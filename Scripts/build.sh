#! /bin/sh

project="TEST"
MAINDIR = "C:\Program Files"
PROJECTFOLDER = "Serious Nutrition Game"

echo "Attempting to build $project for Windows"
$(MAINDIR)\Unity\Editor\Unity.exe \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd)/$(PROJECTFOLDER) \
  -buildWindows64Player "$(pwd)/$(PROJECTFOLDER)/$project.exe" \
  -quit

# echo "Attempting to build $project for OS X"
# C:\Program Files\Unity\Editor\Unity.exe \
#   -batchmode \
#   -nographics \
#   -silent-crashes \
#   -logFile $(pwd)/unity.log \
#   -projectPath $(pwd) \
#   -buildOSXUniversalPlayer "$(pwd)/Build/osx/$project.app" \
#   -quit

echo 'Logs from build'
cat $(pwd)/unity.log
