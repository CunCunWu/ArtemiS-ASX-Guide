# Add-In type decision

Choose the type from the intended data transformation, not from the implementation language.

| Type | Input | Required output | Critical invariant |
| --- | --- | --- | --- |
| Filter | HDF time signal | HDF time signal | Result channel `DataKind` is `Recording` |
| Analysis | HDF time signal | HDF analysis data | Result `DataKind` is not `Recording`; axes and quantity describe the analysis |
| Post-Analysis | HDF analysis data | HDF analysis data | Preserve or intentionally redefine the analysis axes, unit, quantity, and `DataKind` |
| Export | Recording, 2D, or 3D HDF | User-defined file format | Validate the requested extension and output completeness |
| Export-Merge | Text file listing one HDF path per line | One user-defined export file | Use `$InputListFile`, preserve deterministic input ordering |

Filter, Analysis, and Post-Analysis Add-Ins can be used in Automation, Metric, Pool, or Standardized Test workflows subject to the host project's available pools. Export Add-Ins produce external formats and have single-input and merge variants.

When a requested algorithm changes time data into a spectrum or scalar level, use Analysis rather than Filter. When it modifies an existing analysis result, use Post-Analysis. Do not force a transform into the wrong type merely to reuse an existing template.
