# ASX 04 排错

| 症状 | 检查 |
| --- | --- |
| Recorder 不可用 | ArtemiS SUITE 版本、ASX 04 许可、Remote 初始化 |
| 前端无法连接 | 设备电源、网络/USB、驱动、设备占用和配置 |
| StartRecord 后无文件 | 基础目录、文件名、Arm 状态、Start Trigger |
| 录音不停止 | Stop Trigger 条件或代码没有调用 StopRecord |
| 文件被覆盖 | 文件名模式不唯一 |
| CAN Remote 无反应 | PCAN 设备、驱动、ID、位率和 SUITE 选项 |

在真实设备上测试前先使用安全通道配置和短录音，任何自动化都应包含强制停止路径。
