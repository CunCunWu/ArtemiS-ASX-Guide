# ASX 06 工作流

1. 先确定 Add-In 类型和输出结构。
2. 用 ASX 01 在独立命令行中完成输入读取、算法和输出写入。
3. 实现参数检查和稳定退出码。
4. 将 EXE/config/依赖放在同一部署目录，或准备 M/P 文件。
5. 在 ArtemiS SUITE Add-In 属性中选择文件并填参数。
6. 用短的已知数据验证 Event Viewer、输出轴、单位和 DataKind。
7. 再进行批量和大文件测试。

推荐先用 `factor=1` 的 Filter 验证无损读写链路。
