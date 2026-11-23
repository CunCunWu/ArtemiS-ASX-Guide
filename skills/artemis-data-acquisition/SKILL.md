---
name: artemis-data-acquisition
description: Control frontends, triggers, and recordings through the ArtemiS SUITE Recorder Remote API.
---

# ASX 04

- Use the SUITE Recorder for this module. For the standalone host, combine ASX 08 with the ASX 04 Recorder client API.
- Choose the configuration, control, or trigger service based on the operation. Before applying settings, distinguish a partial update from loading a full configuration.
- With a start trigger, distinguish armed from actively recording. Bound waits, handle stop and cancellation, and verify the output path, HDF channels, and recorded duration on a test run.

## Sources

Use the guide module `ASX04-Data-Acquisition/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/HDF-ASX-Guide) first.
