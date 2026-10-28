# ASX 04 Data Acquisition API

ASX 04 通过 Remote Recorder 服务远程准备和控制 ArtemiS SUITE Recorder。它可以连接前端、配置文件名和目录、加载/保存设置、设置触发器以及开始/停止监控、播放和录音。

## 两种运行方式

- ArtemiS SUITE 内置 Recorder：需要 ASX 04；不因只使用 Recorder 而额外要求 ASX 02。
- 独立 `ArtemiSrec.exe`：远程调用仍需 ASX 04，服务启动还会自动检查 ASX 08。

独立录音服务详见 [ASX 08](../ASX08-Local-Recording-Service/)。

## 阅读顺序

1. [概念与安全](docs/concepts.md)
2. [服务地图](docs/api-map.md)
3. [工作流](docs/workflows.md)
4. [排错](docs/troubleshooting.md)
5. [官方示例](docs/official-example-index.md)
6. [多语言示例](examples/README.md)
