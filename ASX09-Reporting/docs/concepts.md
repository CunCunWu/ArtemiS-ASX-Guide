# ASX 09 核心概念

Report 对象持有可能较大的资源，使用完必须 `Dispose`。

Reporting API 的许多操作返回 Job：

- C#：`AsTask()` / await；
- Python/MATLAB：`Wait()`；
- 可注册 Progress 回调。

`Try*` 方法返回带 `ErrorCode` 的 ActionResult；非 Try 版本失败时抛异常。

Quantity/Unit modifications 必须在读取任何 Report 之前应用，否则可能不生效或产生不一致。
