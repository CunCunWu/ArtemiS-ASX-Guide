# 统一安装与环境配置

本文件适用于仓库中的所有 ASX 模块。各模块只补充自己特有的依赖。

## 1. 必须先安装 ASX

ASX API 不是可从本仓库独立安装的普通软件包。使用任何示例前，必须先在 Windows 上安装合法、完整且版本匹配的 HEAD System Integration and Extension（ASX）。

默认安装目录通常为：

```text
C:\Program Files\HEAD System Integration and Extension (ASX)
```

该目录包含 API 程序集和离线帮助。不要从其他计算机或未知来源拼接 DLL；单独复制 DLL 不能替代 ASX 安装。

当前文档和示例以以下环境为基线：

- Windows x64；
- ASX 18.1 x64；
- .NET Framework 4.8；
- 相应模块的有效许可证。

## 2. 许可证

安装 ASX 不等于拥有全部模块许可证。运行前应确认加密狗或许可证容器包含目标模块，例如 ASX 01 使用：

```csharp
ProductCode.ASX_01_DataAccessAPI
```

典型许可证错误 `ContainerNotFound` 表示程序已经进入许可证检查，但没有找到可用容器或对应授权。

### ASX 01–09 对照

| 模块 | 正式名称 | 主要入口/程序 | 许可证行为 |
| --- | --- | --- | --- |
| ASX 01 | Data Access API | `HEADacoustics.API.Hdf.dll` | 调用方签出 ASX 01 |
| ASX 02 | Data Processing and Representation API | `HEADacoustics.API.Remote.dll` | 调用方签出 ASX 02 |
| ASX 03 | SQala Extension API | `HEADacoustics.API.SQala.dll` | 在 SQala/ArtemiS SUITE 中使用 ASX 03 |
| ASX 04 | Data Acquisition API | Remote Recorder | 调用方签出 ASX 04 |
| ASX 05 | Documentation and Metadata API | `HEADacoustics.API.Documentation.dll` | 调用方签出 ASX 05 |
| ASX 06 | Data Processing Add-In API | ArtemiS SUITE Add-In | 项目环境需要 ASX 06；HDF 直接读写通常还需 ASX 01 |
| ASX 07 | Local Processing Service | `ArtemiSproc.exe` | 服务启动时自动检查 ASX 07；具体分析还需相应分析许可 |
| ASX 08 | Local Recording Service | `ArtemiSrec.exe` | 服务启动时自动检查 ASX 08；远程控制还需 ASX 04 |
| ASX 09 | Reporting API | `HEADacoustics.API.Reporting.dll` | 调用方签出 ASX 09 |

ASX 03 和 ASX 06 在当前 `ProductCode` 公共字段中没有像 ASX 01/02/04/05/09 那样的手动签出入口，应遵循各自宿主和项目的许可流程。

## 3. C# 环境

推荐：

- Visual Studio 2022 或 MSBuild；
- .NET Framework 4.8 Developer Pack；
- 项目平台 `x64`。

示例项目通过 `ASX_DIR` MSBuild 属性引用本机程序集，默认值为 ASX 默认安装目录：

```powershell
msbuild .\Asx01Examples.csproj /p:Configuration=Release /p:Platform=x64
```

自定义安装位置：

```powershell
msbuild .\Asx01Examples.csproj /p:Configuration=Release /p:Platform=x64 /p:ASX_DIR="D:\ASX"
```

运行 EXE 时，Windows 必须能定位 ASX 及其依赖。最稳妥的方式是在已安装 ASX 的机器上运行，并保持进程架构一致。

## 4. Python 环境

ASX 18.1 的 Python 示例通过 `pythonnet` 加载 .NET Framework 程序集，并不是纯 Python HDF5 解析。

建议：

- 64 位 CPython；
- 与 ASX 18.1 和 pythonnet 兼容的 Python 版本；
- `pythonnet`；
- 部分数值示例使用 `numpy`。

安装社区依赖：

```powershell
python -m pip install -r requirements.txt
```

如 ASX 不在默认目录，设置：

```powershell
$env:ASX_DIR = 'D:\ASX'
```

脚本应先将 ASX 目录加入 `sys.path`，再使用 `clr.AddReference(...)` 加载程序集。

## 5. MATLAB 环境

MATLAB 示例通过 MATLAB 的 .NET 接口加载 ASX 程序集：

```matlab
NET.addAssembly(fullfile(asxDir, 'HEADacoustics.API.Hdf.dll'));
NET.addAssembly(fullfile(asxDir, 'HEADacoustics.API.License.dll'));
```

MATLAB、ASX 和操作系统必须使用兼容架构，当前示例按 x64 编写。若 `NET.addAssembly` 失败，先检查安装路径、程序集版本和 MATLAB 使用的 .NET 运行环境。

## 6. 离线帮助

安装 ASX 后，离线帮助通常位于：

```text
C:\Program Files\HEAD System Integration and Extension (ASX)\Documentation
```

重点入口：

- `index.html`：帮助首页；
- `hdf/integration.html`：HDF Library；
- `hsvx/integration.html`：HSVX Library；
- `api/HEADacoustics.API.Hdf.html`：Programming Reference。

接口签名和版本差异以当前机器所安装版本的 Programming Reference 为准。

## 7. 安装检查清单

- ASX 安装目录存在；
- `HEADacoustics.API.Hdf.dll` 和 `HEADacoustics.API.License.dll` 存在；
- 程序、Python/MATLAB 和 ASX 均为 x64；
- 许可证容器可见并包含目标模块；
- 离线帮助可打开；
- 示例输入文件存在；
- 输出目录可写。
