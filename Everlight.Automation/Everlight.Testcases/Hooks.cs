using Everlight.POM;
using Everlight.Testcases.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Everlight.Testcases
{
    [Binding]
    public sealed class Hooks : StepsBase
    {
        public Hooks(ScenarioContext scenarioContext, WebManager webManager) : base(scenarioContext, webManager)
        { }

        [BeforeScenario]
        public void BeforeScenarioRun()
        {
            // Initializing WebManager if its not already
            if (!this.WebManager.IsInitialized)
            {
                this.WebManager.Initialize();
            }
        }

        [AfterScenario]
        public void AfterScenarioRun()
        {
            if (this.ScenarioContext.TestError != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Test case failed on URL: '{Browser.CurrentWindowURL}'");
            }

            this.WebManager.Cleanup();
        }
    }
}
