"""Read metadata and the first samples of the first sampled channel."""

import argparse
from pathlib import Path

from asx_runtime import asx01_session


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("input", type=Path)
    parser.add_argument("--count", type=int, default=10)
    args = parser.parse_args()
    if not args.input.is_file():
        parser.error(f"input file not found: {args.input}")
    if args.count <= 0:
        parser.error("--count must be positive")

    with asx01_session() as ASX01:
        reader = ASX01.StreamReader.Create(str(args.input.resolve()))
        try:
            channel = reader.GetSampledChannels()[0]
            count = min(args.count, int(channel.NumberOfSamples))
            values = list(channel.GetData(0, count))
            print(f"Channel: {channel.ChannelInfo.Name}")
            print(f"Sample rate: {channel.SampleRate}")
            print(f"Samples: {channel.NumberOfSamples}")
            print(f"Quantity: {channel.Ordinate.Quantity.Name}")
            print(f"Unit: {channel.Ordinate.Quantity.Unit}")
            print(f"First values: {values}")
        finally:
            reader.Dispose()


if __name__ == "__main__":
    main()

