# ASX 01 Data Access API

ASX 01 是 ASX 中负责 HEAD acoustics 数据访问的模块。它提供 HDF/HSVX 文件识别、读取、创建和写入能力，并维护通道、坐标轴、物理量、单位、DataKind、单值和容差等语义信息。

## ASX 01 能做什么

- 识别 Time Data、2D Analysis 和 3D Analysis HDF；
- 读取和写入实数或复数 2D 数据；
- 分块读取和流式写入长时间信号；
- 访问采样、控制、脉冲、脉冲率、触发和事件通道；
- 读取和写入实数或复数 3D 数据；
- 读取、创建和修改 HSVX 单值结果；
- 维护文件和通道元数据；
- 保存并检查单值限值和容差结果。

ASX 01 不负责自动执行 FFT、响度或其他分析算法，也不负责把程序接入 ArtemiS SUITE 的 Add-In 流程。算法由调用方实现；Processing Add-In 集成属于 ASX 06。

## 功能地图

| 数据/任务 | 读取接口 | 写入接口 |
| --- | --- | --- |
| 文件识别 | `HdfInfo` | 不适用 |
| 2D 实数/复数 | `Reader.Read2D` | `Writer` |
| Time Data | `StreamReader` | `StreamWriter` |
| 3D 实数 | `Real3DReader` | `Real3DWriter` |
| 3D 复数 | `Complex3DReader` | `Complex3DWriter` |
| HSVX 单值 | `HsvxReader` | `HsvxWriter` |
| 限值检查 | `LimitInspector` | `Limit`、`SingleValue` |

## 推荐阅读顺序

1. [核心概念](docs/concepts.md)
2. [API 选择地图](docs/api-map.md)
3. [典型工作流](docs/workflows.md)
4. [常见问题](docs/troubleshooting.md)
5. [MATLAB SHDF 数据交换](docs/matlab-shdf.md)
6. [官方示例索引](docs/official-example-index.md)
7. [多语言示例](examples/README.md)

## 最小生命周期

```text
检查路径和参数
    ↓
License.Create(ASX_01_DataAccessAPI)
    ↓
HdfInfo.Create(path) 识别数据
    ↓
选择正确 Reader
    ↓
读取数据与元数据
    ↓
可选：处理并使用匹配的 Writer 写入
    ↓
重新打开输出进行验证
    ↓
Dispose/Close Reader、Writer、License
```

## 示例语言

- [C#](examples/csharp/README.md)：直接引用 .NET Framework 程序集；
- [Python](examples/python/README.md)：通过 pythonnet 调用同一套 .NET API；
- [MATLAB](examples/matlab/README.md)：通过 MATLAB .NET 接口调用同一套 API。

三种语言使用的是同一数据模型，不是三套独立 API。

