import argparse,os,sys
from pathlib import Path
p=argparse.ArgumentParser();p.add_argument('input',type=Path);p.add_argument('pdf',type=Path);p.add_argument('pptx',type=Path);p.add_argument('--range',default='');a=p.parse_args()
if not a.input.is_file():p.error('report not found')
if a.pdf.exists() or a.pptx.exists():p.error('refusing to overwrite output')
sys.path.append(os.environ.get('ASX_DIR',r'C:\Program Files\HEAD System Integration and Extension (ASX)'))
import clr;clr.AddReference('HEADacoustics.API.Reporting');clr.AddReference('HEADacoustics.API.License')
import HEADacoustics.API.Reporting as Reporting
from HEADacoustics.API.License import License,ProductCode
license_=License.Create([ProductCode.ASX_09_ReportingAPI]);report=None
try:
 report=Reporting.ReportReader.ReadFromFile(str(a.input.resolve())).Wait();settings=Reporting.ExportSettings.Default()
 if a.range:settings=settings.WithRangeCustom(a.range)
 Reporting.ReportExporter.ExportToPdf(report,str(a.pdf.resolve()),settings).Wait();Reporting.ReportExporter.ExportToPowerPoint(report,str(a.pptx.resolve()),settings).Wait()
finally:
 if report:report.Dispose()
 license_.Dispose()
