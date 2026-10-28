# ASX 07 概念与参数

## 必需参数

- `/job <instructions.hpsx>`：处理例程；
- `/src <source>`：文件、目录或通配符；可重复；
- `/srcr <source>`：递归搜索；可重复。

`/srcr` 不能用于包含 `Find Files in Directory` 过程的例程。

## 可选参数

- `/target <directory>`：覆盖 HPSX 目标目录；
- `/prod <codes>`：预签出分析许可，多个用 `;`，`*` 表示全部；
- `/var name=value`：覆盖 HPSX 变量，可重复；
- `/d`：Debug 日志；
- `/p`：结束后暂停；
- `/pe`：仅错误时暂停；
- `/st`：单线程，降低内存压力但也降低性能；
- `/lang`：文本输出语言。

参数名和值以空格分隔，包含空格的路径才需要引号。路径可为绝对或相对当前工作目录。
