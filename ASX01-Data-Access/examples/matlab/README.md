# MATLAB examples

MATLAB loads the ASX .NET Framework assemblies and calls the same ASX 01 API used by C# and Python.

## Setup

Add this directory to the MATLAB path, then pass an optional ASX installation directory to `setup_asx01` through the example functions. Without an override, the standard installation path is used.

## Run

```matlab
inspect_hdf('C:\data\Input.hdf')
read_time_data('C:\data\InputTimeData.hdf')
read_2d('C:\data\Input2D.hdf')
read_3d('C:\data\Input3D.hdf')
create_hsvx('C:\data\NewOutput.hsvx')
```

Each function uses `onCleanup` so the ASX 01 license and disposable readers are released even when an error occurs.

