# ASX 04 工作流

## 基本录音

```text
签出 ASX 04 → 选择并启动 ArtemiS SUITE
→ 获取 Recorder → 检查/连接前端
→ 设置基础目录和文件名模式
→ 可选配置触发器 → StartRecord
→ 等待测试完成或触发 Stop → StopRecord
→ 验证生成文件
```

## 触发录音

设置 Trigger 后，StartRecord 可能只是 Arm。程序必须区分“等待触发”和“正在记录”，并设置超时或取消策略，避免永久等待。

## 配置管理

可保存或加载 Recorder 设置。批处理前应明确是完整加载还是只加载部分配置，避免覆盖当前设备参数。
