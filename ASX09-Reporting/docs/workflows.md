# ASX 09 工作流

## 导出

签出 ASX 09 → 可选应用 Quantity Modifications → 读取 HRPX 并等待 → 创建 ExportSettings → 导出 PDF/PPTX 并等待 → Dispose Report。

## 修改并保存

读取 → 列出 DataSource 名称 → 按名称取得目标 → Exchange 或 DuplicateWithBindings → 写到新 HRPX → 重新读取验证。

## 批量

不要跨线程共享同一个 Report 对象。限制并发，记录每个 Job 的进度、错误和输出路径，避免多个任务写同一文件。
