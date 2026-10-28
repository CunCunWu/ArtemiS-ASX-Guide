# ASX 02 典型工作流

## 启动 GUI 并获取服务

```text
签出 ASX 02 → ForLatestApplication → 检查 Application.IsAvailable
→ Start → Get...Service → 执行业务操作
```

## Calculator 批处理

```text
签出 ASX 02 → ASXRemote.ForLatestApplication
→ 启动 Calculator（自动需要 ASX 07）
→ GetProcessingService → StartJob
→ 注册进度 → Wait/await → 检查 JobSummary.ResultFiles
```

处理例程为 `.hpsx`，输入和输出路径必须由调用方验证。具体分析步骤可能需要额外 ASP/ASX 许可。

## 项目自动化

典型顺序：打开项目、清理或替换源、修改变量、启动计算、等待完成、保存或导出。任何“打开后再修改”的操作都应等待前一步完成。

## Report 数据交换

通过 Reporting Service 打开 Report，读取角色/数据源，替换文件或文件夹源，再导出 PDF。离线直接编辑 `.hrpx` 则使用 ASX 09。
