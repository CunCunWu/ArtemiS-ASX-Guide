using HEADacoustics.API.SQala;

namespace HdfAsxGuide.SQala.HelloWorld
{
    [ExportStepFactory("HdfAsxGuide.HelloWorldStep")]
    public class HelloWorldFactory : IStepFactory
    {
        public FactorySettings Settings
        {
            get
            {
                var settings = new FactorySettings();
                settings.SetName("HDF-ASX Guide Hello World");
                settings.SetCategory("API Examples");
                settings.SetUsesSounds(true);
                settings.SetMinimumNumberOfSounds(1);
                settings.SetMaximumNumberOfSounds(1);
                return settings;
            }
        }

        public IStep CreateStep()
        {
            return new HelloWorldStep();
        }
    }
}
