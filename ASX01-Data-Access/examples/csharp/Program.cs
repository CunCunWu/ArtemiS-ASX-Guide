using System;
using System.IO;
using System.Linq;
using HEADacoustics.API.Hdf;
using HEADacoustics.API.License;
using AsxStreamReader = HEADacoustics.API.Hdf.StreamReader;
using AsxLicense = HEADacoustics.API.License.License;

namespace HdfAsxGuide.Asx01Examples
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                PrintUsage();
                return 2;
            }

            try
            {
                using (AsxLicense.Create(ProductCode.ASX_01_DataAccessAPI))
                {
                    switch (args[0].ToLowerInvariant())
                    {
                        case "inspect":
                            RequireInput(args[1]);
                            Inspect(args[1]);
                            break;
                        case "read-time":
                            RequireInput(args[1]);
                            ReadTimeData(args[1]);
                            break;
                        case "read-2d":
                            RequireInput(args[1]);
                            Read2D(args[1]);
                            break;
                        case "read-3d":
                            RequireInput(args[1]);
                            Read3D(args[1]);
                            break;
                        case "create-hsvx":
                            RequireNewOutput(args[1]);
                            CreateHsvx(args[1]);
                            break;
                        default:
                            PrintUsage();
                            return 2;
                    }
                }

                return 0;
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine(exception);
                return 1;
            }
        }

        private static void Inspect(string path)
        {
            HdfInfo info = HdfInfo.Create(path);
            Console.WriteLine("Path: {0}", info.Path);
            Console.WriteLine("HDF type: {0}", info.HdfType);
            Console.WriteLine("Data type: {0}", info.DataType);
            Console.WriteLine("Title: {0}", info.FileInfo.Title);

            switch (info.HdfType)
            {
                case HdfType.TimeData:
                    using (AsxStreamReader reader = AsxStreamReader.Create(path))
                        Console.WriteLine("Sampled channels: {0}", reader.GetSampledChannels().Length);
                    break;
                case HdfType.AnalysisData2D:
                    ReaderResult result = Reader.Read2D(path);
                    Console.WriteLine("Real channels: {0}", result.RealChannels.Length);
                    Console.WriteLine("Complex channels: {0}", result.ComplexChannels.Length);
                    break;
                case HdfType.AnalysisData3D:
                    if (info.DataType == DataType.Real)
                    {
                        using (Real3DReader reader = Real3DReader.Create(path))
                            Console.WriteLine("Real 3D channels: {0}", reader.GetChannels().Length);
                    }
                    else if (info.DataType == DataType.Complex)
                    {
                        using (Complex3DReader reader = Complex3DReader.Create(path))
                            Console.WriteLine("Complex 3D channels: {0}", reader.GetChannels().Length);
                    }
                    break;
            }
        }

        private static void ReadTimeData(string path)
        {
            using (AsxStreamReader reader = AsxStreamReader.Create(path))
            {
                IStreamReaderSampledChannel channel = reader.GetSampledChannels().First();
                int count = (int)Math.Min(10L, channel.NumberOfSamples);
                float[] values = channel.GetData(0, count);

                Console.WriteLine("Channel: {0}", channel.ChannelInfo.Name);
                Console.WriteLine("Sample rate: {0}", channel.SampleRate);
                Console.WriteLine("Samples: {0}", channel.NumberOfSamples);
                Console.WriteLine("Quantity: {0}", channel.Ordinate.Quantity.Name);
                Console.WriteLine("Unit: {0}", channel.Ordinate.Quantity.Unit);
                Console.WriteLine("First values: {0}", string.Join(", ", values));
            }
        }

        private static void Read2D(string path)
        {
            HdfInfo info = HdfInfo.Create(path);
            if (info.HdfType != HdfType.AnalysisData2D)
                throw new InvalidDataException("The input is not a 2D analysis HDF.");

            ReaderResult result = Reader.Read2D(path);
            if (info.DataType == DataType.Real)
            {
                RealChannel channel = result.RealChannels.First();
                float[] values = channel.GetRealData();
                Console.WriteLine("Channel: {0}", channel.ChannelInfo.Name);
                Console.WriteLine("Abscissa: {0} [{1}]", channel.Abscissa.Quantity.Name, channel.Abscissa.Quantity.Unit);
                Console.WriteLine("Ordinate: {0} [{1}]", channel.Ordinate.Quantity.Name, channel.Ordinate.Quantity.Unit);
                Console.WriteLine("Points: {0}; range: {1} .. {2}", values.Length, values.Min(), values.Max());
            }
            else if (info.DataType == DataType.Complex)
            {
                ComplexChannel channel = result.ComplexChannels.First();
                Console.WriteLine("Channel: {0}", channel.ChannelInfo.Name);
                Console.WriteLine("Complex points: {0}", channel.GetRealData().Length);
            }
            else
            {
                throw new NotSupportedException("Unsupported 2D data type: " + info.DataType);
            }
        }

        private static void Read3D(string path)
        {
            HdfInfo info = HdfInfo.Create(path);
            if (info.HdfType != HdfType.AnalysisData3D)
                throw new InvalidDataException("The input is not a 3D analysis HDF.");

            if (info.DataType == DataType.Real)
            {
                using (Real3DReader reader = Real3DReader.Create(path))
                {
                    IReal3DReaderChannel channel = reader.GetChannels().First();
                    Console.WriteLine("Channel: {0}", channel.ChannelInfo.Name);
                    Console.WriteLine("First abscissa: {0} [{1}]", channel.FirstAbscissa.Quantity.Name, channel.FirstAbscissa.Quantity.Unit);
                    Console.WriteLine("Second abscissa: {0} [{1}]", channel.SecondAbscissa.Quantity.Name, channel.SecondAbscissa.Quantity.Unit);
                    Console.WriteLine("First vector length: {0}", channel.GetVector(0).Length);
                }
            }
            else if (info.DataType == DataType.Complex)
            {
                using (Complex3DReader reader = Complex3DReader.Create(path))
                {
                    IComplex3DReaderChannel channel = reader.GetChannels().First();
                    IComplexVector vector = channel.GetVector(0);
                    Console.WriteLine("Channel: {0}", channel.ChannelInfo.Name);
                    Console.WriteLine("First complex vector length: {0}", vector.Real.Length);
                }
            }
            else
            {
                throw new NotSupportedException("Unsupported 3D data type: " + info.DataType);
            }
        }

        private static void CreateHsvx(string outputPath)
        {
            Quantity quantity = Quantity.Create(QuantityIds.Torque, "Nm", QuantityDomains.Signal);
            string moniker = SingleValueMoniker.PrependIndividualSingleValueMonikerPrefix("Guide.Torque");
            SingleValue value = SingleValue.Create("Torque", moniker, 42.4, quantity);
            HsvxSingleValueChannel channel = HsvxSingleValueChannel.Create("Channel 1", value);
            HsvxSingleValueSource source = HsvxSingleValueSource.Create();

            ActionResult result = source.TryAddChannel(channel);
            if (!result.ActionIsOk)
                throw new InvalidOperationException("The HSVX channel could not be added.");

            HsvxWriter.WriteToHsvxFile(source, outputPath);
            Console.WriteLine("Created: {0}", outputPath);
        }

        private static void RequireInput(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Input file not found.", path);
        }

        private static void RequireNewOutput(string path)
        {
            if (File.Exists(path))
                throw new IOException("Refusing to overwrite existing output: " + path);
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Asx01Examples inspect <input.hdf>");
            Console.WriteLine("Asx01Examples read-time <input.hdf>");
            Console.WriteLine("Asx01Examples read-2d <input.hdf>");
            Console.WriteLine("Asx01Examples read-3d <input.hdf>");
            Console.WriteLine("Asx01Examples create-hsvx <output.hsvx>");
        }
    }
}

