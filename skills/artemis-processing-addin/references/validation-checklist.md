# Validation checklist

Use the highest applicable level and report the achieved level explicitly.

## Static and build

- [ ] Source compiles or passes the relevant syntax check.
- [ ] Target framework, CPU architecture, and ASX assembly versions match the target machine.
- [ ] No vendor DLL, license file, secret, or customer data is added to source control.
- [ ] Release output contains the implementation and required configuration/dependencies.
- [ ] Parameter help and Add-In description match actual behavior.

## Standalone behavior

- [ ] Missing/invalid arguments return a documented nonzero exit code.
- [ ] Paths with spaces and non-ASCII characters work.
- [ ] Numeric parameters use invariant parsing and enforce ranges.
- [ ] Known input produces independently checkable values.
- [ ] Large data does not cause avoidable whole-file memory growth.
- [ ] Failures do not leave a result that can be mistaken for success.

## HDF contract

- [ ] Input channels and dimensions are validated.
- [ ] Channel names/IDs, metadata, units, quantities, axes, sampling information, and `DataKind` are preserved or intentionally transformed.
- [ ] Filter output is time data with `DataKind=Recording`.
- [ ] Analysis/Post-Analysis output is valid analysis data and not `Recording`.
- [ ] Export-Merge respects the order and contents of `$InputListFile`.
- [ ] All readers, writers, licenses, and streams are disposed.

## ArtemiS SUITE integration

- [ ] The exact executable/M-file and parameter string are recorded.
- [ ] A short known dataset succeeds from the intended project type.
- [ ] The output opens and can feed the next intended sequence step.
- [ ] Exit code `0` occurs only on complete success.
- [ ] Intentional failures stop the workflow and produce a useful Event Viewer entry.
- [ ] No modal UI or unattended prompt appears.
- [ ] Timeout behavior is understood and documented.
- [ ] MATLAB edits are tested after clearing the persistent MATLAB process.

## Delivery evidence

- [ ] Supported ASX/ArtemiS versions and architecture are stated.
- [ ] Build, staging, installation, parameter configuration, smoke test, and rollback steps are present.
- [ ] Automated, manual, licensed-runtime, and unexecuted tests are clearly distinguished.
