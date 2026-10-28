# ASX 06 核心概念

- EXE Add-In 是独立进程，不是加载进 ArtemiS SUITE 的 DLL；
- M/P 文件在隐藏 MATLAB Command Window 中顺序执行；
- `$InputFile`、`$OutputFile` 是 SUITE 运行时替换的路径占位符；
- Export-Merge 使用 `$InputListFile`，文本每行一个 HDF；
- 浮点参数使用语言无关的 `.`；
- EXE 退出码 0 为成功，非零会停止后续处理并记录 Event Viewer；
- 默认超时 30 分钟，禁止等待用户点击的模态窗口。

MATLAB M-file 只有一个长期存在的 MATLAB 进程，修改 M-file 后可能需要终止隐藏进程才能重新加载。
