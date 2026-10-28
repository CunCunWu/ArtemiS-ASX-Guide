# ASX 02 核心概念

## Remote descriptor 与运行实例

`ArtemiSuiteRemote.ForLatestApplication(...)` 或 `ASXRemote.ForLatestApplication(...)` 先选择兼容安装，再通过 `Application` 或 `Calculator` 属性访问目标。`IsAvailable` 表示相应可执行程序当前是否可用；必要时调用 `Start`。

也可以使用：

- `ForExecutable(path)`：指定 ArtemiS SUITE 或 ArtemiSproc；
- `ForAllCompatibleApplications(...)`：枚举兼容安装；
- `FriendlyName`：向用户显示版本选择。

## 同步与异步

多数 GUI 服务按顺序同步工作，但处理和导出等操作可能返回 Job。C# 使用 `await`/`AsTask`，Python 和 MATLAB 常使用 `Wait()`，进度可通过回调注册。

## 兼容性

官方保证当前 Remote Library 与当前及下一主版本的应用兼容；控制更旧版本不保证。不要把某个版本的 Remote DLL 与任意版本应用组合后假设完全兼容。

## 生命周期

- 获取 ASX 02 License；
- 选择安装并启动目标；
- 获取具体服务；
- 操作文档或提交 Job；
- 等待异步任务、检查结果；
- 释放 License。
