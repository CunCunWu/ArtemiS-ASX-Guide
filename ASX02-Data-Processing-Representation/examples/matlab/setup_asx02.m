function license = setup_asx02(asxDir)
if nargin < 1 || isempty(asxDir), asxDir='C:\Program Files\HEAD System Integration and Extension (ASX)'; end
NET.addAssembly(fullfile(asxDir,'HEADacoustics.API.Remote.dll')); NET.addAssembly(fullfile(asxDir,'HEADacoustics.API.License.dll'));
import HEADacoustics.API.License.*
license=License.Create(ProductCode.ASX_02_DataProcessingAndRepresentationAPI);
end
