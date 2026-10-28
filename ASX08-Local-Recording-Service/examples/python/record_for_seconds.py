import argparse,os,sys,time
p=argparse.ArgumentParser();p.add_argument('--seconds',type=float,default=3);p.add_argument('--name',default='HDF_ASX_Guide_Standalone.hdf');a=p.parse_args()
sys.path.append(os.environ.get('ASX_DIR',r'C:\Program Files\HEAD System Integration and Extension (ASX)'))
import clr;clr.AddReference('HEADacoustics.API.Remote');clr.AddReference('HEADacoustics.API.License')
import HEADacoustics.API.Remote as Remote
from HEADacoustics.API.License import License,ProductCode
license_=License.Create([ProductCode.ASX_04_DataAcquisitionAPI])
try:
 remote=Remote.ASXRemote.ForLatestApplication(True)
 if not remote.StandAloneRecorder.IsAvailable:remote.StandAloneRecorder.Start().Wait()
 control=remote.StandAloneRecorder.GetRecorderService().GetControlService();control.SetFileNamePattern(a.name);control.StartRecord()
 try:time.sleep(a.seconds)
 finally:control.StopRecord()
finally:license_.Dispose()
