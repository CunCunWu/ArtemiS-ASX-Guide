---
name: artemis-sqala-extension
description: Develop, modify, or troubleshoot custom SQala Step extensions.
---

# ASX 03

- Start with `IStepFactory` exported via `ExportStepFactory`, an `IStep`, and its WPF view. Add configuration, preview, navigation, or result conversion interfaces only as the step requires.
- Build the class library with the target SUITE-compatible framework and dependencies. Stage before deploying to `Extensions.API.SQala`.
- In a minimal SQala project, verify discovery in Add Step, execution, cancellation/navigation as applicable, and any exported result. Record build and host validation separately.

## Sources

Use the guide module `ASX03-SQala-Extension/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/HDF-ASX-Guide) first.
