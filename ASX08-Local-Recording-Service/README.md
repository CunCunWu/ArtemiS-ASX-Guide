# ASX 08 Local Recording Service

ASX 08 许可用于启动独立录音服务 `ArtemiSrec.exe`。调用程序仍通过 Remote Recorder API 控制它，因此通常组合为：

- 调用方手动签出 ASX 04 Data Acquisition API；
- `ArtemiSrec.exe` 启动时自动检查 ASX 08 Local Recording Service。

ASX 08 与 ASX 04 的区别：ASX 04 是控制接口，ASX 08 是不启动完整 ArtemiS SUITE GUI 的本地录音宿主许可。

## 导航

- [概念](docs/concepts.md) · [工作流](docs/workflows.md) · [排错](docs/troubleshooting.md) · [官方示例](docs/official-example-index.md) · [示例](examples/README.md)
