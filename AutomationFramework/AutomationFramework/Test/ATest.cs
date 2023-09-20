using NUnit.Framework;
using OpenQA.Selenium;
using ProjectCore.Configurations;
using ProjectCore.Drivers;
using System.Xml.Serialization;

namespace ProjectCore.Test
{
    public abstract class ATest
    {
        protected abstract string TestConfigurationsFilePath { get; }

        protected TestConfigurations Configurations { get; private set; }

        protected IWebDriver Driver { get; private set; }
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TestConfigurations));
            StreamReader reader = new StreamReader(TestConfigurationsFilePath);
            Configurations = (TestConfigurations)serializer.Deserialize(reader);
            reader.Close();
            
            Driver = DriverFactory.GetDriverProvider(Configurations.DriverType);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Configurations.DefaultImplicitWaitTimeout);
        }

        [OneTimeTearDown]
        public void OnTimeTearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
