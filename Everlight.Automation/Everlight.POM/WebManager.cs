using Aseem.Driver;
using Everlight.Configurations;
using Everlight.POM.Pages.ComputerDatabase;
using Everlight.POM.Pages.JavaScriptAlerts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.POM
{
    public class WebManager
    {
        public IBrowser Browser { get; private set; }

        internal ITestDriver Driver { get; private set; }

        public bool IsInitialized { get { return Driver != null; } }

        public void Initialize()
        {
            if (Driver == null)
            {
                this.Browser = new Browser(this);
                OpenNewBrowserWindow();
                CreatePageObjects();
            }
        }

        public void OpenNewBrowserWindow(bool openInPrivateMode = false, string browserProfile = "")
        {
            Driver = DriverFactory.GetTestDriver("",
                                                 Config.Browser,
                                                 "",
                                                 Config.ImplicitWaitTimeOutInMilliseconds,
                                                 10000,
                                                 Config.DefaultExplilicitWaitTimeOutInMilliseconds,
                                                 Config.HighlightElementsWhenTheyAreAccessed,
                                                 Config.HighlightDurationInMilliseconds,
                                                 false,
                                                 openInPrivateMode,
                                                 browserProfile);
        }

        public void Cleanup()
        {
            Driver.Quit();
            Driver = null;
        }

        private void CreatePageObjects()
        {
            ComputerDatabase.CreatePageObjects(this);
            JavaScriptAlerts.CreatePageObjects(this);
        }

        public class ComputerDatabase
        {
            internal static void CreatePageObjects(WebManager webManager)
            {
                HomePage = ComputerDatabaseHomePageFactory.GetComputerDatabaseHomePage(webManager.Driver);
                AddANewComputerPage = AddANewComputerPageFactory.GetAddANewComputerPage(webManager.Driver);
                EditOrDeleteComputerPage = EditOrDeleteComputerPageFactory.GetEditOrDeleteComputerPage(webManager.Driver);
            }

            public static IComputerDatabaseHomePage HomePage { get; private set; }
            public static IAddANewComputerPage AddANewComputerPage { get; private set; }
            public static IEditOrDeleteComputerPage EditOrDeleteComputerPage { get; private set; }
        }

        public class JavaScriptAlerts
        {
            internal static void CreatePageObjects(WebManager webManager)
            {
                JavaScriptAlertsPage = JavaScriptAlertsPageFactory.GetJavaScriptAlertsPage(webManager.Driver);
            }

            public static IJavaScriptAlertsPage JavaScriptAlertsPage { get; private set; }
        }
    }
}
