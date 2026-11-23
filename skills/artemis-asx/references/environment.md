# Shared environment and validation

Locate the ASX guide. In a clone, find the root containing `INSTALLATION.md` and the `ASX01-Data-Access/` through `ASX10-Structural-Analysis-Model-Updating/` module directories. If the skill was copied into another project, use the guide checkout or [GitHub source](https://github.com/CunCunWu/ArtemiS-ASX-Guide). Use the same guide revision as the installed skill where possible.

Read the guide's `INSTALLATION.md` for framework, architecture, license and assembly setup. The guide baseline is ASX 18.1 x64. Use the target machine's installed Programming Reference and official examples for exact signatures and version differences. Read the module README and only the API map, workflow or example needed for the task.

ASX execution needs a matching licensed local installation. Keep vendor binaries, license material, credentials and customer measurements out of distribution. Validate on known input and record which checks ran: static review, compilation, DLL loading, standalone processing, or licensed host/hardware execution. Identify missing prerequisites for any remaining checks.
