using Aseem.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.POM.Pages.Abstractions
{
    abstract class WebComponentBase
    {
        protected ITestDriver Driver { get; private set; }

        protected IUIMap _uiMap;
        protected WebComponentBase(ITestDriver driver, IUIMap uiMap)
        {
            this.Driver = driver;
            _uiMap = uiMap;
        }

        public bool WaitUntil(Func<bool> condition, int maxWaitTimeInMilliseconds = -1)
        {
            return Driver.WaitUntil(condition, maxWaitTimeInMilliseconds);
        }

        public bool WaitUntilButFailFast(Func<bool> condition, Func<bool> failFastCondition, int maxWaitTimeInMilliseconds = -1)
        {
            return Driver.WaitUntilButFailFast(condition, failFastCondition, maxWaitTimeInMilliseconds);
        }

        protected void SendTextToTextArea(string textareaCss, string text) => Driver.GetUICollection(textareaCss).SendTextToItemByIndex(text);

        protected void WaitForItemToGetLoaded(IUICollection uiCollection, string itemCss, int indexOfTheItem = 0, int waitTimeInMilliseconds = 5000)
        {
            Driver.WaitUntil(() => uiCollection.Count > 0 && uiCollection.GetItemByIndex(indexOfTheItem, itemCss) != null, waitTimeInMilliseconds);
        }
    }
}
