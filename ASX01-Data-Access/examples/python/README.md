# Python examples

Python uses `pythonnet` to call the ASX .NET Framework API. These scripts do not parse HEAD HDF as generic HDF5.

## Setup

```powershell
python -m pip install -r requirements.txt
```

Optional custom installation path:

```powershell
$env:ASX_DIR = 'D:\ASX'
```

## Run

```powershell
python inspect_hdf.py <input.hdf>
python read_time_data.py <input.hdf>
python read_2d.py <input.hdf>
python read_3d.py <input.hdf>
python create_hsvx.py <new-output.hsvx>
```

The scripts acquire ASX 01 for the shortest practical scope and always dispose the license and readers. Runtime execution requires ASX 01 and compatible sample data.

