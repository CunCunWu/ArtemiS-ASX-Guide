# MATLAB

来源：`official-adapted`。

```matlab
calculate_mac_matrix('TorqueSupport.pch', ...
    'TorqueSupport.bdf', 'Measurement.hstx', 0.7)
```

第五个参数可传入自定义 ASX 安装目录。示例按米解释 Nastran 几何；如果源模型使用其他长度单位，请把函数中的 `LengthUnit.METER` 改为对应枚举值。
