# ASX 04 服务地图

| 服务 | 获取方法 | 典型功能 |
| --- | --- | --- |
| Configuration | `GetConfigurationService()` | 连接前端、加载/保存全部或部分设置 |
| Control | `GetControlService()` | 文件名、目录、监控、播放、录音启停 |
| Trigger | `GetTriggerService()` | 创建、修改、删除 Start/Stop Trigger |

核心程序集为 `HEADacoustics.API.Remote.dll`，Recorder 类型位于 `HEADacoustics.API.Remote.Recorder` 命名空间。

CAN Remote 是另一种控制方式，需要兼容 PEAK PCAN 适配器、驱动及 ArtemiS SUITE 选项配置；它不是 .NET Remote 服务的替代实现。
