function read_time_data(inputPath, count, asxDir)
%READ_TIME_DATA Read metadata and the first samples of a sampled channel.
    if nargin < 2 || isempty(count)
        count = 10;
    end
    if nargin < 3
        asxDir = [];
    end
    if ~isfile(inputPath)
        error('Input file not found: %s', inputPath);
    end

    license = setup_asx01(asxDir);
    licenseCleanup = onCleanup(@() license.Dispose()); %#ok<NASGU>
    import HEADacoustics.API.Hdf.*

    reader = StreamReader.Create(inputPath);
    readerCleanup = onCleanup(@() reader.Dispose()); %#ok<NASGU>
    channels = reader.GetSampledChannels();
    channel = channels(1);
    count = min(double(count), double(channel.NumberOfSamples));
    values = double(channel.GetData(int64(0), int32(count)));

    fprintf('Channel: %s\n', char(channel.ChannelInfo.Name));
    fprintf('Sample rate: %.12g\n', double(channel.SampleRate));
    fprintf('Samples: %d\n', int64(channel.NumberOfSamples));
    fprintf('Quantity: %s\n', char(channel.Ordinate.Quantity.Name));
    fprintf('Unit: %s\n', char(channel.Ordinate.Quantity.Unit));
    disp('First values:');
    disp(values);
end

