# ASX 04 概念与安全

Recorder 控制属于设备和文件写入操作。示例不能保证任意前端、通道配置或触发条件安全适用。

关键状态包括：Recorder 未准备、已准备、已 Arm 等待触发、正在录音、停止。启动录音前应验证：

- 前端已连接；
- 通道和采样设置正确；
- 基础目录可写；
- 文件名不会覆盖重要数据；
- Start/Stop Trigger 符合测试规范；
- StopRecord 和异常清理路径存在。

## 服务层次

`ArtemiSuiteRemote` → `Application` → `Recorder` → Configuration/Control/Trigger services。

只使用 Recorder 时签出 `ASX_04_DataAcquisitionAPI`。
