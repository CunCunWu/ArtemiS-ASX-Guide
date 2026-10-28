function export_report(input,pdfOut,pptxOut,pageRange,asxDir)
if nargin<4,pageRange='';end;if nargin<5,asxDir='C:\Program Files\HEAD System Integration and Extension (ASX)';end
NET.addAssembly(fullfile(asxDir,'HEADacoustics.API.Reporting.dll'));NET.addAssembly(fullfile(asxDir,'HEADacoustics.API.License.dll'));import HEADacoustics.API.Reporting.*;import HEADacoustics.API.License.*
license=License.Create(ProductCode.ASX_09_ReportingAPI);licenseCleanup=onCleanup(@()license.Dispose()); %#ok<NASGU>
report=ReportReader.ReadFromFile(input).Wait();reportCleanup=onCleanup(@()report.Dispose()); %#ok<NASGU>
settings=ExportSettings.Default();if ~isempty(pageRange),settings=settings.WithRangeCustom(pageRange);end
ReportExporter.ExportToPdf(report,pdfOut,settings).Wait();ReportExporter.ExportToPowerPoint(report,pptxOut,settings).Wait();
end
