"""Read axes and the first vector from a real or complex 3D HDF."""

import argparse
from pathlib import Path

from asx_runtime import asx01_session


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("input", type=Path)
    args = parser.parse_args()
    if not args.input.is_file():
        parser.error(f"input file not found: {args.input}")

    with asx01_session() as ASX01:
        path = str(args.input.resolve())
        info = ASX01.HdfInfo.Create(path)
        if str(info.HdfType) != "AnalysisData3D":
            raise ValueError(f"not a 3D analysis HDF: {info.HdfType}")

        reader_type = ASX01.Real3DReader if str(info.DataType) == "Real" else ASX01.Complex3DReader
        reader = reader_type.Create(path)
        try:
            channel = reader.GetChannels()[0]
            vector = channel.GetVector(0)
            print(f"Channel: {channel.ChannelInfo.Name}")
            print(f"First abscissa: {channel.FirstAbscissa.Quantity.Name} [{channel.FirstAbscissa.Quantity.Unit}]")
            print(f"Second abscissa: {channel.SecondAbscissa.Quantity.Name} [{channel.SecondAbscissa.Quantity.Unit}]")
            if str(info.DataType) == "Real":
                print(f"First vector length: {len(vector)}")
            else:
                print(f"First complex vector length: {len(vector.Real)}")
        finally:
            reader.Dispose()


if __name__ == "__main__":
    main()

