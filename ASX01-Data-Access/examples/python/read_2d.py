"""Read the first real or complex channel from a 2D analysis HDF."""

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
        if str(info.HdfType) != "AnalysisData2D":
            raise ValueError(f"not a 2D analysis HDF: {info.HdfType}")

        result = ASX01.Reader.Read2D(path)
        if str(info.DataType) == "Real":
            channel = result.RealChannels[0]
            values = list(channel.GetRealData())
            print(f"Channel: {channel.ChannelInfo.Name}")
            print(f"Abscissa: {channel.Abscissa.Quantity.Name} [{channel.Abscissa.Quantity.Unit}]")
            print(f"Ordinate: {channel.Ordinate.Quantity.Name} [{channel.Ordinate.Quantity.Unit}]")
            print(f"Points: {len(values)}; range: {min(values)} .. {max(values)}")
        elif str(info.DataType) == "Complex":
            channel = result.ComplexChannels[0]
            real = list(channel.GetRealData())
            imaginary = list(channel.GetImagData())
            print(f"Channel: {channel.ChannelInfo.Name}")
            print(f"Complex points: {len(real)}")
            print(f"First value: {real[0]} + j{imaginary[0]}")
        else:
            raise ValueError(f"unsupported 2D data type: {info.DataType}")


if __name__ == "__main__":
    main()

