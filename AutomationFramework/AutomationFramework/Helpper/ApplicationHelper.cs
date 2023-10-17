using Microsoft.Extensions.Configuration;
using ProjectCore.Configurations;
using ProjectCore.Drivers;

namespace ProjectCore.Helpper
{
    public static class ApplicationHelper
    {
        public static List<DriverConfig> GetDriverConfigs()
        {
            var driverConfigs = Application.GetConfig().GetSection("DriverConfigs")
                            .GetChildren()
                            .ToList()
                            .Select(x => new DriverConfig
                            {
                                BrowserName = x.GetValue<string>("BrowserName"),
                                Version = x.GetValue<string>("Version"),
                                BinaryLocation = x.GetValue<string>("BinaryLocation")
                            }).ToList();

            return driverConfigs;
        }

        public static string GetApiBaseUrl()
        {
            return Application.GetConfig()["Application:ApiBaseUrl"];
        }

        public static string GetAccessToken()
        {
            return Application.GetConfig()["Application:AccessToken"];
        }
    }
}
