# ASX 03 开发与部署

1. 创建 .NET Framework Class Library。
2. 引用 `HEADacoustics.API.SQala.dll` 及 WPF 程序集。
3. 实现带 `ExportStepFactory` 的 `IStepFactory`。
4. 实现 `IStep` 和 WPF View。
5. 按需加入配置、验证、预览和结果转换接口。
6. 编译 DLL。
7. 将 DLL 及必要依赖部署到 ArtemiS SUITE 的 `Extensions.API.SQala`。
8. 重启 ArtemiS SUITE，在 SQala Add Step 中检查扩展。
9. 使用最小项目验证播放、导航、取消和结果。

部署到 Program Files 通常需要管理员权限。本仓库示例不会自动写入安装目录。
