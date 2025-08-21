@echo off

cd ..

echo =====================================
echo Generating Visual Studio Solution with Premake...
echo =====================================
Premake\premake5-Windows.exe --file=Build.lua vs2022

echo =====================================
echo Setup Complete!
echo =====================================

pause
