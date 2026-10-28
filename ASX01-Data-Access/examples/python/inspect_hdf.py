"""Identify an HDF and select the reader that matches its structure."""

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
        info = ASX01.HdfInfo.Create(str(args.input.resolve()))
        print(f"Path: {info.Path}")
        print(f"HDF type: {info.HdfType}")
        print(f"Data type: {info.DataType}")
        print(f"Title: {info.FileInfo.Title}")

        hdf_type = str(info.HdfType)
        data_type = str(info.DataType)
        if hdf_type == "TimeData":
            reader = ASX01.StreamReader.Create(info.Path)
            try:
                print(f"Sampled channels: {len(reader.GetSampledChannels())}")
            finally:
                reader.Dispose()
        elif hdf_type == "AnalysisData2D":
            result = ASX01.Reader.Read2D(info.Path)
            channels = result.RealChannels if data_type == "Real" else result.ComplexChannels
            print(f"2D channels: {len(channels)}")
        elif hdf_type == "AnalysisData3D":
            reader_type = ASX01.Real3DReader if data_type == "Real" else ASX01.Complex3DReader
            reader = reader_type.Create(info.Path)
            try:
                print(f"3D channels: {len(reader.GetChannels())}")
            finally:
                reader.Dispose()
        else:
            raise ValueError(f"Unsupported HDF type: {hdf_type}/{data_type}")


if __name__ == "__main__":
    main()

