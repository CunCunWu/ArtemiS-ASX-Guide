import os,sys
def arg(prefix,default=None):
 for value in sys.argv[1:]:
  if value.lower().startswith(prefix.lower()):return value[len(prefix):].strip('"')
 return default
asx=os.environ.get('ASX_DIR',r'C:\Program Files\HEAD System Integration and Extension (ASX)');sys.path.append(asx)
import clr;clr.AddReference('HEADacoustics.API.Hdf');clr.AddReference('HEADacoustics.API.License');import System
import HEADacoustics.API.Hdf as Hdf
from HEADacoustics.API.License import License,ProductCode
input_path=arg('/In=');output_path=arg('/Out=');factor=float(arg('/factor=','1'))
if not input_path or not os.path.isfile(input_path) or not output_path:raise SystemExit(2)
license_=License.Create([ProductCode.ASX_01_DataAccessAPI]);reader=None
try:
 reader=Hdf.StreamReader.Create(input_path);writer=Hdf.Writer.Create(reader.FileInfo)
 for ch in reader.GetSampledChannels():
  data=ch.GetData(0,int(ch.NumberOfSamples));scaled=System.Array[System.Single]([float(v)*factor for v in data])
  info=Hdf.ChannelInfo.Create(ch.ChannelInfo.Name,ch.ChannelInfo.Title,ch.ChannelInfo.Abbreviation)
  writer.AddChannel(Hdf.RealChannel.Create(scaled,info,ch.EquidistantAbscissa,ch.Ordinate,'Recording'))
 if not writer.Write(output_path):raise SystemExit(3)
finally:
 if reader:reader.Dispose()
 license_.Dispose()
