using Microsoft.Extensions.Configuration;

namespace ProjectCore.Configurations
{
    public class Application
    {
        private static IConfigurationRoot config =  null;

        public static IConfigurationRoot Configure()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true)
                .AddEnvironmentVariables();

            config = builder.Build();
            return config;
        }

        public static IConfigurationRoot GetConfig()
        {
            return config;
        }
    }
}
