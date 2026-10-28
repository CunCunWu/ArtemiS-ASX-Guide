# C# examples

## Requirements

- ASX 18.1 x64 installed;
- ASX 01 Data Access API license;
- .NET Framework 4.8 Developer Pack;
- x64 build.

## Build

```powershell
msbuild .\Asx01Examples.csproj /p:Configuration=Release /p:Platform=x64
```

The project defaults `ASX_DIR` to the standard installation directory. Override it with `/p:ASX_DIR="D:\ASX"` when needed.

## Commands

```powershell
.\bin\Release\Asx01Examples.exe inspect <input.hdf>
.\bin\Release\Asx01Examples.exe read-time <input.hdf>
.\bin\Release\Asx01Examples.exe read-2d <input.hdf>
.\bin\Release\Asx01Examples.exe read-3d <input.hdf>
.\bin\Release\Asx01Examples.exe create-hsvx <output.hsvx>
```

These examples are `official-adapted`: they follow the ASX 18.1 help scenarios while using command-line paths and one reusable project. They do not redistribute vendor binaries or test data.

