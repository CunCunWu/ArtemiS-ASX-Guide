# API 选择地图

## 先识别，后读取

```text
HdfInfo.Create(path)
│
├─ TimeData ───────────────→ StreamReader
├─ AnalysisData2D / Real ──→ Reader.Read2D().RealChannels
├─ AnalysisData2D / Complex → Reader.Read2D().ComplexChannels
├─ AnalysisData3D / Real ──→ Real3DReader
└─ AnalysisData3D / Complex → Complex3DReader
```

HSVX 使用 `HsvxReader.ReadFromHsvxFile`，不走上述 HDF Reader 分支。

## Reader/Writer 对照

### 2D

- `Reader.Read2D(path)`：返回 `ReaderResult`；
- `ReaderResult.RealChannels`：`RealChannel[]`；
- `ReaderResult.ComplexChannels`：`ComplexChannel[]`；
- `Writer.Create(fileInfo)`；
- `Writer.AddChannel/AddChannels`；
- `Writer.Write(path)`。

2D Reader 一次返回通道数据，适合中小型曲线文件。

### Time Data

- `StreamReader.Create(path)`；
- `GetSampledChannels()`、`GetPulseChannels()` 等；
- `channel.GetData(offset, count)`；
- `StreamWriter.Create(...)`；
- `CreateSampledChannel(...)` 或从 Reader 通道复制结构；
- `EndSetup()`；
- `AppendData(block)`；
- `Close()`。

长时间信号必须按块读取，避免 `GetData(0, NumberOfSamples)`。

### 3D

- 实数：`Real3DReader/Real3DWriter`；
- 复数：`Complex3DReader/Complex3DWriter`；
- `GetVector(index)`：读取一个向量；
- `GetVectors(start, count)`：分块读取；
- `AppendVector(...)`：逐向量写入。

### HSVX

- `HsvxReader.ReadFromHsvxFile(path)`；
- `HsvxSingleValueSource.Channels`；
- `SingleValue`；
- `HsvxWriter.WriteToHsvxFile(source, path)`。

## 元数据构造器

| 类型 | 作用 |
| --- | --- |
| `FileInfo` | 文件标题、注释、日期、Mark/Cut/容差信息 |
| `ChannelInfo` | 通道名、标题、缩写、传感器、DOF |
| `Quantity` | 物理量 ID、单位、Domain、Weighting |
| `Ordinate` | 纵轴范围和 Quantity |
| `EquidistantAbscissa` | 起点、步长、点数和 Quantity |
| `TickListAbscissa` | 非等间距刻度 |
| `BandAbscissa` | 标准频带 |
| `SingleValue` | 单值、moniker、Quantity 和 limits |

## 选择规则

1. 不确定 HDF 类型时，始终先用 `HdfInfo`。
2. Time Data 只用 Stream API。
3. 2D 使用 `Reader/Writer`，不要用 Stream API。
4. 3D 根据 `DataType` 选择 Real 或 Complex API。
5. 不要用实数 Reader 丢弃复数结果的相位信息。
6. 写入时使用与读取数据结构匹配的 Writer。

