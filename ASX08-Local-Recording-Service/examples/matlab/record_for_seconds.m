function record_for_seconds(seconds,fileName,asxDir)
if nargin<1,seconds=3;end;if nargin<2,fileName='HDF_ASX_Guide_Standalone.hdf';end;if nargin<3,asxDir='C:\Program Files\HEAD System Integration and Extension (ASX)';end
NET.addAssembly(fullfile(asxDir,'HEADacoustics.API.Remote.dll'));NET.addAssembly(fullfile(asxDir,'HEADacoustics.API.License.dll'));import HEADacoustics.API.Remote.*;import HEADacoustics.API.License.*
license=License.Create(ProductCode.ASX_04_DataAcquisitionAPI);cleanup=onCleanup(@()license.Dispose()); %#ok<NASGU>
remote=ASXRemote.ForLatestApplication(true);if ~remote.StandAloneRecorder.IsAvailable,remote.StandAloneRecorder.Start().Wait();end
control=remote.StandAloneRecorder.GetRecorderService().GetControlService();control.SetFileNamePattern(fileName);control.StartRecord();stopCleanup=onCleanup(@()control.StopRecord()); %#ok<NASGU>
pause(seconds);control.StopRecord();clear stopCleanup
end
