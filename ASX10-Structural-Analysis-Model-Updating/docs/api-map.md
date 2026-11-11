# ASX 10 API 地图

## 入口程序集和许可

| 项目 | 值 |
| --- | --- |
| 主程序集 | `HEADacoustics.API.StructuralAnalysis.ModelUpdating.dll` |
| 许可证程序集 | `HEADacoustics.API.License.dll` |
| Shared 程序集 | `HEADacoustics.API.Shared.dll` |
| 命名空间 | `HEADacoustics.API.StructuralAnalysis.ModelUpdating` |
| ProductCode | `ASX_10_StructuralAnalysisModelUpdatingAPI` |

## 几何读取

| 数据来源 | 方法 |
| --- | --- |
| HEAD acoustics `.hmpl` | `MeasurementPointsReader.Read` / `TryRead` |
| Abaqus | `ReadAbaqus` / `TryReadAbaqus` |
| Altair | `ReadAltair` / `TryReadAltair` |
| Ansys | `ReadAnsys` / `TryReadAnsys` |
| Nastran | `ReadNastran` / `TryReadNastran` |
| PERMAS | `ReadPermas` / `TryReadPermas` |
| Universal File | `ReadUniversalFile` / `TryReadUniversalFile` |

第三方几何读取方法要求显式提供 `LengthUnit`。ASX 18.1 支持 `MICROMETER`、`MILLIMETER`、`CENTIMETER`、`METER`、`KILOMETER`、`MIL`、`INCH`、`FEET`、`YARD` 和 `MILES`。

## 振型读取

| 数据来源 | 方法 |
| --- | --- |
| HEAD acoustics `.hstx` | `ShapeTableReader.Read` / `TryRead` |
| Abaqus | `ReadAbaqus` / `TryReadAbaqus` |
| Ansys | `ReadAnsys` / `TryReadAnsys` |
| Nastran | `ReadNastran` / `TryReadNastran` |
| PERMAS | `ReadPermas` / `TryReadPermas` |
| Universal File | `ReadUniversalFile` / `TryReadUniversalFile` |

第三方振型读取方法接收已解析的 `MeasurementPoints`，用于建立振型自由度与几何点之间的映射。

## MAC 计算

| 任务 | 类型或方法 |
| --- | --- |
| 计算完整矩阵 | `MacCalculator.CalculateMacMatrix` |
| 带错误码计算 | `MacCalculator.TryCalculateMacMatrix` |
| 查询指定振型对 | `MacMatrix.GetValue` / `TryGetValue` |
| 按阈值筛选 | `MacMatrix.GetValues` |
| 单个匹配结果 | `MacValue.Value`、`ShapeA`、`ShapeB` |
| 振型信息 | `Shape.Frequency`、`Attenuation`、`Mpc` |
