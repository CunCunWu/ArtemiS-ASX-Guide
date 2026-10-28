# ASX 02 Data Processing and Representation API

ASX 02 通过 `HEADacoustics.API.Remote` 启动和远程控制 ArtemiS SUITE 图形应用及其服务。它适合自动打开项目、替换数据源、启动计算、管理文档、导出结果和控制主窗口。

## 两个控制目标

| 目标 | 入口 | 许可 |
| --- | --- | --- |
| ArtemiS SUITE GUI | `ArtemiSuiteRemote` / `Application` | ASX 02 |
| Calculator (`ArtemiSproc.exe`) | `ASXRemote` / `Calculator` | ASX 02；服务自动检查 ASX 07 |

ASX 02 不是数据文件 Reader。要直接读取计算生成的 HDF，使用 ASX 01。

## 主要功能

- 启动兼容的 ArtemiS SUITE 或 Calculator；
- 获取版本和应用信息；
- 打开、准备、保存和导出文档；
- 控制 Automation、Pool、Standardized Test 等项目；
- 替换 Report 数据源并导出；
- 启动处理 Job 并观察进度；
- 控制主窗口位置；
- 访问最近录音、事件和 Mark Analyzer 等服务。

## 阅读顺序

1. [核心概念](docs/concepts.md)
2. [服务与 API 地图](docs/api-map.md)
3. [工作流](docs/workflows.md)
4. [排错](docs/troubleshooting.md)
5. [官方示例索引](docs/official-example-index.md)
6. [多语言示例](examples/README.md)
