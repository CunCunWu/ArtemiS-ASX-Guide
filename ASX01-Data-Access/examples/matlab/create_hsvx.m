function create_hsvx(outputPath, asxDir)
%CREATE_HSVX Create one torque single-value channel in a new HSVX file.
    if nargin < 2
        asxDir = [];
    end
    if isfile(outputPath)
        error('Refusing to overwrite existing output: %s', outputPath);
    end

    license = setup_asx01(asxDir);
    licenseCleanup = onCleanup(@() license.Dispose()); %#ok<NASGU>
    import HEADacoustics.API.Hdf.*

    quantity = Quantity.Create(QuantityIds.Torque, 'Nm', QuantityDomains.Signal);
    moniker = SingleValueMoniker.PrependIndividualSingleValueMonikerPrefix('Guide.Torque');
    value = SingleValue.Create('Torque', moniker, 42.4, quantity);
    channel = HsvxSingleValueChannel.Create('Channel 1', value);
    source = HsvxSingleValueSource.Create();
    result = source.TryAddChannel(channel);
    if ~result.ActionIsOk
        error('The HSVX channel could not be added.');
    end

    HsvxWriter.WriteToHsvxFile(source, outputPath);
    fprintf('Created: %s\n', outputPath);
end

