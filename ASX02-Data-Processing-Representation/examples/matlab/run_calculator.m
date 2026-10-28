function run_calculator(routine,inputData,resultDir,asxDir)
if nargin<4, asxDir=[]; end
license=setup_asx02(asxDir); cleanup=onCleanup(@()license.Dispose()); %#ok<NASGU>
import HEADacoustics.API.Remote.*
remote=ASXRemote.ForLatestApplication(true); if ~remote.Calculator.IsAvailable, remote.Calculator.Start('/prod *').Wait(); end
job=remote.Calculator.GetProcessingService().StartJob('HDF-ASX-Guide',routine,resultDir,{inputData});
job.RegisterProgress(@(p)fprintf('Progress %d%%\n',p)); summary=job.Wait(); fprintf('Result files: %d\n',summary.ResultFiles.Length);
end
