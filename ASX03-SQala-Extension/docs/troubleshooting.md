# ASX 03 排错

| 症状 | 检查 |
| --- | --- |
| Step 不出现在列表 | DLL 部署目录、ASX 03 许可、Export attribute、目标框架 |
| 无声音属性页 | `FactorySettings.SetUsesSounds(true)` |
| 无法离开 Step | 完成逻辑没有设置 `navigation.FinishEnabled=true` |
| XAML 加载失败 | namespace、assembly 名和 code-behind 不一致 |
| 旧项目无法加载 | Factory 类型名或 Export ID 被修改 |
| 配置修改不触发验证 | Config Editor 未触发 `ConfigChanged` |

调试时将 Visual Studio 附加到 ArtemiS SUITE 进程，并保留与宿主一致的架构和框架。
