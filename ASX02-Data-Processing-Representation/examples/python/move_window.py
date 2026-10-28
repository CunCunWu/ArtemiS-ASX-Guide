from asx02_runtime import session

with session() as ASX02:
    remote = ASX02.ArtemiSuiteRemote.ForLatestApplication(True)
    if not remote.Application.IsAvailable:
        remote.Application.Start().Wait()
    rect = ASX02.Rect(); rect.X = 10; rect.Y = 10; rect.Width = 1024; rect.Height = 768
    remote.Application.GetMainWindowService().MoveTo(rect)
