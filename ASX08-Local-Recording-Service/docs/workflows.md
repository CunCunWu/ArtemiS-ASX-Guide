# ASX 08 工作流

```text
签出 ASX 04
→ ASXRemote.ForLatestApplication
→ StandAloneRecorder.IsAvailable / Start
→ GetRecorderService
→ 连接或加载前端配置
→ 设置目录、文件名、触发器
→ StartRecord / StopRecord
→ 验证文件
```

守护进程式应用应处理服务意外退出、设备断开、许可证丢失和强制停止，并限制自动重试次数。
