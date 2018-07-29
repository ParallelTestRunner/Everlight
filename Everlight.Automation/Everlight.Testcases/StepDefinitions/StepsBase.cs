using Everlight.Configurations;
using Everlight.POM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Everlight.Testcases.StepDefinitions
{
    public abstract class StepsBase : Steps
    {
        protected new ScenarioContext ScenarioContext { get; private set; }
        protected WebManager WebManager { get; set; }
        protected IBrowser Browser { get { return this.WebManager.Browser; } }

        protected StepsBase(ScenarioContext scenarioContext, WebManager webManager)
        {
            this.ScenarioContext = scenarioContext;
            this.WebManager = webManager;
        }
    }
}
