using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Core
{
    public static class ConfigurationsManager
    {
        public static string GetUrl()
        {
            return ConfigurationManager.AppSettings.Get("URL");
        }
        public static string GetBrowser()
        {
            if (Environment.GetEnvironmentVariable("BROWSER_VAL") != null)
            {
                return Environment.GetEnvironmentVariable("BROWSER_VAL");
            }
            else
            {
                return ConfigurationManager.AppSettings.Get("BROWSER");
            }
        }
        public static string GetHeadless()
        {
            return ConfigurationManager.AppSettings.Get("HEADLESS");
        }
    }
}
