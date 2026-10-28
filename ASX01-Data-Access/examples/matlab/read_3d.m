function read_3d(inputPath, asxDir)
%READ_3D Read axes and the first vector from a 3D analysis HDF.
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
    if ~strcmp(char(info.HdfType.ToString()), 'AnalysisData3D')
        error('Input is not a 3D analysis HDF.');
    end

    if strcmp(char(info.DataType.ToString()), 'Real')
        reader = Real3DReader.Create(inputPath);
    else
        reader = Complex3DReader.Create(inputPath);
    end
    readerCleanup = onCleanup(@() reader.Dispose()); %#ok<NASGU>
    channels = reader.GetChannels();
    channel = channels(1);
    vector = channel.GetVector(int64(0));

    fprintf('Channel: %s\n', char(channel.ChannelInfo.Name));
    fprintf('First abscissa: %s [%s]\n', char(channel.FirstAbscissa.Quantity.Name), char(channel.FirstAbscissa.Quantity.Unit));
    fprintf('Second abscissa: %s [%s]\n', char(channel.SecondAbscissa.Quantity.Name), char(channel.SecondAbscissa.Quantity.Unit));
    if strcmp(char(info.DataType.ToString()), 'Real')
        fprintf('First vector length: %d\n', vector.Length);
    else
        fprintf('First complex vector length: %d\n', vector.Real.Length);
    end
end

