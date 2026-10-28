# ASX 07 Local Processing Service

ASX 07 提供 `ArtemiSproc.exe`，无需启动 ArtemiS SUITE 图形界面即可在命令行执行 `.hpsx` 处理例程，适合批处理、测试台和端到端自动评价。

ASX 07 是本地服务，不是新的算法库。HPSX 中使用的分析仍可能需要相应 ASP/ASX 许可。

## 最小调用

```text
ArtemiSproc.exe /job routine.hpsx /src input.hdf
```

必需：`/job` 和至少一个 `/src` 或 `/srcr`。服务启动时自动检查 ASX 07。

## 导航

- [概念与参数](docs/concepts.md) · [工作流](docs/workflows.md) · [退出码和排错](docs/troubleshooting.md) · [官方示例](docs/official-example-index.md) · [包装器示例](examples/README.md)
