# HDF-ASX-Guide

面向开发者和编码智能体的 HEAD System Integration and Extension（ASX）使用指南与可运行示例库。

本仓库按 ASX 功能模块组织。安装、许可证、运行库加载和版本兼容等公共内容只维护一份；每个 ASX 模块在独立目录中说明自己的职责、数据模型、典型工作流和多语言示例。

## 当前内容

| 模块 | 状态 | 内容 |
| --- | --- | --- |
| [ASX 01 Data Access API](ASX01-Data-Access/) | 已建立 | HDF/HSVX 数据访问 |
| [ASX 02 Data Processing and Representation API](ASX02-Data-Processing-Representation/) | 已建立 | 远程控制 ArtemiS SUITE 与 Calculator |
| [ASX 03 SQala Extension API](ASX03-SQala-Extension/) | 已建立 | 自定义 SQala Step 类型 |
| [ASX 04 Data Acquisition API](ASX04-Data-Acquisition/) | 已建立 | 远程控制 ArtemiS SUITE Recorder |
| [ASX 05 Documentation and Metadata API](ASX05-Documentation-Metadata/) | 已建立 | User Documentation、UDI、HATX 模板 |
| [ASX 06 Data Processing Add-In API](ASX06-Processing-Add-In/) | 已建立 | Filter、Analysis、Post-Analysis、Export Add-In |
| [ASX 07 Local Processing Service](ASX07-Local-Processing-Service/) | 已建立 | ArtemiSproc 命令行批处理服务 |
| [ASX 08 Local Recording Service](ASX08-Local-Recording-Service/) | 已建立 | 独立 ArtemiSrec 录音服务 |
| [ASX 09 Reporting API](ASX09-Reporting/) | 已建立 | 读取、修改、保存和导出 Report |

## 开始使用

1. 阅读 [统一安装与环境配置](INSTALLATION.md)。
2. 进入目标模块目录，例如 [ASX 01](ASX01-Data-Access/README.md)。
3. 先阅读模块的功能边界和数据模型，再选择对应语言示例。
4. 使用本机合法 ASX 安装附带的 DLL、许可证和测试数据运行示例。

## 仓库原则

- 不提交 HEAD acoustics 的 DLL、许可证文件或受限二进制资源。
- 示例以 ASX 18.1 x64 为当前验证基线，其他版本应先核对 Programming Reference。
- 每个示例注明来源：`official-adapted` 表示依据随 ASX 安装的官方帮助示例重新整理，`community` 表示本仓库补充。
- 示例强调数据结构、资源释放和错误处理，不把 ASX 当作普通无类型 HDF5 文件处理。
- 文档既面向人类阅读，也为 Codex 等智能体提供明确的术语、接口选择规则和验证标准。

## 重要声明

本仓库是社区维护的学习资料，不是 HEAD acoustics 官方文档，也不替代随 ASX 安装的帮助和 Programming Reference。ASX、ArtemiS SUITE 及相关程序集的权利归其各自权利人所有。
