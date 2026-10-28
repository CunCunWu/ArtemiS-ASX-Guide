# ASX 05 核心概念

- `Documentation`：可修改的 User Documentation 根对象；
- `Form`：字段分组；
- Field：Text、Date、Integer、Real 等具体字段类型；
- 外部 Documentation：与文件或目录关联保存；
- Embedded Documentation：写入 HDF；
- Template：`.hatx` 文档模板；
- Legacy UDI：旧格式，只读；
- `ActionResult`：Try/Write 操作的状态和错误信息。

Integer/Real Field 还可带 MinValue、MaxValue 和 Unit；Text Field 可带 MaxLength。复制对象时优先使用 Clone，避免多个文档意外共享可修改状态。
