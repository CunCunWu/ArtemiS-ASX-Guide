using System;
using System.Globalization;
using System.IO;
using System.Linq;
using HEADacoustics.API.Hdf;
using HEADacoustics.API.License;
using StreamReader = HEADacoustics.API.Hdf.StreamReader;
using License = HEADacoustics.API.License.License;

public static class TimeSignalFactor
{
    private static string GetArgument(string[] args, string prefix)
    {
        string value = args.FirstOrDefault(item =>
            item.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
        return value == null ? null : value.Substring(prefix.Length).Trim('"');
    }

    public static int Main(string[] args)
    {
        try
        {
            string input = GetArgument(args, "/In=");
            string output = GetArgument(args, "/Out=");
            float factor;
            bool factorIsValid = float.TryParse(
                GetArgument(args, "/factor=") ?? "1",
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out factor);
            if (!File.Exists(input) || string.IsNullOrWhiteSpace(output) || !factorIsValid)
                return 2;

            using (License.Create(ProductCode.ASX_01_DataAccessAPI))
            using (var reader = StreamReader.Create(input))
            {
                var writer = Writer.Create(reader.FileInfo);
                foreach (var channel in reader.GetSampledChannels())
                {
                    if (channel.NumberOfSamples > int.MaxValue)
                        throw new InvalidOperationException(
                            "Use a block-writing implementation for this file.");

                    float[] data = channel.GetData(0, (int)channel.NumberOfSamples);
                    for (int index = 0; index < data.Length; index++)
                        data[index] *= factor;

                    var channelInfo = ChannelInfo.Create(
                        channel.ChannelInfo.Name,
                        channel.ChannelInfo.Title,
                        channel.ChannelInfo.Abbreviation);
                    writer.AddChannel(RealChannel.Create(
                        data,
                        channelInfo,
                        channel.EquidistantAbscissa,
                        channel.Ordinate,
                        "Recording"));
                }

                if (!writer.Write(output))
                    return 3;
            }

            return 0;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine(exception);
            return 1;
        }
    }
}
