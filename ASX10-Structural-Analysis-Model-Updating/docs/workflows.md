# ASX 10 典型工作流

## Nastran 仿真与 HSTX 测量结果比较

1. 签出 ASX 10 许可证。
2. 使用 `MeasurementPointsReader.ReadNastran(pch, bdf, unit)` 读取仿真几何。
3. 使用 `ShapeTableReader.ReadNastran(pch, measurementPoints)` 读取仿真振型。
4. 使用 `ShapeTableReader.Read(measurement.hstx)` 读取测量振型。
5. 使用 `MacCalculator.CalculateMacMatrix` 计算完整矩阵。
6. 使用 `GetValues(threshold)` 筛选候选匹配，并同时查看两侧振型频率。
7. 记录输入文件、长度单位、阈值和 ASX 版本，供结果追溯。

## 比较两份 HEAD acoustics 振型表

分别使用 `ShapeTableReader.Read` 读取两份 `.hstx`，等待两个 Job 完成后计算 MAC 矩阵。这种工作流不需要单独读取几何文件，因为每张 HSTX 已包含 API 所需的 `ShapeTable` 数据。

## 导入其他求解器结果

先使用对应的 `MeasurementPointsReader.Read*` 方法建立几何，再调用同格式的 `ShapeTableReader.Read*`。不要把一个模型的几何对象与另一个模型的振型文件混用，除非已经验证点 ID、坐标系和自由度映射兼容。

## 批量相关性检查

- 对每个模型组合单独记录读取和计算阶段；
- 限制并发，避免大量模型同时占用内存；
- 将低 MAC 视为需要调查的信号，而不是自动判定模型失败；
- 除 MAC 外，同时输出频率差、振型编号和输入文件标识；
- 失败时保留 `ErrorCode` 或完整异常信息。
