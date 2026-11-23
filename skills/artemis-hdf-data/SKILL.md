---
name: artemis-hdf-data
description: Inspect, read, transform, or write ArtemiS HDF and HSVX data.
---

# ASX 01

- Classify HDF with `HdfInfo` before choosing a reader. Use `StreamReader` for Time Data, `Reader.Read2D` for 2D curves, and the matching real or complex 3D reader for maps. Read HSVX with its dedicated reader.
- For long recordings or 3D maps, bound memory with blocks and retain algorithm state across block boundaries. Complete stream writer setup before appending.
- Reopen generated files and compare channel IDs, axes, units, quantities, `DataKind`, dimensions, and known sample values.

## Sources

Use the guide module `ASX01-Data-Access/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/ArtemiS-ASX-Guide) first.
