using ProjectCore.Drivers;

namespace ProjectCore.Configurations
{
    [Serializable()]
    public class TestConfigurations
    {
        public string AppUrl { get; set; }
        public DriverType DriverType { get; set; }
        public int DefaultImplicitWaitTimeout { get; set; }
    }
}