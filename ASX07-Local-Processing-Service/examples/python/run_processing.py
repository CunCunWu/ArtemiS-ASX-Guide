import argparse,os,subprocess
from pathlib import Path
p=argparse.ArgumentParser();p.add_argument('job',type=Path);p.add_argument('source');p.add_argument('target',type=Path);p.add_argument('--prod',default='*');p.add_argument('--var',action='append',default=[]);a=p.parse_args()
if not a.job.is_file():p.error('HPSX not found')
a.target.mkdir(parents=True,exist_ok=True)
exe=Path(os.environ.get('ASX_DIR',r'C:\Program Files\HEAD System Integration and Extension (ASX)'))/'ArtemiSproc.exe'
cmd=[str(exe),'/job',str(a.job.resolve()),'/src',a.source,'/target',str(a.target.resolve()),'/prod',a.prod]
for value in a.var:cmd.extend(['/var',value])
result=subprocess.run(cmd,check=False);raise SystemExit(result.returncode)
