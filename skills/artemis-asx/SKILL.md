---
name: artemis-asx
description: Select and combine ArtemiS ASX modules when the request spans modules or the correct API is unclear.
---

# ArtemiS ASX routing

Use the [module map](references/module-map.md) to classify the task by operation and target host. Read only the selected module skills. For mixed workflows, select a module per stage and make explicit which files, jobs, or process states connect the stages.

Use the [shared environment and validation guide](references/environment.md) to locate documentation and distinguish a code check from licensed execution. If installed outside the guide repository, locate the guide as described there. When sibling skills are unavailable, use the corresponding module README and workflow from the guide.

Example: record with ASX 04 (or ASX 08 + 04 for the standalone host), wait for recording completion, process through ASX 02 or 07 depending on the host, inspect the result via ASX 01, then export an existing report with ASX 09.
