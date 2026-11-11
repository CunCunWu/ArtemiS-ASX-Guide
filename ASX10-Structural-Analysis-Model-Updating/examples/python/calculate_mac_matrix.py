import argparse
import os
import sys
from pathlib import Path


def threshold_value(text):
    value = float(text)
    if not 0.0 <= value <= 1.0:
        raise argparse.ArgumentTypeError("threshold must be between 0 and 1")
    return value


parser = argparse.ArgumentParser(
    description="Calculate MAC values between Nastran simulation shapes and a measured HSTX."
)
parser.add_argument("simulation_pch", type=Path)
parser.add_argument("geometry_bdf", type=Path)
parser.add_argument("measurement_hstx", type=Path)
parser.add_argument("--threshold", type=threshold_value, default=0.7)
args = parser.parse_args()

for input_path in (args.simulation_pch, args.geometry_bdf, args.measurement_hstx):
    if not input_path.is_file():
        parser.error(f"input file not found: {input_path}")

asx_dir = os.environ.get(
    "ASX_DIR", r"C:\Program Files\HEAD System Integration and Extension (ASX)"
)
sys.path.append(asx_dir)

import clr  # noqa: E402

clr.AddReference("HEADacoustics.API.License")
clr.AddReference("HEADacoustics.API.StructuralAnalysis.ModelUpdating")

import HEADacoustics.API.StructuralAnalysis.ModelUpdating as ASX10  # noqa: E402
from HEADacoustics.API.License import License, ProductCode  # noqa: E402


license_ = License.Create([ProductCode.ASX_10_StructuralAnalysisModelUpdatingAPI])
try:
    measurement_points = ASX10.MeasurementPointsReader.ReadNastran(
        str(args.simulation_pch.resolve()),
        str(args.geometry_bdf.resolve()),
        ASX10.LengthUnit.METER,
    ).Wait()

    simulation_shapes = ASX10.ShapeTableReader.ReadNastran(
        str(args.simulation_pch.resolve()), measurement_points
    ).Wait()

    measurement_shapes = ASX10.ShapeTableReader.Read(
        str(args.measurement_hstx.resolve())
    ).Wait()

    mac_matrix = ASX10.MacCalculator.CalculateMacMatrix(
        simulation_shapes, measurement_shapes
    ).Wait()

    print("MAC\tSimulationHz\tMeasurementHz")
    for pair in mac_matrix.GetValues(args.threshold):
        print(
            f"{pair.Value:.4f}\t"
            f"{pair.ShapeA.Frequency:.2f}\t"
            f"{pair.ShapeB.Frequency:.2f}"
        )
finally:
    license_.Dispose()
