---
name: artemis-suite-automation
description: Control ArtemiS SUITE projects, documents, or the Calculator through the Remote API.
---

# ASX 02

- Choose the target application first. Use the SUITE service for interactive project operations and Calculator for API-managed processing jobs. Use ASX 07 for direct `ArtemiSproc.exe` command-line automation.
- Confirm application availability before obtaining its service. Wait for project operations and processing jobs before accessing results or changing sources. For Calculator, check ASX 07 and analysis licenses as well as ASX 02.
- Verify job completion and the expected result files. Distinguish source replacement in a live report from offline HRPX processing (ASX 09).

## Sources

Use the guide module `ASX02-Data-Processing-Representation/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/HDF-ASX-Guide) first.
