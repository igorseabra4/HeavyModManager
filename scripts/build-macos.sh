#!/bin/bash
set -e

# Build and Package Heavy Mod Manager for macOS (Native .app Bundle)

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ROOT_DIR="$(cd "${SCRIPT_DIR}/.." && pwd)"

CONFIGURATION="${1:-Release}"
RID="${2:-osx-arm64}"
OUTPUT_DIR="${ROOT_DIR}/publish"
APP_NAME="Heavy Mod Manager.app"
APP_BUNDLE="${OUTPUT_DIR}/${APP_NAME}"
CONTENTS_DIR="${APP_BUNDLE}/Contents"
MACOS_DIR="${CONTENTS_DIR}/MacOS"
RESOURCES_DIR="${CONTENTS_DIR}/Resources"

echo "=== Building Heavy Mod Manager for macOS ==="
echo "Configuration: ${CONFIGURATION}"
echo "Runtime:       ${RID}"
echo "Output:        ${APP_BUNDLE}"

mkdir -p "${OUTPUT_DIR}"
rm -rf "${APP_BUNDLE}"
mkdir -p "${MACOS_DIR}" "${RESOURCES_DIR}"

echo "--> Publishing .NET project..."
dotnet publish "${ROOT_DIR}/HeavyModManager.Desktop/HeavyModManager.Desktop.csproj" \
    -c "${CONFIGURATION}" \
    -r "${RID}" \
    --self-contained true \
    -o "${MACOS_DIR}"

echo "--> Generating macOS AppIcon.icns..."
ICONSET_DIR="/tmp/HeavyModManager.iconset"
rm -rf "${ICONSET_DIR}"
mkdir -p "${ICONSET_DIR}"

BASE_PNG="/tmp/hmm_base_icon.png"
sips -s format png "${ROOT_DIR}/HeavyModManager/Resources/icon_rainbow.ico" --out "${BASE_PNG}" >/dev/null 2>&1

sips -z 16 16     "${BASE_PNG}" --out "${ICONSET_DIR}/icon_16x16.png" >/dev/null 2>&1
sips -z 32 32     "${BASE_PNG}" --out "${ICONSET_DIR}/icon_16x16@2x.png" >/dev/null 2>&1
sips -z 32 32     "${BASE_PNG}" --out "${ICONSET_DIR}/icon_32x32.png" >/dev/null 2>&1
sips -z 64 64     "${BASE_PNG}" --out "${ICONSET_DIR}/icon_32x32@2x.png" >/dev/null 2>&1
sips -z 128 128   "${BASE_PNG}" --out "${ICONSET_DIR}/icon_128x128.png" >/dev/null 2>&1
sips -z 256 256   "${BASE_PNG}" --out "${ICONSET_DIR}/icon_128x128@2x.png" >/dev/null 2>&1
sips -z 256 256   "${BASE_PNG}" --out "${ICONSET_DIR}/icon_256x256.png" >/dev/null 2>&1

iconutil -c icns "${ICONSET_DIR}" -o "${RESOURCES_DIR}/AppIcon.icns"
rm -rf "${ICONSET_DIR}" "${BASE_PNG}"

echo "--> Generating Info.plist..."
cat <<EOF > "${CONTENTS_DIR}/Info.plist"
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>CFBundleDevelopmentRegion</key>
    <string>en</string>
    <key>CFBundleExecutable</key>
    <string>HeavyModManager.Desktop</string>
    <key>CFBundleIconFile</key>
    <string>AppIcon.icns</string>
    <key>CFBundleIdentifier</key>
    <string>org.heavyironmodding.heavymodmanager</string>
    <key>CFBundleInfoDictionaryVersion</key>
    <string>6.0</string>
    <key>CFBundleName</key>
    <string>HeavyModManager</string>
    <key>CFBundleDisplayName</key>
    <string>Heavy Mod Manager</string>
    <key>CFBundlePackageType</key>
    <string>APPL</string>
    <key>CFBundleShortVersionString</key>
    <string>2026.02.24</string>
    <key>CFBundleVersion</key>
    <string>2026.02.24</string>
    <key>LSMinimumSystemVersion</key>
    <string>10.15</string>
    <key>NSHighResolutionCapable</key>
    <true/>
    <key>NSSupportsAutomaticGraphicsSwitching</key>
    <true/>
</dict>
</plist>
EOF

echo "APPL????" > "${CONTENTS_DIR}/PkgInfo"

chmod +x "${MACOS_DIR}/HeavyModManager.Desktop"

echo "--> Performing ad-hoc codesigning..."
xattr -cr "${APP_BUNDLE}"
codesign --force --deep --sign - "${APP_BUNDLE}"

ZIP_NAME="HeavyModManager-macOS-${RID#osx-}.zip"
echo "--> Creating distribution zip (${ZIP_NAME})..."
ditto -c -k --keepParent "${APP_BUNDLE}" "${OUTPUT_DIR}/${ZIP_NAME}"

echo "=== Build Complete! ==="
echo "Application Bundle created at: ${APP_BUNDLE}"
echo "Distribution Zip created at:   ${OUTPUT_DIR}/${ZIP_NAME}"
