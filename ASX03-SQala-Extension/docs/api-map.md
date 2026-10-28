# ASX 03 接口地图

| 能力 | 接口 |
| --- | --- |
| 扩展入口 | `IStepFactory`、`ExportStepFactoryAttribute` |
| Step 运行 | `IStep` |
| 用户配置 | `IStepConfig`、`IStepConfigFactory` |
| 配置 UI | `IStepConfigEditor`、`IStepConfigEditorFactory<T>` |
| 配置验证 | `IValidatable` |
| 结果导出 | `IResultConverter`、`IResultConverterFactory` |
| 设计器预览 | `IStepPreviewFactory` |
| 播放 | `IPlayer`、`IPlayerSettings`、`ISoundReference` |
| 导航 | `INavigation`、`DefaultNavigator` |
| 输入 | `IInputService` |
| 运行环境 | `IRuntimeEnvironment` |

最小扩展只需要 Factory、Step 和一个 WPF View；其余接口按功能增加。
