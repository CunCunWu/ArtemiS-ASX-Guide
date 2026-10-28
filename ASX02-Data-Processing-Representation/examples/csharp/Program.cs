using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using HEADacoustics.API.License;
using HEADacoustics.API.Remote;
using HEADacoustics.API.Shared;
using License = HEADacoustics.API.License.License;

namespace HdfAsxGuide.Asx02
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            try { return Run(args).GetAwaiter().GetResult(); }
            catch (Exception e) { Console.Error.WriteLine(e); return 1; }
        }

        private static async Task<int> Run(string[] args)
        {
            if (args.Length == 1 && args[0] == "move-window") { await MoveWindow(); return 0; }
            if (args.Length == 4 && args[0] == "run-calculator") { await RunCalculator(args[1], args[2], args[3]); return 0; }
            Console.WriteLine("move-window | run-calculator <routine.hpsx> <input> <result-directory>"); return 2;
        }

        private static async Task MoveWindow()
        {
            using (License.Create(ProductCode.ASX_02_DataProcessingAndRepresentationAPI))
            {
                var remote = ArtemiSuiteRemote.ForLatestApplication(true);
                if (!remote.Application.IsAvailable) await remote.Application.Start();
                remote.Application.GetMainWindowService().MoveTo(new Rect { X = 10, Y = 10, Width = 1024, Height = 768 });
            }
        }

        private static async Task RunCalculator(string routine, string input, string resultDirectory)
        {
            if (!File.Exists(routine)) throw new FileNotFoundException("HPSX not found", routine);
            Directory.CreateDirectory(resultDirectory);
            using (License.Create(ProductCode.ASX_02_DataProcessingAndRepresentationAPI))
            {
                var remote = ASXRemote.ForLatestApplication(true);
                if (!remote.Calculator.IsAvailable) await remote.Calculator.Start("/prod *");
                var summary = await remote.Calculator.GetProcessingService()
                    .StartJob("HDF-ASX-Guide", routine, resultDirectory, new[] { input })
                    .AsTask(CancellationToken.None, new Progress<int>(p => Console.WriteLine("Progress {0}%", p)));
                Console.WriteLine("Result files: {0}", summary.ResultFiles.Length);
            }
        }
    }
}
