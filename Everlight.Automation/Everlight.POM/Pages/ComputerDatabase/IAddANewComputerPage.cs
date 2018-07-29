using Aseem.Driver;
using Everlight.POM.Pages.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.POM.Pages.ComputerDatabase
{
    public interface IAddANewComputerPage : IWebComponent
    {
        string ComputerName { set; }
        string Introduced { set; }
        string Discontinued { set; }
        string Company { set; }

        void CreateThisComputer();
        void Cancel();
    }

    class AddANewComputerPage : WebComponentBase, IAddANewComputerPage
    {
        private AddANewComputerPageUiMap UiMap => (AddANewComputerPageUiMap)_uiMap;
        public AddANewComputerPage(ITestDriver driver, AddANewComputerPageUiMap uiMap) : base(driver, uiMap)
        { }

        public virtual bool IsVisible => Driver.IsVisible(UiMap.HeadingCss) && Driver.GetText(UiMap.HeadingCss) == "Add a computer";

        public string ComputerName { set => Driver.SendText(UiMap.ComputerNameCss, value); }

        public string Introduced { set => Driver.SendText(UiMap.IntroducedCss, value); }

        public string Discontinued { set => Driver.SendText(UiMap.DiscontinuedCss, value); }

        protected IUICollection CompanyNameCollection => Driver.GetUICollection(UiMap.CompanyDropdownCss);
        public string Company { set => CompanyNameCollection.SelectItemByTextOnSelectControl(value); }

        public void CreateThisComputer() => Driver.Click(UiMap.CreateButtonCss);

        public void Cancel() => Driver.Click(UiMap.CancelButtonCss);
    }

    class AddANewComputerPageUiMap : IUIMap
    {
        public string HeadingCss => "#main > h1";

        public string ComputerNameCss => "#name";
        public string IntroducedCss => "#introduced";
        public string DiscontinuedCss => "#discontinued";
        public string CompanyDropdownCss => "#company option";

        public string CreateButtonCss => "input[value=\"Create this computer\"]";
        public string CancelButtonCss => "a.btn";
    }

    class AddANewComputerPageFactory
    {
        public static IAddANewComputerPage GetAddANewComputerPage(ITestDriver driver) => new AddANewComputerPage(driver, new AddANewComputerPageUiMap());
    }
}
