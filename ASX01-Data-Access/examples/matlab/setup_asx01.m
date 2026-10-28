function license = setup_asx01(asxDir)
%SETUP_ASX01 Load ASX 01 assemblies and acquire the Data Access license.
    if nargin < 1 || isempty(asxDir)
        asxDir = 'C:\Program Files\HEAD System Integration and Extension (ASX)';
    end
    if ~isfolder(asxDir)
        error('ASX directory not found: %s', asxDir);
    end

    NET.addAssembly(fullfile(asxDir, 'HEADacoustics.API.Hdf.dll'));
    NET.addAssembly(fullfile(asxDir, 'HEADacoustics.API.License.dll'));
    NET.addAssembly(fullfile(asxDir, 'HEADacoustics.API.Shared.dll'));

    import HEADacoustics.API.License.*
    license = License.Create(ProductCode.ASX_01_DataAccessAPI);
end

