# ASX 05 Documentation and Metadata API

ASX 05 用于读取、创建、修改和保存 ArtemiS SUITE User Documentation，并处理 Documentation Template (`.hatx`) 和旧版 UDI。

## 主要能力

- 读取文件、HDF 内嵌或目录的 User Documentation；
- 从零创建 Documentation、Form 和 Field；
- 修改字段值以及 Editable/Mandatory/Visible 等属性；
- 读写 `.hatx` Documentation Template；
- 读取旧 ArtemiS Classic/HEAD Recorder UDI；
- 将只读 UDI 转换成新的 User Documentation；
- 搜索属性并批量更新。

## 关键限制

旧 UDI 只能读取，不能直接修改或写回；应先通过 `DocumentationConverter` 转换。Form 名在整个文档中唯一，不能以 `@` 开头，也不能以空格开头或结尾；Field 名在父级中唯一。

## 导航

- [概念](docs/concepts.md) · [API 地图](docs/api-map.md) · [工作流](docs/workflows.md) · [排错](docs/troubleshooting.md) · [官方示例](docs/official-example-index.md) · [多语言示例](examples/README.md)
