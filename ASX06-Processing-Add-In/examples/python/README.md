# Python executable Add-In

ASX 06 不直接把 `.py` 当作 Executable Add-In。`time_signal_factor.py` 展示处理入口，必须在匹配的 Python/pythonnet 环境中测试，再用 PyInstaller 等工具封装为 EXE，并将运行时依赖与 EXE 一起部署。

配置参数仍为：

```text
/In="$InputFile" /Out="$OutputFile" /factor=1.0
```

这是社区模式，不是 ASX 18.1 官方 Python Add-In 示例。
