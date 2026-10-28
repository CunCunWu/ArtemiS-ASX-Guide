function create_directory_documentation(outDir,asxDir)
if nargin<2,asxDir='C:\Program Files\HEAD System Integration and Extension (ASX)';end
if ~isfolder(outDir),mkdir(outDir);end
NET.addAssembly(fullfile(asxDir,'HEADacoustics.API.Documentation.dll'));NET.addAssembly(fullfile(asxDir,'HEADacoustics.API.License.dll'));
import HEADacoustics.API.Documentation.*;import HEADacoustics.API.License.*
license=License.Create(ProductCode.ASX_05_DocumentationAndMetadataAPI);cleanup=onCleanup(@()license.Dispose()); %#ok<NASGU>
doc=Documentation.Create('Created by HDF-ASX-Guide');doc.AddField(TextField.Create('Name','Example'));doc.AddField(DateField.Create('Created',System.DateTime.Now));disp(DocumentationWriter.WriteDirectoryDocumentation(doc,outDir));
end
