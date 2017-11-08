#! /bin/sh

project="TEST"

echo "Attempting to build $project for Windows"
C:\Program Files\Unity\Editor\Unity.exe \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd)/Serious Nutrition Game \
  -buildWindows64Player "$(pwd)/Serious Nutrition Game/$project.exe" \
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
