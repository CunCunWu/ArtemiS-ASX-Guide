function read_2d(inputPath, asxDir)
%READ_2D Read the first real or complex channel from a 2D analysis HDF.
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
    if ~strcmp(char(info.HdfType.ToString()), 'AnalysisData2D')
        error('Input is not a 2D analysis HDF.');
    end

    result = Reader.Read2D(inputPath);
    if strcmp(char(info.DataType.ToString()), 'Real')
        channel = result.RealChannels(1);
        values = double(channel.GetRealData());
        fprintf('Channel: %s\n', char(channel.ChannelInfo.Name));
        fprintf('Abscissa: %s [%s]\n', char(channel.Abscissa.Quantity.Name), char(channel.Abscissa.Quantity.Unit));
        fprintf('Ordinate: %s [%s]\n', char(channel.Ordinate.Quantity.Name), char(channel.Ordinate.Quantity.Unit));
        fprintf('Points: %d; range: %.12g .. %.12g\n', numel(values), min(values), max(values));
    else
        channel = result.ComplexChannels(1);
        realValues = double(channel.GetRealData());
        imaginaryValues = double(channel.GetImagData());
        fprintf('Channel: %s\n', char(channel.ChannelInfo.Name));
        fprintf('Complex points: %d\n', numel(realValues));
        fprintf('First value: %.12g + j%.12g\n', realValues(1), imaginaryValues(1));
    end
end

