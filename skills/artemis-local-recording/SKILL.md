---
name: artemis-local-recording
description: Start and control the standalone ArtemiSrec recording host.
---

# ASX 08

- Check standalone host availability and ASX 08 service licensing. The Remote client signs out ASX 04 and obtains the Recorder service from the standalone application.
- Confirm frontend configuration and explicit output paths before starting. Handle the armed, recording, completed, and failed states separately with bounded waits.
- On a test recording, confirm output integrity and stop behavior. If the host or frontend disconnects, inspect recorder state before retrying so a retry does not start duplicate acquisition.

## Sources

Use the guide module `ASX08-Local-Recording-Service/` for its README, workflows, and language examples. Check signatures against the installed Programming Reference. For environment setup, use the guide's `INSTALLATION.md`. If the skill is installed separately, locate the [ASX guide](https://github.com/CunCunWu/ArtemiS-ASX-Guide) first.
