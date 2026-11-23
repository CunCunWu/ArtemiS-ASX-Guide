---
name: artemis-metadata
description: Read or write ArtemiS User Documentation, legacy UDI, or HATX templates.
---

# ASX 05

- Identify external versus embedded documentation and the precise write target. Locate the typed form/field before updating it and check the writer result.
- For legacy UDI, read it via `LegacyUdiReader` and convert with `ToUserDocumentation` before editing. For HATX edits, clone the template and save to a new path by default.
- Reopen the output and compare field values, types, and untouched forms. Use ASX 01 for signal data rather than documentation edits.

## Sources

Use the guide module `ASX05-Documentation-Metadata/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/HDF-ASX-Guide) first.
