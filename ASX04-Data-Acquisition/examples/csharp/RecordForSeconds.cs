using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using HEADacoustics.API.License;
using HEADacoustics.API.Remote;
using License = HEADacoustics.API.License.License;

public static class RecordForSeconds
{
    public static void Main(string[] args)
    {
        Run(args).GetAwaiter().GetResult();
    }

    private static async Task Run(string[] args)
    {
        double seconds = args.Length > 0
            ? double.Parse(args[0], CultureInfo.InvariantCulture)
            : 3.0;
        string fileName = args.Length > 1 ? args[1] : "HDF_ASX_Guide_Record.hdf";

        using (License.Create(ProductCode.ASX_04_DataAcquisitionAPI))
        {
            var remote = ArtemiSuiteRemote.ForLatestApplication(true);
            if (!remote.Application.IsAvailable)
                await remote.Application.Start("/nolic");

            var control = remote.Application.Recorder.GetControlService();
            control.SetFileNamePattern(fileName);
            control.StartRecord();
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(seconds));
            }
            finally
            {
                control.StopRecord();
            }
        }
    }
}
