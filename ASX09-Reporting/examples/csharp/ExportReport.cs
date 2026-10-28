using System;
using System.IO;
using System.Threading.Tasks;
using HEADacoustics.API.License;
using HEADacoustics.API.Reporting;
using HEADacoustics.API.Shared;

public static class ExportReport
{
    public static void Main(string[] args)
    {
        Run(args).GetAwaiter().GetResult();
    }

    private static async Task Run(string[] args)
    {
        if (args.Length < 3)
            throw new ArgumentException("<input.hrpx> <output.pdf> <output.pptx> [range]");
        if (File.Exists(args[1]) || File.Exists(args[2]))
            throw new IOException("Refusing to overwrite output");

        using (License.Create(ProductCode.ASX_09_ReportingAPI))
        {
            var report = await ReportReader.ReadFromFile(args[0]).AsTask();
            try
            {
                var settings = ExportSettings.Default();
                if (args.Length > 3)
                    settings = settings.WithRangeCustom(args[3]);
                await report.ExportToPdf(args[1], settings).AsTask();
                await report.ExportToPowerPoint(args[2], settings).AsTask();
            }
            finally
            {
                report.Dispose();
            }
        }
    }
}
