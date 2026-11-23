---
name: artemis-reporting
description: Modify HRPX report sources or export PDF and PowerPoint using the offline Reporting API.
---

# ASX 09

- Use `ReportReader` and await completion before listing data source names. Use `Exchange` for replacement or `DuplicateWithBindings` when the new source needs the existing bindings.
- Write changed HRPX to a separate path and reopen it. For export, select the page range via `ExportSettings`, wait for completion, and inspect pages and resolved data. Dispose the report after jobs finish.
- For report operations through a running SUITE instance, use ASX 02 Reporting Service.

## Sources

Use the guide module `ASX09-Reporting/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/HDF-ASX-Guide) first.
