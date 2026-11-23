---
name: artemis-model-updating
description: Read modal geometry and shape tables and calculate MAC correlations with ASX 10.
---

# ASX 10

- Two HSTX files can be read directly. For third-party results, read matching geometry first, specify the length unit, and check point IDs, directions, coordinate systems, and degrees of freedom before calculating MAC.
- Wait for reader and calculation jobs. Record row and column model identities, mode IDs, frequencies, and any configurable threshold when exporting results.
- Check an expected matching pair and investigate low MAC alongside frequency differences and mapping. This module exposes correlation; solver optimization and FE parameter updates are separate tasks.

## Sources

Use the guide module `ASX10-Structural-Analysis-Model-Updating/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/ArtemiS-ASX-Guide) first.
