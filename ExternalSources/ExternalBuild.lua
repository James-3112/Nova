-- Load the library configuration
include "Libraries.lua"

workspace "ExternalBuild"
    architecture "x64"
    configurations { "Debug", "Release" }
    location "build"

-- Use the first library as the start project (default)
startproject(libs[1].name)

-- Loop through all libraries and generate a project for each
for _, lib in ipairs(libs) do
    project(lib.name)
        kind(lib.kind or "StaticLib")
        language(lib.language or "C++")
        staticruntime "on"

        -- Output folders
        targetdir(externalLib)              -- final .lib / .a output
        objdir("build/obj/" .. lib.name)    -- intermediate object files

        -- Source files
        files {
            path.join(libdir, lib.name, lib.srcdir, table.concat(lib.files, " "))
        }

        -- Include directories for compilation
        local resolvedIncludes = {}
        for _, inc in ipairs(lib.includedirs) do
            table.insert(resolvedIncludes, path.join(libdir, lib.name, inc))
        end
        includedirs(resolvedIncludes)

        -- Platform-specific settings
        filter "system:windows"
            systemversion "latest"

        filter "system:linux"
            pic "On"

        -- Configuration-specific settings
        filter "configurations:Debug"
            runtime "Debug"
            symbols "On"

        filter "configurations:Release"
            runtime "Release"
            optimize "Speed"

        filter {}

        -- Post-build: copy each include folder to External/include/[LibName]
        for _, inc in ipairs(resolvedIncludes) do
            postbuildcommands {
                ("{COPYDIR} " .. inc .. " " .. path.join(externalInclude, lib.name))
            }
        end
end
