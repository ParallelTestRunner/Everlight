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
    public interface IComputerDatabaseHomePage : IWebComponent
    {
        void FilterComputersByName(string computerName);

        IEnumerable<ComputerDetail> GetAllComputers();

        void ClickComputerByName(string computerName);

        void ClickComputerByIndex(int index);

        void ClickAddANewComputerButton();

        void GoToNextPageOfComputerTable();

        String AlertMessage { get; }
    }

    class ComputerDatabaseHomePage : WebComponentBase, IComputerDatabaseHomePage
    {
        private ComputerDatabaseHomePageUiMap UiMap => (ComputerDatabaseHomePageUiMap)_uiMap;
        public ComputerDatabaseHomePage(ITestDriver driver, ComputerDatabaseHomePageUiMap uiMap) : base(driver, uiMap)
        { }

        public bool IsVisible => Driver.IsVisible(UiMap.FilterByNameButtonCss)
                                 && Driver.GetAttributeValue(UiMap.FilterByNameButtonCss, "value") == "Filter by name";

        public void FilterComputersByName(string computerName)
        {
            Driver.SendText(UiMap.SearchBoxCss, computerName);
            Driver.Click(UiMap.FilterByNameButtonCss);
        }

        private IUICollection _computersCollection;
        protected IUICollection ComputersCollection
        {
            get
            {
                if (_computersCollection == null)
                {
                    var columnsCss = new List<string>()
                    {
                        UiMap.CT_ComputerNameCss,
                        UiMap.CT_IntroducedCss,
                        UiMap.CT_DiscontinuedCss,
                        UiMap.CT_CompanyCss
                    };
                    _computersCollection = Driver.GetUICollection(columnsCss, UiMap.CT_BaseCssOfItems);
                }
                return _computersCollection;
            }
        }

        public IEnumerable<ComputerDetail> GetAllComputers() => ComputersCollection.AllItems.Select(x => new ComputerDetail(x.ElementAt(0).Trim(),
                                                                                                                            x.ElementAt(1).Trim(),
                                                                                                                            x.ElementAt(2).Trim(),
                                                                                                                            x.ElementAt(3).Trim()));

        public void ClickComputerByName(string computerName) => ComputersCollection.ClickItemByText(computerName);

        public void ClickComputerByIndex(int index) => ComputersCollection.ClickItemByIndex(index);

        public void ClickAddANewComputerButton() => Driver.Click(UiMap.AddANewComputerButtoneCss);

        public void GoToNextPageOfComputerTable() => Driver.Click(UiMap.NextPageButtoneCss);

        public String AlertMessage => Driver.GetText(UiMap.AlertMesageCss);
    }

    class ComputerDatabaseHomePageUiMap : IUIMap
    {
        public string SearchBoxCss => "#searchbox";

        public string FilterByNameButtonCss => "#searchsubmit";

        #region Computer table fields
        public string CT_BaseCssOfItems => ".computers tbody tr";

        public string CT_ComputerNameCss => "td a";
        public string CT_IntroducedCss => "td:nth-child(2)";
        public string CT_DiscontinuedCss => "td:nth-child(3)";
        public string CT_CompanyCss => "td:nth-child(4)";
        #endregion

        public string AddANewComputerButtoneCss => "#add";

        public string NextPageButtoneCss => "#pagination .next a";

        public string AlertMesageCss => ".alert-message";
    }

    class ComputerDatabaseHomePageFactory
    {
        public static IComputerDatabaseHomePage GetComputerDatabaseHomePage(ITestDriver driver) => new ComputerDatabaseHomePage(driver, new ComputerDatabaseHomePageUiMap());
    }
}
