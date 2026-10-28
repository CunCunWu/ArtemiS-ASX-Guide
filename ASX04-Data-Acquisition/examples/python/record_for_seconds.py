import argparse, os, sys, time
parser=argparse.ArgumentParser(); parser.add_argument('--seconds',type=float,default=3); parser.add_argument('--name',default='HDF_ASX_Guide_Record.hdf'); args=parser.parse_args()
if args.seconds<=0: parser.error('seconds must be positive')
sys.path.append(os.environ.get('ASX_DIR',r'C:\Program Files\HEAD System Integration and Extension (ASX)'))
import clr; clr.AddReference('HEADacoustics.API.Remote'); clr.AddReference('HEADacoustics.API.License')
import HEADacoustics.API.Remote as Remote
from HEADacoustics.API.License import License,ProductCode
license_=License.Create([ProductCode.ASX_04_DataAcquisitionAPI])
try:
 remote=Remote.ArtemiSuiteRemote.ForLatestApplication(True)
 if not remote.Application.IsAvailable: remote.Application.Start('/nolic').Wait()
 control=remote.Application.Recorder.GetControlService(); control.SetFileNamePattern(args.name)
 control.StartRecord()
 try: time.sleep(args.seconds)
 finally: control.StopRecord()
finally: license_.Dispose()
