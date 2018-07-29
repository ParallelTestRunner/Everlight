using Aseem.Driver;
using Everlight.POM.Model;
using Everlight.POM.Pages.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.POM.Pages.ComputerDatabase
{
    public interface IEditOrDeleteComputerPage : IWebComponent
    {
        string ComputerName { set; }
        string Introduced { set; }
        string Discontinued { set; }
        string Company { set; }

        void DeleteThisComputer();
        void SaveThisComputer();
        void Cancel();
    }

    class EditOrDeleteComputerPage : AddANewComputerPage, IEditOrDeleteComputerPage
    {
        private EditOrDeleteComputerPageUiMap UiMap => (EditOrDeleteComputerPageUiMap)_uiMap;
        public EditOrDeleteComputerPage(ITestDriver driver, EditOrDeleteComputerPageUiMap uiMap) : base(driver, uiMap)
        { }

        public override bool IsVisible => Driver.IsVisible(UiMap.HeadingCss) && Driver.GetText(UiMap.HeadingCss) == "Edit computer";

        public void DeleteThisComputer() => Driver.Click(UiMap.DeleteButtonCss);

        public void SaveThisComputer() => Driver.Click(UiMap.SaveButtonCss);
    }

    class EditOrDeleteComputerPageUiMap : AddANewComputerPageUiMap
    {
        public string DeleteButtonCss => "input[value=\"Delete this computer\"]";
        public string SaveButtonCss => "input[value=\"Save this computer\"]";
    }

    class EditOrDeleteComputerPageFactory
    {
        public static IEditOrDeleteComputerPage GetEditOrDeleteComputerPage(ITestDriver driver) => new EditOrDeleteComputerPage(driver, new EditOrDeleteComputerPageUiMap());
    }
}
