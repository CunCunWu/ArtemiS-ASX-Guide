# Python

来源：`official-adapted`。示例通过 `pythonnet` 调用 ASX .NET API。

```powershell
python -m pip install pythonnet
python calculate_mac_matrix.py TorqueSupport.pch TorqueSupport.bdf Measurement.hstx --threshold 0.7
```

脚本默认从环境变量 `ASX_DIR` 读取安装目录；未设置时使用标准安装路径。Nastran 几何按米读取，如源模型使用其他单位，应在脚本中改为对应的 `LengthUnit`。
