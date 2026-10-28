# ASX 01 示例

示例覆盖三种语言，但调用的是同一套 ASX .NET 数据模型。

| 示例 | C# | Python | MATLAB | 来源 |
| --- | --- | --- | --- | --- |
| 自动识别 HDF 类型 | 是 | 是 | 是 | official-adapted |
| 读取 Time Data | 是 | 是 | 是 | official-adapted |
| 读取 2D Analysis | 是 | 是 | 是 | official-adapted |
| 读取 3D Analysis | 是 | 是 | 是 | official-adapted |
| 创建 HSVX 单值 | 是 | 是 | 是 | official-adapted |

`official-adapted` 表示示例依据 ASX 18.1 安装目录中的官方帮助场景重新组织，增加了命令行参数、统一初始化和资源释放；这里不复制厂商 DLL 或示例数据。

随 ASX 18.1 安装的完整示例场景及路径见[官方示例索引](../docs/official-example-index.md)。

## 测试数据

官方 ASX 18.1 帮助安装通常包含测试数据：

```text
%ASX_DIR%\Documentation\hdf\data
```

HSVX 官方示例数据位于对应 `Documentation\hsvx` 文档目录或官方示例部署位置。也可以使用自己的 HDF/HSVX，但应先备份，写入示例默认要求新输出路径。


