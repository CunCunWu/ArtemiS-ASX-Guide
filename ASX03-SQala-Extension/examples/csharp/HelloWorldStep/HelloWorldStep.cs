using System.Linq;
using System.Windows;
using System.Xml.Linq;
using HEADacoustics.API.SQala;

namespace HdfAsxGuide.SQala.HelloWorld
{
    public class HelloWorldStep : IStep
    {
        private INavigation navigation;

        public ISoundReference Sound { get; set; }
        public IPlayer Player { get; set; }

        public void OnStarted(XElement readonlyStepConfig, IRuntimeEnvironment environment)
        {
            Sound = environment.SoundReferences.First();
            Player = environment.Player;
            navigation = environment.Navigation;
            Player.OnPlaybackEvent += OnPlaybackEvent;
        }

        public void OnCanceled()
        {
        }

        public StepResult OnFinished()
        {
            return null;
        }

        private void OnPlaybackEvent(object sender, PlaybackEventArgs eventArgs)
        {
            if (eventArgs.Type == PlaybackEventType.Finished)
                navigation.FinishEnabled = true;
        }

        public FrameworkElement View
        {
            get { return new HelloWorldStepView { DataContext = this }; }
        }
    }
}
