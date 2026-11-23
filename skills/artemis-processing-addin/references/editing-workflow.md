# Creation and editing workflow

## 1. Capture the contract

Record:

- Add-In type and host project type;
- implementation form: executable, MATLAB M-file, or MATLAB P-file;
- input shape and channel assumptions;
- expected output shape, axes, unit, quantity, `DataKind`, and extension;
- parameter names, defaults, valid ranges, and error behavior;
- supported ASX/ArtemiS version and CPU architecture;
- representative test input and an independently checkable expected result.

For an existing Add-In, save the current parameter string and known-good deployment layout before editing.

## 2. Inspect before changing

Trace these artifacts together:

1. Add-In property page or project configuration.
2. Command-line or MATLAB function parameters.
3. Argument validation and defaulting.
4. HDF read path and channel selection.
5. Algorithm and numerical assumptions.
6. HDF write path, metadata, and output finalization.
7. Exit-code mapping and logging.
8. Build output and runtime dependency layout.

Search for hard-coded paths, versioned assembly references, culture-sensitive parsing, full-array loading, UI calls, swallowed exceptions, and output creation that occurs before validation.

## 3. Implement safely

- Separate argument parsing, domain calculation, HDF I/O, and process entry point where practical.
- Reject missing inputs, invalid ranges, unsupported dimensions, and incompatible channel kinds before creating the final output.
- Write to the path supplied by ArtemiS SUITE. Do not silently redirect it.
- If atomic replacement is feasible, complete a temporary result and promote it only after validation.
- Keep numeric behavior deterministic and document any rounding, windowing, averaging, or resampling.
- For a pass-through Filter smoke test, start with a factor of `1` and compare data plus metadata.

## 4. Build and stage

- Match the target framework and architecture expected by the installed ASX version.
- Resolve API assemblies from the local licensed ASX installation; do not add vendor binaries to source control.
- Stage the executable, its application configuration, and required redistributable dependencies together.
- Keep the previous release recoverable. Use a versioned or separate staging directory for changed output.
- Document the exact executable/M-file path and parameter string used in ArtemiS SUITE.

## 5. Validate progressively

1. Test pure numerical logic with small deterministic data.
2. Run the executable or MATLAB function directly on exported sample HDF files.
3. Inspect result structure, metadata, units, axes, and representative values.
4. Invoke it from ArtemiS SUITE using a short known dataset.
5. Test invalid input, paths containing spaces and non-ASCII characters, multi-channel data, and the largest representative dataset.
6. Check the ArtemiS SUITE Event Viewer and confirm downstream sequence steps continue only on success.

## 6. Hand off

Deliver source changes, a reproducible build procedure, a deployment layout description, the ArtemiS parameter string, supported versions, test evidence, limitations, and rollback instructions. Clearly label tests that could not run because of missing licenses or runtimes.
