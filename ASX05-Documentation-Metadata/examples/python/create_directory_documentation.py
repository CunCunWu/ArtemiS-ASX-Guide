import argparse,os,sys
from pathlib import Path
parser=argparse.ArgumentParser();parser.add_argument('directory',type=Path);args=parser.parse_args();args.directory.mkdir(parents=True,exist_ok=True)
sys.path.append(os.environ.get('ASX_DIR',r'C:\Program Files\HEAD System Integration and Extension (ASX)'))
import clr;clr.AddReference('HEADacoustics.API.Documentation');clr.AddReference('HEADacoustics.API.License');import System
import HEADacoustics.API.Documentation as ASX05
from HEADacoustics.API.License import License,ProductCode
license_=License.Create([ProductCode.ASX_05_DocumentationAndMetadataAPI])
try:
 doc=ASX05.Documentation.Create('Created by HDF-ASX-Guide');doc.AddField(ASX05.TextField.Create('Name','Example'));doc.AddField(ASX05.DateField.Create('Created',System.DateTime.Now))
 result=ASX05.DocumentationWriter.WriteDirectoryDocumentation(doc,str(args.directory.resolve()));print(result)
finally:license_.Dispose()
