using System;
using System.Diagnostics;
using System.IO;

public static class RunProcessing
{
    public static int Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("<job.hpsx> <source> <target> [prod]");
            return 4;
        }

        string asxDirectory = Environment.GetEnvironmentVariable("ASX_DIR")
            ?? @"C:\Program Files\HEAD System Integration and Extension (ASX)";
        string target = Path.GetFullPath(args[2]);
        Directory.CreateDirectory(target);

        string commandLine = string.Format(
            "/job \"{0}\" /src \"{1}\" /target \"{2}\" /prod \"{3}\"",
            Path.GetFullPath(args[0]), args[1], target, args.Length > 3 ? args[3] : "*");
        var process = Process.Start(new ProcessStartInfo(
            Path.Combine(asxDirectory, "ArtemiSproc.exe"), commandLine)
        {
            UseShellExecute = false
        });
        process.WaitForExit();
        return process.ExitCode;
    }
}
