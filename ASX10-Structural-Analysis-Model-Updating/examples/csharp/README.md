# C#

来源：`official-adapted`。

推荐使用 SDK-style C# 项目、x64 目标，并引用：

- `HEADacoustics.API.StructuralAnalysis.ModelUpdating.dll`；
- `HEADacoustics.API.License.dll`；
- `HEADacoustics.API.Shared.dll`。

非 SDK 项目必须特别检查 `Prefer32Bit=false`，否则依赖解析不正确时可能出现 `BadImageFormatException`。

运行格式：

```text
CalculateMacMatrix.exe <simulation.pch> <geometry.bdf> <measurement.hstx> [threshold]
```

示例：

```powershell
CalculateMacMatrix.exe .\TorqueSupport.pch .\TorqueSupport.bdf .\Measurement.hstx 0.7
```
