from contextlib import contextmanager
import os, sys

@contextmanager
def session():
    asx_dir = os.environ.get("ASX_DIR", r"C:\Program Files\HEAD System Integration and Extension (ASX)")
    sys.path.append(asx_dir)
    import clr
    clr.AddReference("HEADacoustics.API.Remote"); clr.AddReference("HEADacoustics.API.License")
    import HEADacoustics.API.Remote as ASX02
    from HEADacoustics.API.License import License, ProductCode
    license_ = License.Create([ProductCode.ASX_02_DataProcessingAndRepresentationAPI])
    try: yield ASX02
    finally: license_.Dispose()
