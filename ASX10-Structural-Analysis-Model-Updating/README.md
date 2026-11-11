# ASX 10 Structural Analysis - Model Updating API

ASX 10 用于读取测量点和振型数据，并计算两组振型之间的 Modal Assurance Criterion（MAC）矩阵。它适合将试验模态结果与有限元仿真结果进行相关性比较，不要求安装 ArtemiS SUITE，但运行时必须具有 ASX 10 许可证。

## 主要能力

- 读取 HEAD acoustics 测量点库（`.hmpl`）和振型表（`.hstx`）；
- 从 Abaqus、Altair、Ansys、Nastran、PERMAS 和 Universal File 等第三方格式导入几何信息；
- 从 Abaqus、Ansys、Nastran、PERMAS 和 Universal File 导入振型；
- 使用 `MacCalculator` 计算两张 `ShapeTable` 的完整 MAC 矩阵；
- 按阈值筛选匹配振型，或查询指定振型对的 MAC 值；
- 使用 `Try*` 方法取得 `ActionResult.ErrorCode`，或使用非 `Try*` 方法让错误以异常形式报告。

## 功能边界

ASX 10 的公开接口重点是数据导入与 MAC 计算。名称中的 Model Updating 不表示 API 会自动修改有限元模型参数、回写求解器模型或执行优化迭代；这些上层步骤需要调用方根据 MAC 结果自行组织。

## 导航

- [核心概念](docs/concepts.md)
- [API 地图](docs/api-map.md)
- [典型工作流](docs/workflows.md)
- [常见问题与排错](docs/troubleshooting.md)
- [官方示例索引](docs/official-example-index.md)
- [C#、Python 和 MATLAB 示例](examples/README.md)
