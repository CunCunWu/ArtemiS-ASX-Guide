# ASX 09 Reporting API

ASX 09 用于离线读取、修改、保存和导出 ArtemiS SUITE Report (`.hrpx`)。它可以替换或复制 Report DataSource，并导出 PDF 或 PowerPoint。

## 主要能力

- `ReportReader` 读取 Report；
- 访问 `DataSourceCollection`；
- 按名称交换数据或复制 DataSource 与 bindings；
- `ReportWriter` 保存新的 Report；
- `ReportExporter` 导出 PDF/PPTX；
- 注册异步 Job 进度；
- 在读取任何 Report 前应用 Quantity Modifications。

ASX 09 是 Report 文件 API；通过运行中的 ArtemiS SUITE 控制 Report 属于 ASX 02 Reporting Service。

## 导航

- [概念](docs/concepts.md) · [API 地图](docs/api-map.md) · [工作流](docs/workflows.md) · [排错](docs/troubleshooting.md) · [官方示例](docs/official-example-index.md) · [多语言示例](examples/README.md)
