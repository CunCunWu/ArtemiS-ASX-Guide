"""Create a new HSVX file containing one torque single value."""

import argparse
from pathlib import Path

from asx_runtime import asx01_session


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("output", type=Path)
    args = parser.parse_args()
    if args.output.exists():
        parser.error(f"refusing to overwrite existing output: {args.output}")

    args.output.parent.mkdir(parents=True, exist_ok=True)
    with asx01_session() as ASX01:
        quantity = ASX01.Quantity.Create(
            ASX01.QuantityIds.Torque, "Nm", ASX01.QuantityDomains.Signal
        )
        moniker = ASX01.SingleValueMoniker.PrependIndividualSingleValueMonikerPrefix(
            "Guide.Torque"
        )
        value = ASX01.SingleValue.Create("Torque", moniker, 42.4, quantity)
        channel = ASX01.HsvxSingleValueChannel.Create("Channel 1", value)
        source = ASX01.HsvxSingleValueSource.Create()
        result = source.TryAddChannel(channel)
        if not result.ActionIsOk:
            raise RuntimeError("the HSVX channel could not be added")
        ASX01.HsvxWriter.WriteToHsvxFile(source, str(args.output.resolve()))
        print(f"Created: {args.output.resolve()}")


if __name__ == "__main__":
    main()

