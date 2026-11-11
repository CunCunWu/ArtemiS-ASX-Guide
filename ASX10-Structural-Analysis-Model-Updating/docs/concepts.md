# ASX 10 核心概念

## MAC

Modal Assurance Criterion（MAC）用于量化两个振型向量的相关程度。结果位于 0 到 1 之间：接近 1 表示振型高度相似，接近 0 表示相关性低。MAC 只描述振型相关性，不单独证明有限元模型已经正确，也不能代替频率偏差、阻尼、测点质量和边界条件检查。

示例中的 `0.7` 仅用于演示 `MacMatrix.GetValues(threshold)`。实际项目应根据模型、测点密度、噪声和验收规范确定阈值。

## MeasurementPoints

`MeasurementPoints` 描述用于振型映射的几何点。每个 `MeasurementPoint` 包含：

- `Id`；
- `X`、`Y`、`Z` 坐标；
- `LocalCoordinateSystem`。

读取第三方仿真振型时，几何点 ID、坐标系和长度单位必须与振型数据对应。错误的点映射可能产生可计算但没有工程意义的 MAC 结果。

## ShapeTable 与 Shape

`ShapeTable` 包含 `Points` 和 `Shapes`。单个 `Shape` 提供频率 `Frequency`、衰减 `Attenuation` 和模态相位共线性指标 `Mpc` 等信息。

HEAD acoustics 原生振型表使用 `.hstx`。第三方格式通常需要先通过 `MeasurementPointsReader` 读取几何，再把得到的 `MeasurementPoints` 传给对应的 `ShapeTableReader.Read*` 方法。

## MacMatrix

`MacCalculator.CalculateMacMatrix(shapeTableA, shapeTableB)` 计算两张振型表中所有振型组合的 MAC 值。结果 `MacMatrix` 提供：

- `Values`：完整矩阵值；
- `GetValue(shapeA, shapeB)`：查询指定振型对；
- `GetValues(threshold)`：取得达到阈值的 `MacValue` 集合；
- `ShapeTableA` 和 `ShapeTableB`：保留参与计算的两张振型表。

## 异步 Job 与错误模型

读取和计算操作返回 `Job<T>`：

- C# 使用 `AsTask()` 并 `await`；
- Python 和 MATLAB 使用 `Wait()`。

`Try*` 方法返回带 `ErrorCode` 的 `ActionResult`；非 `Try*` 方法失败时抛出异常。批处理程序需要选择一种错误模型并统一记录输入文件、阶段和错误代码。
