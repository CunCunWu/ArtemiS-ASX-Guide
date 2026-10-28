# ASX 03 SQala Extension API

ASX 03 用于为 ArtemiS SUITE 的 SQala Project 创建自定义 Step 类型。扩展可以实现测试逻辑、播放交互、导航、配置页面、验证、预览和结果导出。

## 技术边界

- 官方开发语言：C# / .NET Framework；
- UI：WPF 和 XAML；
- 输出：扩展 DLL；
- 部署：ArtemiS SUITE 安装目录的 `Extensions.API.SQala` 文件夹；
- 当前官方支持本地执行；
- Python 和 MATLAB 不能作为 SQala Step 的官方实现语言。

## 组成

- 必需：`IStepFactory`、`IStep`；
- 可选：配置、配置编辑器、验证、结果转换、预览等接口；
- 环境服务：Player、Navigation、InputService、Sound/Attribute references；
- UI 控件：SoundButton、AttributeControl、RatingButton、LabeledProperty、CheckableProperty。

## 阅读顺序

1. [核心概念](docs/concepts.md)
2. [接口地图](docs/api-map.md)
3. [开发与部署工作流](docs/workflows.md)
4. [排错](docs/troubleshooting.md)
5. [官方示例索引](docs/official-example-index.md)
6. [示例](examples/README.md)
