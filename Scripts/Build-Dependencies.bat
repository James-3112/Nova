@echo off

cd ..

echo =====================================
echo Generating Visual Studio Solution with Premake...
echo =====================================
Premake\premake5-Windows.exe --file=ExternalSources/ExternalBuild.lua vs2022

echo =====================================
echo Building Solution with MSBuild...
echo =====================================
"C:/Program Files/Microsoft Visual Studio/2022/Community/MSBuild/Current/Bin/MSBuild.exe" ExternalSources/build/ExternalBuild.sln /t:Build /p:Configuration=Release /m

echo =====================================
echo Build Complete!
echo =====================================

pause
