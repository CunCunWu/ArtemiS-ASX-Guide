# ASX 06 runtime contract

## Executable Add-Ins

ArtemiS SUITE starts the executable as a separate process and waits for it to terminate. The default parameter form is:

```text
/In="$InputFile" /Out="$OutputFile"
```

Additional values are space-separated, for example:

```text
/Factor=1.25 /In="$InputFile" /Out="$OutputFile"
```

`$InputFile` and `$OutputFile` expand to absolute paths in a temporary directory. Always retain the quotes because paths can contain spaces. Export-Merge uses `$InputListFile` instead of `$InputFile`.

Exit code `0` means success. Any nonzero exit code stops further processing and is logged in the ArtemiS SUITE Event Viewer. Define stable codes for argument errors, input/data errors, output/write errors, license failures, and unexpected failures; document them with the Add-In.

The documented default timeout is 1800 seconds and can be configured with `AddIn.TimeoutSeconds` in `ArtemiSProc.exe.config`. Treat timeout changes as deployment configuration, not as a substitute for diagnosing hangs or excessive memory use.

## MATLAB M/P-file Add-Ins

M/P files run through a hidden MATLAB Command Window. ArtemiS SUITE keeps one MATLAB process alive, so execution is serial and edited M-files can remain cached. Terminate the hidden MATLAB process before retesting changed code.

M-file parameters are comma-separated; executable parameters are space-separated. Develop and test with exported sample HDF files directly in MATLAB before host integration.

Do not print routine output to the MATLAB Command Window. ArtemiS SUITE interprets command-window output as an error, records it in the Event Viewer, and stops processing.

## Numeric and file behavior

- Additional floating-point parameters use a language-neutral decimal point (`.`).
- Do not assume the temp directory, installation directory, or user profile contains only ASCII characters.
- Validate that an output exists and has the correct structure; a zero-byte or merely created file is not success.
- Close and dispose file handles before process exit so ArtemiS SUITE can consume or move the result.
- Put parameter descriptions in M-file comments or executable assembly information, including units and allowed values.
