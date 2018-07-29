using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.POM
{
    public interface IBrowser
    {
        void OpenWebpage(string URL);
        string CurrentWindowTitle { get; }
        string CurrentWindowURL { get; }

        string GetAlertText();
        void AcceptAlert();
        void DismissAlert();
        void SendTextToAlert(string text);

        void DeleteAllCookies();
    }

    class Browser : IBrowser
    {
        private WebManager WebManager { get; set; }

        public Browser(WebManager webManager)
        {
            this.WebManager = webManager;
        }

        public void OpenWebpage(string URL)
        {
            this.WebManager.Driver.OpenURL(URL);
        }

        public string CurrentWindowTitle { get { return this.WebManager.Driver.CurrentWindowTitle; } }

        public string CurrentWindowURL { get { return this.WebManager.Driver.CurrentURL; } }

        public string GetAlertText()
        {
            return this.WebManager.Driver.GetAlertText();
        }

        public void AcceptAlert()
        {
            this.WebManager.Driver.AcceptAlert();
        }

        public void DismissAlert()
        {
            this.WebManager.Driver.DismissAlert();
        }

        public void SendTextToAlert(string text)
        {
            this.WebManager.Driver.SendTextToAlert(text);
        }

        public void DeleteAllCookies() => this.WebManager.Driver.DeleteAllCookies();
    }
}
