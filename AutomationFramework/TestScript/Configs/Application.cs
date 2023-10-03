using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace TestScript.Configs
{
    public class Application
    {
        private static IConfiguration Configuration = null;


        public static IConfiguration Configure()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables();

            Configuration = builder.Build();
            return Configuration;
        }

        public static IConfiguration GetConfig()
        {
            return Configuration;
        }
    }
}
