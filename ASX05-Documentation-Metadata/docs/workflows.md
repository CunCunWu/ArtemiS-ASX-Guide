# ASX 05 工作流

## 创建目录文档

签出 ASX 05 → `Documentation.Create` → AddField/AddForm → `DocumentationWriter.WriteDirectoryDocumentation` → 检查 ActionResult。

## 修改 HDF 文档

读取 external/embedded documentation → 查找 Form/Field → 使用 TrySet 或类型专用方法修改 → 写回明确目标 → 重新读取验证。

## 模板

`TemplateReader.Read` → 修改克隆对象 → `TemplateWriter.Write` 到新 `.hatx`。默认不要覆盖原模板。

## 旧 UDI

`LegacyUdiReader` → 得到只读 `IDocumentation` → `ToUserDocumentation` → 修改转换结果 → 使用新 Writer 保存。
