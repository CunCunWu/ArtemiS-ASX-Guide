using System;
using System.IO;
using HEADacoustics.API.Documentation;
using HEADacoustics.API.License;
using License = HEADacoustics.API.License.License;

public static class CreateDirectoryDocumentation
{
    public static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("<directory>");
            return 2;
        }

        string directory = Path.GetFullPath(args[0]);
        Directory.CreateDirectory(directory);
        using (License.Create(ProductCode.ASX_05_DocumentationAndMetadataAPI))
        {
            var documentation = Documentation.Create("Created by HDF-ASX-Guide");
            documentation.AddField(TextField.Create("Name", "Example"));
            documentation.AddField(DateField.Create("Created", DateTime.Now));
            var result = DocumentationWriter.WriteDirectoryDocumentation(documentation, directory);
            Console.WriteLine(result);
        }

        return 0;
    }
}
