function exitCode=run_processing(job,source,target,productCodes,asxDir)
if nargin<4,productCodes='*';end;if nargin<5,asxDir='C:\Program Files\HEAD System Integration and Extension (ASX)';end
exe=fullfile(asxDir,'ArtemiSproc.exe');cmd=sprintf('"%s" /job "%s" /src "%s" /target "%s" /prod "%s"',exe,job,source,target,productCodes);exitCode=system(cmd);
end
