# MATLAB SHDF 数据交换

ASX 01 与 MATLAB 有两条不同使用路径，必须区分。

## 路径一：MATLAB 直接调用 ASX .NET API

MATLAB 通过 `NET.addAssembly` 加载 `HEADacoustics.API.Hdf.dll` 和 License API，然后直接使用 `Reader`、`StreamReader`、`Real3DReader` 等对象。

特点：

- 直接访问 HDF/HSVX；
- 需要 ASX 安装和 ASX 01 许可证；
- 与 C#、Python 使用同一 API；
- 适合自动化数据处理和写回 HDF。

本仓库 `examples/matlab` 使用这条路径。

## 路径二：ArtemiS SUITE MATLAB Import/Export 的 SHDF

ArtemiS SUITE 可把数据导出为包含 `shdf` 变量的 MAT 文件，并从符合结构规范的 MAT 文件导入。

特点：

- MATLAB 侧主要操作结构体；
- `shdf` 中包含数据集、通道、横轴、脉冲通道和 tags；
- 字段维度和 `nNbr...` 数量字段必须一致；
- 官方帮助建议先导出同类型结果作为模板，再修改必要字段；
- 为保持兼容，官方 ASX 18.1 帮助要求保存为 MATLAB V6 格式：

  ```matlab
  save('name.mat', 'shdf', '-v6')
  ```

SHDF 适合 ArtemiS SUITE 的 MATLAB 文件交换，但不是通用 HDF Reader 的替代品。

## 选择建议

| 需求 | 推荐路径 |
| --- | --- |
| MATLAB 中直接读取/写入 HDF | .NET ASX 01 API |
| 与 C#/Python 共用同一数据访问逻辑 | .NET ASX 01 API |
| 通过 ArtemiS SUITE 的 MATLAB Import/Export 交换 | SHDF |
| 不熟悉完整 SHDF 字段结构 | 先导出模板，再修改 |

## 关键风险

- 不要把 `.mat` 中的 `shdf` 结构误认为 HDF 文件本身；
- 不要忽略维度计数字段；
- 不要更改单位而不换算数值；
- 不要用现代 MAT 格式替代官方要求的 V6 格式后仍假设可导入；
- 精确字段定义以 `Documentation\shdf\shdfDocumentation.html` 为准。

