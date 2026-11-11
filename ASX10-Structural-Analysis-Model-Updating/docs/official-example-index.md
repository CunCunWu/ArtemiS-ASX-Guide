# ASX 10 官方示例索引

离线帮助页面：

```text
%ASX_DIR%\Documentation\api_structuralanalysismodelupdating\Examples\ExampleCalculatingMacMatrices.html
```

示例名称：`Calculating Mac Matrices`。页面同时提供 C#、MATLAB 和 Python 代码，演示：

- 从 Nastran PCH/BDF 读取测量点几何；
- 从 Nastran PCH 读取仿真振型；
- 从 HSTX 读取测量振型；
- 计算 MAC 矩阵；
- 使用 `GetValues(0.7)` 输出候选匹配及双方频率。

官方示例数据位于：

```text
%ASX_DIR%\Documentation\structural_analysis_model_updating\Data
```

ASX 18.1 安装包含：

- `Measurement.hstx`；
- `Simulation_TorqueSupport.hmpl`；
- `Simulation_TorqueSupport.hstx`；
- `TorqueSupport.bdf`；
- `TorqueSupport.pch`。

本仓库不复制这些厂商示例数据。运行仓库示例时，请从本机合法 ASX 安装中引用它们。
