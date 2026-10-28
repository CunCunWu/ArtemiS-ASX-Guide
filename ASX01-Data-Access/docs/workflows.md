# ASX 01 典型工作流

## 只检查文件

1. 获取 ASX 01 License。
2. 调用 `HdfInfo.Create(path)`。
3. 输出 `HdfType`、`DataType` 和 `FileInfo`。
4. 不加载通道数据。

适用于目录扫描、类型分流和批处理预检。

## 读取 2D 曲线

1. `Reader.Read2D(path)`。
2. 根据 `DataType` 读取 RealChannels 或 ComplexChannels。
3. 读取 ChannelInfo、Abscissa、Ordinate。
4. 获取实数数据，或实部与虚部。
5. 在计算前确认数据是线性值还是已经是对数结果。

## 分块处理 Time Data

1. 打开 `StreamReader`。
2. 获取 sampled channels。
3. 为输出创建 `StreamWriter` 和所有通道。
4. `EndSetup()`。
5. 以固定块大小循环：读取、处理、AppendData。
6. `Close()` 并重新读取输出验证。

块大小影响性能，但不应改变计算结果。带状态算法需要保留跨块状态。

## 读取 3D Map

1. 识别 Real/Complex。
2. 打开相应 3D Reader。
3. 检查 FirstAbscissa、SecondAbscissa 和 Ordinate。
4. 使用 `GetVectors(start,count)` 分批读取。
5. 明确每个向量对应第一横轴的哪个位置。

## 创建 HSVX 单值

1. 使用已知 `QuantityIds` 和 `QuantityDomains` 创建 Quantity。
2. 创建合法 moniker。
3. 创建 `SingleValue`，可选添加 limits。
4. 创建 `HsvxSingleValueChannel`。
5. 加入 `HsvxSingleValueSource`。
6. 写入 HSVX 并重新读取验证。

## 输出验收

- 输出文件可重新打开；
- HdfType/DataType 与预期一致；
- 通道数量、名称、轴和单位正确；
- 数值与独立计算结果一致；
- DataKind 与下游用途匹配；
- Reader/Writer/License 已释放。

