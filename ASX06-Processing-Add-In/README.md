# ASX 06 Data Processing Add-In API

ASX 06 把外部算法作为 Filter、Analysis、Post-Analysis 或 Export Add-In 接入 ArtemiS SUITE 的 Automation、Metric、Pool 和 Standardized Test Project。

## 数据交换

ArtemiS SUITE 生成临时 HDF → 启动 M-file 或 EXE → 外部程序读取输入并写输出 → 进程/函数成功结束 → SUITE 继续信号流。

直接读写 HDF 通常还需要 ASX 01。ASX 06 负责“接入流程”，ASX 01 负责“访问数据”。

## 类型

| 类型 | 输入 | 输出 |
| --- | --- | --- |
| Filter | Time Data | Time Data，DataKind=`Recording` |
| Analysis | Time Data | 2D/3D Analysis，不能为 Recording |
| Post-Analysis | Analysis | Analysis |
| Export | Recording/2D/3D | 自定义格式；Merge 接收输入列表 |

## 导航

- [概念](docs/concepts.md) · [参数与生命周期](docs/api-map.md) · [工作流](docs/workflows.md) · [排错](docs/troubleshooting.md) · [官方示例](docs/official-example-index.md) · [示例](examples/README.md)
