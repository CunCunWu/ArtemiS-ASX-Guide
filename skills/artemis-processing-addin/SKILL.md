---
name: artemis-processing-addin
description: Create, modify, diagnose, validate, package, and document ArtemiS SUITE ASX 06 Processing Add-Ins implemented as executables or MATLAB M/P files. Use for Filter, Analysis, Post-Analysis, or Export Add-Ins and their HDF data contracts, parameters, deployment, and troubleshooting. Do not use for ordinary ArtemiS projects, recorder control, reports, or Excel export macros.
---

# ArtemiS Processing Add-In

Create or edit an ASX 06 Processing Add-In without breaking its ArtemiS SUITE data contract.

## Establish the baseline

1. Identify the installed ASX and ArtemiS SUITE versions and the target architecture.
2. Treat the installed Programming Reference and official examples as the authority. Use repository documentation as an explanation layer, not as a replacement.
3. Inspect the existing source, project files, configuration, deployment layout, Add-In property settings, sample input, expected output, and known-good release before editing.
4. Read the [ASX guide](https://github.com/CunCunWu/HDF-ASX-Guide)'s `INSTALLATION.md` and the relevant pages under `ASX06-Processing-Add-In/` before changing code. For a separately installed skill, use a local guide checkout or the linked repository.
5. Do not copy, download, commit, or redistribute vendor DLLs, license material, or customer measurement data. Reference assemblies from the user's licensed local installation.

## Route the task

- Read [addin-types.md](references/addin-types.md) before selecting or changing the Add-In type.
- Read [editing-workflow.md](references/editing-workflow.md) when creating or modifying an implementation.
- Read [runtime-contract.md](references/runtime-contract.md) when changing parameters, process behavior, MATLAB code, configuration, or packaging.
- Use [validation-checklist.md](references/validation-checklist.md) before declaring the work complete.

## Preserve the external contract

- An executable Add-In is a separate process launched by ArtemiS SUITE, not an in-process plug-in DLL.
- Keep input parsing backward compatible unless the user explicitly approves a contract change.
- Quote all file-path placeholders. Parse numeric parameters with culture-independent formatting.
- Return exit code `0` only after a structurally valid output has been written. Use stable, documented nonzero codes for failures.
- Do not show modal dialogs or require interactive input during processing.
- Use ASX 01 Data Access APIs when reading or writing HDF data. Do not treat an ArtemiS HDF file as an untyped generic HDF5 container.
- Preserve channel identity, metadata, units, axes, quantities, sampling information, and `DataKind` unless the algorithm intentionally transforms them.
- Process large signals in blocks where supported; dispose readers, writers, licenses, and streams deterministically.

## Editing discipline

1. State the existing behavior and the requested delta in one short contract.
2. Trace the full path: ArtemiS parameters -> argument parser -> algorithm -> HDF writer -> exit code -> deployment package.
3. Make the smallest coherent change. Preserve unrelated user changes and the known-good release.
4. Put experimental output in a new build or staging directory; do not overwrite a deployed package without explicit approval and a recovery path.
5. Validate the algorithm outside ArtemiS SUITE first, then validate the complete Add-In inside the intended project type.
6. Update the user-facing description and parameter documentation whenever behavior changes.

## Completion standard

Do not claim the Add-In is verified unless the evidence distinguishes all of the following:

- source-level or syntax checks;
- compilation and dependency loading;
- standalone processing on representative input;
- invocation by ArtemiS SUITE with the real parameter string;
- output data and metadata inspection;
- licensed end-to-end execution.

If licensing, test data, MATLAB, ArtemiS SUITE, or the correct ASX runtime is unavailable, report that boundary precisely and provide the remaining manual verification steps.
