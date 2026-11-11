# ASX 10 instructions for coding agents

## Read order

1. Read the repository-level `INSTALLATION.md`.
2. Read this module's `README.md` and `docs/api-map.md`.
3. Check the installed ASX Programming Reference before changing method signatures or supported formats.
4. Use the installed official MAC example as the behavioral baseline.

## Capability boundary

- ASX 10 imports measurement points and shape tables and calculates MAC values.
- Do not claim that it automatically updates FE model parameters or runs a solver optimization loop.
- Do not parse `.hmpl` or `.hstx` as generic archive or HDF formats.

## Correctness rules

- Sign out `ProductCode.ASX_10_StructuralAnalysisModelUpdatingAPI` and always dispose the license.
- Wait for every returned `Job` before using its result.
- For third-party shape formats, read or supply the matching `MeasurementPoints` first.
- State the geometry length unit explicitly.
- Treat point IDs, coordinate systems, directions and units as part of the correlation model.
- Keep the MAC threshold configurable and do not present `0.7` as a universal acceptance criterion.
