using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ProjectCore.Configurations
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

        public static dynamic GetTestUsers()
        {
            var testUsers = Configuration.GetSection("TestUsers")
                            .GetChildren()
                            .ToList()
                            .Select(x => new {
                                UserName = x.GetValue<string>("UserName"),
                                Email = x.GetValue<string>("Email"),
                                Password = x.GetValue<string>("Password")
                            });

            return new { Data = testUsers };
        }
    }
}
