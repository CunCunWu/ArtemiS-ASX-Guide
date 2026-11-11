# ASX 10 examples

三个语言示例均改编自 ASX 18.1 离线帮助中的 `Calculating Mac Matrices`：读取 Nastran 仿真几何与振型、读取测量 HSTX、计算 MAC 矩阵并输出达到阈值的振型对。

## 示例输入

可直接使用本机 ASX 安装附带的数据：

```text
%ASX_DIR%\Documentation\structural_analysis_model_updating\Data\TorqueSupport.pch
%ASX_DIR%\Documentation\structural_analysis_model_updating\Data\TorqueSupport.bdf
%ASX_DIR%\Documentation\structural_analysis_model_updating\Data\Measurement.hstx
```

仓库不包含厂商 DLL、许可证或示例数据。

## 输出

每行依次输出：

```text
MAC value    simulation frequency    measurement frequency
```

默认阈值为 `0.7`，仅用于演示，不能直接作为所有项目的验收标准。
