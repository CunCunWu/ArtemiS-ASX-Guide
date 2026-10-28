# C#

Build for .NET Framework 4.8 x64. Restore the PackageReferences before building.

```powershell
msbuild .\Asx02Examples.csproj /restore /p:Configuration=Release /p:Platform=x64
.\bin\Release\Asx02Examples.exe move-window
.\bin\Release\Asx02Examples.exe run-calculator <routine.hpsx> <input> <result-directory>
```
