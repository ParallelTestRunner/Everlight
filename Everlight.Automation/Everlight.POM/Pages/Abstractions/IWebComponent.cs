using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.POM.Pages.Abstractions
{
    public interface IWebComponent
    {
        bool IsVisible { get; }
        bool WaitUntil(Func<bool> condition, int maxWaitTimeInMilliseconds = -1);
        bool WaitUntilButFailFast(Func<bool> condition, Func<bool> failFastCondition, int maxWaitTimeInMilliseconds = -1);
    }
}
