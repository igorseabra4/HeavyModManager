# Heavy Mod Manager
![HeavyModManager_DgMBEaWLCN](https://github.com/user-attachments/assets/1590df65-7796-4fb1-bb18-1a326c4a4760)

Heavy Mod Manager is a mod manager for GameCube and Wii games emulated on Dolphin, built with Heavy Iron Studios games in mind.

It is intended for use on the following games:
- Scooby-Doo! Night of 100 Frights
- SpongeBob SquarePants: Battle for Bikini Bottom
- The SpongeBob SquarePants Movie
- The Incredibles
- The Incredibles: Rise of the Underminer
- Ratatouille (January 18th, 2006 Prototype)

## Platforms & Installation

Heavy Mod Manager runs on **macOS** (Apple Silicon & Intel) and **Windows** (requires [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later).

### macOS
1. Download `Heavy Mod Manager.app` from Releases or build it from source.
2. Drag `Heavy Mod Manager.app` to your `/Applications` folder (or run it from anywhere).
3. If Dolphin is installed in `/Applications/Dolphin.app`, Heavy Mod Manager automatically detects it along with your emulator settings in `~/Library/Application Support/Dolphin/`.

### Windows
1. Download the latest release `.zip`.
2. Extract and launch `HeavyModManager.exe` (or `HeavyModManager.Desktop.exe`).

---

## Building from Source

Make sure to clone recursively to pull in the `HipHopTool` submodule:

```bash
git clone --recurse-submodules https://github.com/DarthMDev/HeavyModManager.git
cd HeavyModManager
```

If you already cloned without submodules, initialize them:
```bash
git submodule update --init --recursive
```

### Build & Run Desktop App
```bash
dotnet run --project HeavyModManager.Desktop
```

### Build macOS App Bundle (.app)
For Apple Silicon (M1/M2/M3/M4):
```bash
./scripts/build-macos.sh Release osx-arm64
```

For Intel Macs:
```bash
./scripts/build-macos.sh Release osx-x64
```

The resulting standalone, ad-hoc signed app bundle will be placed in `publish/Heavy Mod Manager.app`.

---

## How to Use
Check out the [Heavy Iron Modding Wiki](https://heavyironmodding.org/wiki/Heavy_Mod_Manager) or watch the [video tutorial](https://www.youtube.com/watch?v=ndK9nN9i-rw) to get started.
