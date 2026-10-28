# ASX 06 参数与生命周期

## EXE 默认参数

```text
/In="$InputFile" /Out="$OutputFile"
```

扩展参数建议：`/Name=Value`，路径占位符必须加引号。

## M-file 默认参数

```text
$InputFile,$OutputFile
```

M-file 参数以逗号分隔；EXE 参数以空格分隔。

## 配置项

`ArtemiSProc.exe.config`：

- `AddIn.TimeoutSeconds`：默认 1800；
- `AddIn.WindowStyle`：Normal/Hidden/Minimized/Maximized。

## 成功条件

输出存在、结构与 Add-In 类型相符、程序退出码为 0。仅创建空输出文件不算成功。
