import argparse
from pathlib import Path
from asx02_runtime import session

parser = argparse.ArgumentParser(); parser.add_argument("routine", type=Path); parser.add_argument("input"); parser.add_argument("result", type=Path)
args = parser.parse_args(); args.result.mkdir(parents=True, exist_ok=True)
if not args.routine.is_file(): parser.error("routine not found")
with session() as ASX02:
    from System import Action
    remote = ASX02.ASXRemote.ForLatestApplication(True)
    if not remote.Calculator.IsAvailable: remote.Calculator.Start("/prod *").Wait()
    job = remote.Calculator.GetProcessingService().StartJob("HDF-ASX-Guide", str(args.routine.resolve()), str(args.result.resolve()), [args.input])
    job.RegisterProgress(Action[int](lambda p: print(f"Progress {p}%")))
    summary = job.Wait(); print(f"Result files: {summary.ResultFiles.Length}")
