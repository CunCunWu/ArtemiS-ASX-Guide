# Repository instructions for coding agents

## Purpose

This repository documents HEAD acoustics ASX APIs for both humans and coding agents. Prefer precise capability boundaries, executable examples, and version-qualified statements over broad summaries.

## Navigation

1. Read `/README.md` and `/INSTALLATION.md` once for shared setup.
2. Read the target module's `README.md`.
3. Read `docs/api-map.md` before choosing a Reader or Writer.
4. Use the language README before editing or running examples.

## Source-of-truth order

1. Programming Reference installed with the user's ASX version.
2. Official examples installed under `ASX\Documentation`.
3. This repository's version-qualified explanation and examples.
4. Inference from assembly reflection, clearly marked as inference.

## Safety and licensing

- Never commit vendor DLLs, license containers, dongle data, or proprietary binaries.
- Do not claim that copying DLLs replaces ASX installation.
- Do not silently mix assemblies from different ASX versions.
- Do not treat HEAD HDF files as generic HDF5 unless official documentation explicitly supports that operation.
- Preserve metadata when transforming data: file info, channel info, abscissa, ordinate, quantity, unit, weighting, and DataKind.

## Example conventions

- Every example must release License, Reader, and Writer resources.
- Large Time Data and 3D files must be processed in blocks.
- CLI examples accept paths as arguments; avoid hard-coded user paths.
- Mark example provenance in the language README.
- Test syntax without a license where possible; runtime HDF verification requires ASX 01 and sample data.

