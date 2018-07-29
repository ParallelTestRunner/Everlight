using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.Configurations
{
    public class Config
    {
        public static string ComputerDatabaseWebsiteURL { get; private set; }
        public static string JavaScriptAlertURL { get; private set; }

        public static string Browser { get; private set; }
        public static int ImplicitWaitTimeOutInMilliseconds { get; private set; }
        public static int DefaultExplilicitWaitTimeOutInMilliseconds { get; private set; }

        public static bool HighlightElementsWhenTheyAreAccessed { get; private set; }
        public static int HighlightDurationInMilliseconds { get; private set; }

        static Config()
        {
            ComputerDatabaseWebsiteURL = ConfigurationManager.AppSettings["ComputerDatabaseWebsiteURL"];
            JavaScriptAlertURL = ConfigurationManager.AppSettings["JavaScriptAlertURL"];

            Browser = ConfigurationManager.AppSettings["Browser"];
            ImplicitWaitTimeOutInMilliseconds = Convert.ToInt32(ConfigurationManager.AppSettings["ImplicitWaitTimeOutInMilliseconds"]);
            DefaultExplilicitWaitTimeOutInMilliseconds = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultExplilicitWaitTimeOutInMilliseconds"]);

            HighlightElementsWhenTheyAreAccessed = Convert.ToBoolean(ConfigurationManager.AppSettings["HighlightElementsWhenTheyAreAccessed"]);
            HighlightDurationInMilliseconds = Convert.ToInt32(ConfigurationManager.AppSettings["HighlightDurationInMilliseconds"]);
        }
    }
}
