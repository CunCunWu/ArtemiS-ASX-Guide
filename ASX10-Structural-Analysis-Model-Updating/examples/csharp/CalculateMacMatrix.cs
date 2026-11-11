using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using HEADacoustics.API.License;
using HEADacoustics.API.Shared;
using HEADacoustics.API.StructuralAnalysis.ModelUpdating;

public static class CalculateMacMatrix
{
    public static void Main(string[] args)
    {
        Run(args).GetAwaiter().GetResult();
    }

    private static async Task Run(string[] args)
    {
        if (args.Length < 3 || args.Length > 4)
            throw new ArgumentException(
                "<simulation.pch> <geometry.bdf> <measurement.hstx> [threshold]");

        foreach (var filePath in new[] { args[0], args[1], args[2] })
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Input file not found", filePath);
        }

        var threshold = 0.7d;
        if (args.Length == 4 &&
            !double.TryParse(args[3], NumberStyles.Float, CultureInfo.InvariantCulture, out threshold))
        {
            throw new ArgumentException("Threshold must be a number between 0 and 1");
        }
        if (threshold < 0d || threshold > 1d)
            throw new ArgumentOutOfRangeException("threshold", "Threshold must be between 0 and 1");

        using (License.Create(ProductCode.ASX_10_StructuralAnalysisModelUpdatingAPI))
        {
            var measurementPoints = await MeasurementPointsReader.ReadNastran(
                Path.GetFullPath(args[0]),
                Path.GetFullPath(args[1]),
                LengthUnit.METER).AsTask();

            var simulationShapes = await ShapeTableReader.ReadNastran(
                Path.GetFullPath(args[0]), measurementPoints).AsTask();

            var measurementShapes = await ShapeTableReader.Read(
                Path.GetFullPath(args[2])).AsTask();

            var macMatrix = await MacCalculator.CalculateMacMatrix(
                simulationShapes, measurementShapes).AsTask();

            Console.WriteLine("MAC\tSimulationHz\tMeasurementHz");
            foreach (var pair in macMatrix.GetValues(threshold))
            {
                Console.WriteLine(string.Format(
                    CultureInfo.InvariantCulture,
                    "{0:F4}\t{1:F2}\t{2:F2}",
                    pair.Value,
                    pair.ShapeA.Frequency,
                    pair.ShapeB.Frequency));
            }
        }
    }
}
