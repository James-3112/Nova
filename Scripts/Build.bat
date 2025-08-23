@echo off

set CONFIG=%1
if "%CONFIG%"=="" set CONFIG=Debug

echo =====================================
echo Generating Visual Studio Solution with Premake...
echo =====================================
Premake\premake5-Windows.exe --file=Build.lua vs2022

echo =====================================
echo Building Solution with MSBuild...
echo =====================================
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" "NovaEngine.sln" /t:Build /p:Configuration=%CONFIG% /m
