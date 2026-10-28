function inspect_hdf(inputPath, asxDir)
%INSPECT_HDF Identify an HDF and count channels using the matching reader.
    if nargin < 2
        asxDir = [];
    end
    if ~isfile(inputPath)
        error('Input file not found: %s', inputPath);
    end

    license = setup_asx01(asxDir);
    licenseCleanup = onCleanup(@() license.Dispose()); %#ok<NASGU>
    import HEADacoustics.API.Hdf.*

    info = HdfInfo.Create(inputPath);
    hdfType = char(info.HdfType.ToString());
    dataType = char(info.DataType.ToString());
    fprintf('Path: %s\n', char(info.Path));
    fprintf('HDF type: %s\n', hdfType);
    fprintf('Data type: %s\n', dataType);
    fprintf('Title: %s\n', char(info.FileInfo.Title));

    switch hdfType
        case 'TimeData'
            reader = StreamReader.Create(inputPath);
            readerCleanup = onCleanup(@() reader.Dispose()); %#ok<NASGU>
            fprintf('Sampled channels: %d\n', reader.GetSampledChannels().Length);
        case 'AnalysisData2D'
            result = Reader.Read2D(inputPath);
            if strcmp(dataType, 'Real')
                fprintf('2D channels: %d\n', result.RealChannels.Length);
            else
                fprintf('2D channels: %d\n', result.ComplexChannels.Length);
            end
        case 'AnalysisData3D'
            if strcmp(dataType, 'Real')
                reader = Real3DReader.Create(inputPath);
            else
                reader = Complex3DReader.Create(inputPath);
            end
            readerCleanup = onCleanup(@() reader.Dispose()); %#ok<NASGU>
            fprintf('3D channels: %d\n', reader.GetChannels().Length);
        otherwise
            error('Unsupported HDF type: %s/%s', hdfType, dataType);
    end
end

