# ASX 10 常见问题与排错

| 症状 | 检查 |
| --- | --- |
| 许可证创建失败 | 加密狗或许可证容器是否包含 `ASX_10_StructuralAnalysisModelUpdatingAPI` |
| `BadImageFormatException` | 进程是否为 x64；非 SDK C# 项目是否设置 `Prefer32Bit=false`；程序集是否来自同一 ASX 版本 |
| DLL 能加载但依赖缺失 | 是否在完整 ASX 安装目录运行，是否同时引用 License 和 Shared 依赖 |
| Nastran 读取失败 | PCH/BDF 是否属于同一模型；路径、文件版本和长度单位是否正确 |
| HSTX 读取失败 | 是否使用 `ShapeTableReader.Read`，文件是否完整且与当前 ASX 版本兼容 |
| Job 返回后没有数据 | 是否对 Job 调用了 `Wait()` 或 `await ...AsTask()` |
| MAC 全部很低 | 检查点 ID、坐标系、方向、单位、模态顺序、边界条件和测量噪声，不要只调低阈值 |
| 阈值筛选为空 | 先检查 `MacMatrix.Values` 或降低阈值进行诊断；不要把空结果直接解释为 API 失败 |
| `Try*` 调用失败 | 读取 `ActionResult.ErrorCode`，并对照离线帮助的 Shared Error Codes |
| 代码在另一台机器失效 | 核对 ASX 版本、架构、许可证、文件路径和求解器文件格式 |

MAC 计算前最重要的检查是几何与振型映射。API 可以完成数值计算，但无法替代对测点、自由度和坐标系一致性的工程验证。
