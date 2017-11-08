#! /bin/sh

project="SNG"
PROJECTFOLDER = "Serious Nutrition Game"

echo "Attempting to build $project for Windows"
D:/Programs/programs/Unity/Editor/Unity.exe \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath=$(pwd) \
  -buildWindows64Player "$(pwd)/$project.exe" \
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
