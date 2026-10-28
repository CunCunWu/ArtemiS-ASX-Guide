# ASX 18.1 官方示例索引

本页记录随 ASX 18.1 安装的 ASX 01 示例场景，方便用户和智能体知道官方资料已经覆盖哪些能力。以下代码没有复制到本仓库；请从合法 ASX 安装的离线帮助中阅读。

默认文档根目录：

```text
C:\Program Files\HEAD System Integration and Extension (ASX)\Documentation
```

## HDF Library

目录：`hdf\examples`

| 官方页面 | 场景 | C# | Python | MATLAB |
| --- | --- | --- | --- | --- |
| `ExampleDifferentHdfTypes.html` | 识别 Time/2D/3D 及 Real/Complex，并选择 Reader | 是 | 是 | 是 |
| `ExampleReading2D.html` | 读取 2D 分析数据 | 是 | 是 | 是 |
| `ExampleModifying2D.html` | 修改并写入 2D 数据 | 是 | 是 | 是 |
| `Example2DFromScratch.html` | 从零创建 2D 文件 | 是 | 是 | 是 |
| `ExampleReadingTimeData.html` | 读取采样通道和元数据 | 是 | 是 | 是 |
| `ExampleModifyingTimeData.html` | 修改 Time Data | 是 | 是 | 是 |
| `ExampleBlockWritingTimeData.html` | 分块读取和写入 Time Data | 是 | 是 | 是 |
| `ExampleTimeDataFromScratch.html` | 从零创建 Time Data | 是 | 是 | 是 |
| `ExampleReading3D.html` | 读取 3D 轴和通道 | 是 | 是 | 是 |
| `ExampleModifying3D.html` | 修改并写入 3D 数据 | 是 | 是 | 是 |
| `Example3DFromScratch.html` | 从零创建 3D 文件 | 是 | 是 | 是 |
| `ExampleDifferentPulseChannels.html` | 区分不同脉冲通道 | 是 | 是 | 是 |
| `ExampleModifyingPulseDataAsBoolean.html` | 以布尔数据处理脉冲 | 是 | 是 | 是 |
| `ExampleModifyingPulseDataAsEvent.html` | 以事件处理脉冲 | 是 | 是 | 是 |
| `ExampleUsingSingleValues.html` | 在 HDF 通道中使用 SingleValue | 是 | 是 | 是 |
| `ExampleReading2DToleranceCheck.html` | 读取容差检查结果 | 是 | 是 | 是 |
| `ExampleFileDateCreate.html` | 创建文件日期信息 | 是 | 是 | 是 |

官方样例 HDF 通常位于 `hdf\data`，包括 Time Data、2D、3D、Tolerance Check 和 Pulse 数据。

## HSVX Library

目录：`hsvx\examples`

| 官方页面 | 场景 |
| --- | --- |
| `ExampleReadingHsvx.html` | 读取 HSVX 单值 |
| `ExampleReadingHsvxLimits.html` | 读取单值 limits |
| `ExampleModifyingHsvx.html` | 修改 HSVX |
| `ExampleModifyingHsvxWithLimits.html` | 修改带 limits 的 HSVX |
| `ExampleHsvxFromScratch.html` | 从零创建 HSVX |
| `ExampleHsvxWithLimitsFromScratch.html` | 创建带 limits 的 HSVX |
| `ExampleCreatingHsvxWithLimitsFor3DSingleValue.html` | 为 3D 单值条件创建带限值结果 |

这些页面同样提供 C#、Python 和 MATLAB 版本。

## MATLAB SHDF

目录：`shdf\Examples`

- `ReadingTimeData.html` / `WritingTimeData.html`；
- `Reading2DData.html` / `Writing2DData.html`；
- `Reading3DData.html` / `Writing3DData.html`。

SHDF 是 ArtemiS SUITE MATLAB Import/Export 使用的结构化 MAT 数据，不等同于通过 MATLAB .NET 接口直接调用 ASX 01。两种方法的选择见 [MATLAB SHDF 数据交换](matlab-shdf.md)。

## 如何使用本索引

1. 先在本仓库确定数据类型和 Reader/Writer。
2. 在官方页面查看当前安装版本的完整签名和代码。
3. 将官方示例中的固定路径改为参数。
4. 增加输入检查、异常处理、资源释放和输出复读验证。
5. 不把官方示例中的特定物理量或 DataKind 无条件复制到其他业务。

