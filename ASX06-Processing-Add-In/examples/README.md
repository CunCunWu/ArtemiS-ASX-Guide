# ASX 06 examples

- `csharp/TimeSignalFactor.cs`：完整 Filter EXE 核心示例；
- `python/time_signal_factor.py`：社区版处理脚本，需用 PyInstaller 等封装成 EXE 后配置；
- `matlab/README.md`：官方 M-file 示例位置和运行约束。

生产实现应对大文件使用 StreamWriter 分块写入；为保持示例紧凑，倍率示例一次创建结果通道。
