using Everlight.Configurations;
using Everlight.POM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Everlight.Testcases.StepDefinitions.JavaScriptAlerts
{
    [Binding]
    public sealed class JavaScriptAlertsSteps : StepsBase
    {
        public JavaScriptAlertsSteps(ScenarioContext scenarioContext, WebManager webManager) : base(scenarioContext, webManager)
        { }

        [Given(@"I open the JavaScript-Alerts webpage")]
        public void IOpenTheJavaScript_AlertsWebpage()
        {
            Browser.OpenWebpage(Config.JavaScriptAlertURL);
            Assert.IsTrue(WebManager.JavaScriptAlerts.JavaScriptAlertsPage.IsVisible, "JavaScript-alerts-page is not loaded");
        }

        [When(@"I click the button by text (.*)")]
        public void IClickTheButtonByText(string text)
        {
            WebManager.JavaScriptAlerts.JavaScriptAlertsPage.ClickButtonByText(text);
        }

        [When(@"I click on the ok button of alert")]
        public void IClickOnTheOkButtonOfAlert()
        {
            Browser.AcceptAlert();
        }

        [Then(@"I get the result (.*)")]
        public void IGetTheResult(string result)
        {
            Assert.IsTrue(WebManager.JavaScriptAlerts.JavaScriptAlertsPage.ResultMessage == result,
                          $"Expected result message: '{result}', Actual one:'{WebManager.JavaScriptAlerts.JavaScriptAlertsPage.ResultMessage}'");
        }

        [When(@"I click on the (.*) button of JS Prompt")]
        [When(@"I click on the (.*) button of JS Confirm")]
        public void IClickOnTheButtonOfJSConfirm(string button)
        {
            switch (button)
            {
                case "ok":
                    Browser.AcceptAlert();
                    break;

                case "cancel":
                    Browser.DismissAlert();
                    break;
            }
        }

        [When(@"I type (.*) in the text box of JS Prompt")]
        public void ITypeInTheTextBoxOfJSPrompt(string text)
        {
            Browser.SendTextToAlert(text);
        }

    }
}
