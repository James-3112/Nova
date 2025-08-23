workspace "NovaEngine"
    architecture "x64"
    configurations { "Debug", "Release" }
    startproject "Sandbox"

outputdir = "%{cfg.system}-%{cfg.architecture}/%{cfg.buildcfg}"


project "Nova"
    location "Engine"
    kind "StaticLib"
    language "C++"
    cppdialect "C++20"

    targetdir ("Build/bin/" .. outputdir .. "/%{prj.name}")
    objdir ("Build/bin-int/" .. outputdir .. "/%{prj.name}")

    files {
        "Engine/include/**.h",
        "Engine/src/**.c",
        "Engine/include/**.hpp",
        "Engine/src/**.cpp",

        "External/src/**.c",
        "External/src/**.cpp"
    }

    includedirs { "Engine/include", "External/include" }

    libdirs { "External/lib" }
    links { "glfw3", "opengl32" }

    filter "system:windows"
        systemversion "latest"
        linkoptions { "/NODEFAULTLIB:MSVCRT" }

    filter "configurations:Debug"
        runtime "Debug"
        symbols "On"

    filter "configurations:Release"
        runtime "Release"
        optimize "Speed"


project "Sandbox"
    location "Sandbox"
    kind "ConsoleApp"
    language "C++"
    cppdialect "C++20"

    targetdir ("Build/bin/" .. outputdir .. "/%{prj.name}")
    objdir ("Build/bin-int/" .. outputdir .. "/%{prj.name}")

    files {
        "Sandbox/src/**.h",
        "Sandbox/src/**.c",
        "Sandbox/src/**.hpp",
        "Sandbox/src/**.cpp",

        "External/src/**.c",
        "External/src/**.cpp"
    }
    
    includedirs { "Engine/include", "External/include" }

    libdirs { "External/lib" }
    links { "Nova", "glfw3", "opengl32" }

    filter "system:windows"
        systemversion "latest"
        linkoptions { "/NODEFAULTLIB:MSVCRT" }

        -- Copy Resources folder after build
        postbuildcommands {
            'powershell -command "if (Test-Path \\"%{cfg.targetdir}/Resources\\") { Remove-Item \\"%{cfg.targetdir}/Resources\\" -Recurse -Force }"',
            'xcopy /E /I /Y "%{prj.location}/Resources" "%{cfg.targetdir}/Resources"'
        }

    filter "configurations:Debug"
        runtime "Debug"
        symbols "On"

    filter "configurations:Release"
        runtime "Release"
        optimize "Speed"
