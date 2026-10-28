# ASX 08 核心概念

入口是 `ASXRemote.ForLatestApplication(...).StandAloneRecorder`。检查 `IsAvailable`，需要时调用异步 `Start()`，再通过 `GetRecorderService()` 获取与 ASX 04 相同的 Configuration、Control 和 Trigger 服务。

独立 Recorder 适合无完整 GUI 的自动录音站，但仍需要合法设备配置、前端驱动、ASX 04 和 ASX 08 许可证。

服务启动成功不等于前端已连接或可以安全录音。
