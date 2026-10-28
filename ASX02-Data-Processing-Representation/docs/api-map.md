# ASX 02 服务与 API 地图

## ArtemiS SUITE Application

| 服务 | 获取方法 | 用途 |
| --- | --- | --- |
| Info | `GetInfoService()` | 应用和版本信息 |
| Automation Project | `GetAutomationProjectService()` | 打开、修改和计算 Automation Project |
| Data Viewer | `GetDataViewerService()` | Data Viewer 交互 |
| Pool Project | `GetPoolProjectService()` | Source Pool、Mark 和计算 |
| Reporting | `GetReportingService()` | Report 创建、数据交换和导出 |
| Standardized Test | `GetStandardizedTestProjectService()` | 标准化测试项目 |
| Recent Recordings | `GetRecentRecordingsService()` | 最近录音 |
| Processing | `GetProcessingService()` | 启动处理 |
| Main Window | `GetMainWindowService()` | 窗口位置和尺寸 |
| Documents | `GetDocumentsService()` | 文档管理 |
| Document Export | `GetDocumentExportService()` | 文档导出 |
| Events | `GetEventsService()` | 应用事件 |
| Mark Analyzer | `GetMarkAnalyzerService()` | Mark 分析交互 |

Recorder 服务属于 ASX 04，只有录音需求时不必额外签出 ASX 02。

## Calculator

Calculator 主要提供：

- `GetInfoService()`；
- `GetProcessingService()`；
- `Start` 或 `StartWithoutWindow`；
- `StartJob(...)`；
- Job 进度、等待、摘要和结果文件。

## 安装依赖

核心程序集为 `HEADacoustics.API.Remote.dll`。官方 ASX 18.1 .NET Framework 工程还要求 NuGet 依赖：

- `System.Runtime.CompilerServices.Unsafe >= 6.0.0`；
- `System.Buffers >= 4.5.1`；
- `System.Memory >= 4.5.5`；
- `System.Numerics.Vectors >= 4.5.0`。
