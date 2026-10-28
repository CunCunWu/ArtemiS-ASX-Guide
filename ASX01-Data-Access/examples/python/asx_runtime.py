"""Shared ASX 01 bootstrap helpers for the Python examples."""

from contextlib import contextmanager
import os
from pathlib import Path
import sys


DEFAULT_ASX_DIR = Path(r"C:\Program Files\HEAD System Integration and Extension (ASX)")


def load_asx01():
    asx_dir = Path(os.environ.get("ASX_DIR", str(DEFAULT_ASX_DIR)))
    if not asx_dir.is_dir():
        raise FileNotFoundError(
            f"ASX directory not found: {asx_dir}. Install ASX or set ASX_DIR."
        )

    sys.path.append(str(asx_dir))
    import clr

    clr.AddReference("HEADacoustics.API.Hdf")
    clr.AddReference("HEADacoustics.API.License")
    clr.AddReference("HEADacoustics.API.Shared")

    import HEADacoustics.API.Hdf as ASX01
    from HEADacoustics.API.License import License, ProductCode

    return ASX01, License, ProductCode


@contextmanager
def asx01_session():
    ASX01, License, ProductCode = load_asx01()
    license_ = License.Create([ProductCode.ASX_01_DataAccessAPI])
    try:
        yield ASX01
    finally:
        license_.Dispose()

