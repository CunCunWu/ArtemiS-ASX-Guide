# ASX 01 排错

| 症状 | 常见原因 | 处理 |
| --- | --- | --- |
| `ContainerNotFound` | 没有许可证容器或 ASX 01 授权 | 检查加密狗、驱动和许可 |
| `clr.AddReference` 失败 | ASX_DIR 错误、依赖缺失或架构不一致 | 检查安装目录和 x64 环境 |
| `NET.addAssembly` 失败 | MATLAB .NET 环境或路径不匹配 | 检查 MATLAB/ASX 位数及完整 DLL 名 |
| `InvalidFileFormatException` | 文件损坏、不支持或 Reader 选错 | 先调用 `HdfInfo.Create` |
| 通道数组为空 | 数据类型或通道类别与预期不同 | 检查 HdfType/DataType，并选择正确 Get 方法 |
| 输出可打开但含义错误 | Quantity、Unit、Axis 或 DataKind 错误 | 对照输入和 Programming Reference |
| 内存过高 | 一次性读取全部 Time Data/3D 向量 | 改为分块读取 |
| 输出文件不完整 | 未调用 Close/Dispose 或异常退出 | 使用 using/try-finally |
| Python 数据处理很慢 | 逐元素跨 .NET/Python 边界转换 | 使用块处理和 NumPy 缓冲策略 |

## 日志至少包含

- ASX 版本和程序架构；
- 输入/输出绝对路径；
- HdfType/DataType；
- Reader/Writer 类型；
- 通道名和索引；
- offset/count 或 vector start/count；
- 原始异常类型和消息。

## 不应采用的修复

- 从互联网随机下载 DLL；
- 混用不同 ASX 版本的程序集；
- 为了“能打开”而随意填写 DataKind；
- 只改 Unit 字符串而不换算数据；
- 捕获所有异常后继续生成结果。

