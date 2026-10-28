# ASX 05 排错

| 症状 | 处理 |
| --- | --- |
| Form/Field 添加失败 | 检查唯一命名和非法空格/`@` |
| UDI 无法修改 | 先转换为 User Documentation |
| 写入返回失败 | 检查 ActionResult、目标权限和对象有效性 |
| HDF 中看不到文档 | 确认写的是 Embedded 还是 External |
| 类型方法不匹配 | 用与 Field 实际类型一致的 Getter/Setter |
| 模板损坏 | 写入新文件并保留原 `.hatx` |
