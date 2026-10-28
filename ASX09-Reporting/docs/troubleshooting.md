# ASX 09 排错

| 症状 | 检查 |
| --- | --- |
| 读取 HRPX 失败 | 文件版本、依赖数据、权限、ErrorCode |
| 找不到 DataSource | 使用 `GetNames` 检查实际名称 |
| 导出为空或缺页 | 数据源有效性和 ExportSettings range |
| Quantity 修改不生效 | 是否在首次读取 Report 前应用 |
| 文件被占用 | Report 是否 Dispose，输出是否被 PowerPoint/PDF 查看器占用 |
| Job 表面启动但无结果 | 是否调用 Wait/await 并检查异常 |
