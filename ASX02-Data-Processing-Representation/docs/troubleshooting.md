# ASX 02 排错

| 症状 | 原因 | 处理 |
| --- | --- | --- |
| 找不到兼容应用 | ASX/ArtemiS SUITE 未安装或版本不兼容 | 用 `ForAllCompatibleApplications` 检查 |
| `Application.IsAvailable` 为 false | 可执行文件未找到或不可启动 | 检查安装和 `ForExecutable` 路径 |
| Calculator 启动失败 | ASX 07 不可用 | 检查 Local Processing Service 许可 |
| Job 不结束 | 未等待异步任务、输入无效或流程内部阻塞 | 注册进度并检查日志/Job 摘要 |
| .NET 依赖冲突 | 缺少 NuGet 依赖或 binding redirects | 按官方集成页添加依赖 |
| 新服务不可用 | Remote DLL 与应用版本组合不匹配 | 使用同版本 ASX Remote DLL |

不要用固定 sleep 代替可等待的 Job 完成信号。
