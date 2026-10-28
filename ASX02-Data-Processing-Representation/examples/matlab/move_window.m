function move_window(asxDir)
if nargin<1, asxDir=[]; end
license=setup_asx02(asxDir); cleanup=onCleanup(@()license.Dispose()); %#ok<NASGU>
import HEADacoustics.API.Remote.*
remote=ArtemiSuiteRemote.ForLatestApplication(true); if ~remote.Application.IsAvailable, remote.Application.Start().Wait(); end
rect=Rect(); rect.X=10; rect.Y=10; rect.Width=1024; rect.Height=768; remote.Application.GetMainWindowService().MoveTo(rect);
end
