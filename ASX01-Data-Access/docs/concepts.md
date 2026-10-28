# ASX 01 核心概念

## 文件类别

`HdfInfo.Create(path)` 返回文件的 `HdfType` 和 `DataType`。常见组合：

| HdfType | DataType | 含义 |
| --- | --- | --- |
| `TimeData` | `Real` | 时间记录或采样数据 |
| `AnalysisData2D` | `Real` | 实数二维分析曲线 |
| `AnalysisData2D` | `Complex` | 复数二维分析曲线 |
| `AnalysisData3D` | `Real` | 实数三维分析结果 |
| `AnalysisData3D` | `Complex` | 复数三维分析结果 |

不要仅凭 `.hdf` 扩展名选择 Reader。

## 数据对象

一个通道不仅是数值数组，还包括：

- `FileInfo`：标题、注释、日期及文件级信息；
- `ChannelInfo`：名称、标题、缩写、传感器和自由度信息；
- `Abscissa`：横轴及其物理量；
- `Ordinate`：纵轴范围及其物理量；
- `Quantity`：ID、单位、Domain 和 Weighting；
- `DataKind`：数据用途，例如 Recording 或特定分析结果。

变换数据时必须同步考虑这些元数据。只修改数值、不维护单位和轴，会生成语义错误但可能仍可打开的文件。

## 横轴类型

- `EquidistantAbscissa`：等间距时间或频率轴；
- `TickListAbscissa`：非等间距刻度；
- `BandAbscissa`：标准频带；
- `UserDefinedBandAbscissa`：自定义频带。

## 2D 与 3D

- 2D 通道：一个横轴对应一个实数或复数向量。
- 3D 通道：第一横轴定位向量，第二横轴描述向量内部点。可理解为多个谱随时间、转速等变化。

## Time Data

Time Data 可能包含：

- sampled channels；
- control signals；
- pulse channels；
- pulse-rate channels；
- pulse-trigger channels；
- event channels。

普通时域信号优先使用 `GetSampledChannels()`；只有确实需要混合处理所有流式通道时才使用 `GetChannels()`。

## HSVX 与 SingleValue

HSVX 保存一个或多个单值通道。每个 `SingleValue` 可带物理量、moniker、横轴条件和 limits。HSVX 使用 HDF API 中的若干不可变对象，但自身提供可修改的 source/channel 对象。

## 资源生命周期

- `License`、流式 Reader、3D Reader 和 Writer 应可靠释放；
- 流式 Writer 在通道定义后调用 `EndSetup()`；
- 写完数据后调用 `Close()`；
- 异常路径同样必须释放资源。

