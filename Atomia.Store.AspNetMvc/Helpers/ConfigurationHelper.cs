using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Atomia.Store.AspNetMvc.Helpers
{
    public static class ConfigurationHelper
    {
        public static string ReadConfigurationOption(string configurationKey, string fallbackValue = null)
        {
            if (HttpContext.Current.Application.AllKeys.Contains(configurationKey))
            {
                var value = HttpContext.Current.Application[configurationKey].ToString();
                return value;
            } 
            return fallbackValue;
        }

        public static string GetDnsPackageArticleNumber()
        {
            return ReadConfigurationOption("DnsPackageArticleNumber", "DNS-PK");
        }
    }
}
