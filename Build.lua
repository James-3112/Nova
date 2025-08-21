workspace "Nova"
    architecture "x64"
    configurations { "Debug", "Release" }
    startproject "Sandbox"

outputdir = "%{cfg.system}-%{cfg.architecture}/%{cfg.buildcfg}"

project "Engine"
    location "Engine"
    kind "StaticLib"
    language "C++"
    cppdialect "C++20"
    staticruntime "on"

    targetdir ("Build/bin/" .. outputdir .. "/%{prj.name}")
    objdir ("Build/bin-int/" .. outputdir .. "/%{prj.name}")

    files { "Engine/include/**.h", "Engine/src/**.cpp" }
    includedirs { "Engine/include", "External/include" }

    -- libdirs { "External/lib/%{cfg.buildcfg}" }
    -- links { "GLFW", "Glad" }

    filter "system:windows"
        systemversion "latest"

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
    staticruntime "on"

    targetdir ("Build/bin/" .. outputdir .. "/%{prj.name}")
    objdir ("Build/bin-int/" .. outputdir .. "/%{prj.name}")

    files { "Sandbox/src/**.h", "Sandbox/src/**.cpp" }
    includedirs { "Engine/include" }

    links { "Engine" }

    filter "system:windows"
        systemversion "latest"

    filter "configurations:Debug"
        runtime "Debug"
        symbols "On"

    filter "configurations:Release"
        runtime "Release"
        optimize "Speed"
