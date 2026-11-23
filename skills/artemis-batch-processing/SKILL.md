---
name: artemis-batch-processing
description: Run and troubleshoot unattended HPSX processing using ArtemiSproc.exe.
---

# ASX 07

- Export the `.hpsx` from a known Automation sequence. Smoke-test a single known input with an explicit `/target`; choose `/prod` for needed products and `/var` for variable overrides after checking installed help.
- Capture stdout, stderr, exit code, and job-specific output paths. Confirm expected result files even after exit 0 and prevent stale files from matching a new run.
- Bound concurrency around license, memory, and output constraints. For programmatic Remote API jobs instead of direct CLI invocations, see ASX 02 Calculator.

## Sources

Use the guide module `ASX07-Local-Processing-Service/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/HDF-ASX-Guide) first.
