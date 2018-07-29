using Aseem.Driver;
using Everlight.POM.Pages.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.POM.Pages.JavaScriptAlerts
{
    public interface IJavaScriptAlertsPage : IWebComponent
    {
        void ClickButtonByText(string text);
        string ResultMessage { get; }
    }

    class JavaScriptAlertsPage : WebComponentBase, IJavaScriptAlertsPage
    {
        private JavaScriptAlertsPageUiMap UiMap => (JavaScriptAlertsPageUiMap)_uiMap;
        public JavaScriptAlertsPage(ITestDriver driver, JavaScriptAlertsPageUiMap uiMap) : base(driver, uiMap)
        { }

        public virtual bool IsVisible => Driver.IsVisible(UiMap.HeadingCss) && Driver.GetText(UiMap.HeadingCss) == "JavaScript Alerts";

        public void ClickButtonByText(string text) => Driver.GetUICollection(UiMap.ButtonCss).ClickItemByText(text);

        public string ResultMessage => Driver.GetText(UiMap.ResultMessageCss).Trim();

    }

    class JavaScriptAlertsPageUiMap : IUIMap
    {
        public string HeadingCss => ".example > h3";

        public string ButtonCss => "li button";

        public string ResultMessageCss => ".example h4 + p";
    }

    class JavaScriptAlertsPageFactory
    {
        public static IJavaScriptAlertsPage GetJavaScriptAlertsPage(ITestDriver driver) => new JavaScriptAlertsPage(driver, new JavaScriptAlertsPageUiMap());
    }
}
