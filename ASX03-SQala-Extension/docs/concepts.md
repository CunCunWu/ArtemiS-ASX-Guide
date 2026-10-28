# ASX 03 核心概念

## Factory

`IStepFactory` 是扩展入口，使用 `ExportStepFactory` 导出。`FactorySettings` 定义名称、分类、是否使用声音及声音数量约束。工厂返回新的 `IStep`。

Factory 的完整名称通常是内部标识。重命名类可能破坏旧项目兼容性；需要兼容时应显式固定 Export ID。

## Step

`IStep` 承载运行时逻辑：

- `OnStarted`：取得 `IRuntimeEnvironment` 并初始化；
- `View`：返回 WPF UI；
- `OnFinished`：返回结果；
- `OnCanceled`：清理取消状态。

参与者只能通过框架导航栏离开 Step，完成后必须启用 Finish。

## RuntimeEnvironment

运行环境提供可用声音、Player、Navigation 和输入服务。扩展只能播放环境提供的声音。

## 配置和结果

配置保存在 SQala Project (`.hsp`) 中。可选接口允许自定义配置页、验证、预览和 Excel 结果转换。
