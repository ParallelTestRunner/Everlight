using Everlight.Configurations;
using Everlight.POM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Everlight.Testcases.StepDefinitions.ComputerDatabase
{
    [Binding]
    public sealed class ComputerDatabaseSteps : StepsBase
    {
        public ComputerDatabaseSteps(ScenarioContext scenarioContext, WebManager webManager) : base(scenarioContext, webManager)
        { }

        [Given(@"I open the home page of computer-database website")]
        public void IOpenTheHomePageOfComputer_DatabaseWebsite()
        {
            Browser.OpenWebpage(Config.ComputerDatabaseWebsiteURL);
            Assert.IsTrue(WebManager.ComputerDatabase.HomePage.IsVisible, "Home page of computer-database-website is not loaded");
        }

        [Given(@"I make sure that there is no computer with name (.*)")]
        public void IMakeSureThatThereIsNoComputerWithGivenName(string computerName)
        {
            WebManager.ComputerDatabase.HomePage.FilterComputersByName(computerName);

            var computers = WebManager.ComputerDatabase.HomePage.GetAllComputers();

            if (computers.Any(x => x.ComputerName == computerName))
            {
                WebManager.ComputerDatabase.HomePage.ClickComputerByName(computerName);
                Assert.IsTrue(WebManager.ComputerDatabase.EditOrDeleteComputerPage.IsVisible, "Edit-or-delete-computer page is not loaded");
                WebManager.ComputerDatabase.EditOrDeleteComputerPage.DeleteThisComputer();
                Assert.IsTrue(WebManager.ComputerDatabase.HomePage.IsVisible, "Home page of computer-database-website is not loaded");
                Assert.IsTrue(WebManager.ComputerDatabase.HomePage.AlertMessage == "Done! Computer has been deleted", "\"Done! Computer has been deleted\" message is not displayed");
            }
        }

        [When(@"I go to Add-a-computer page and create a new computer with (.*), (.*), (.*) and (.*)")]
        public void IGoToAdd_A_ComputerPageAndCreateANewComputer(string computerName, string introduced, string discontinued, string company)
        {
            WebManager.ComputerDatabase.HomePage.ClickAddANewComputerButton();
            Assert.IsTrue(WebManager.ComputerDatabase.AddANewComputerPage.IsVisible, "Add-a-new-computer page is not loaded");

            WebManager.ComputerDatabase.AddANewComputerPage.ComputerName = computerName;
            WebManager.ComputerDatabase.AddANewComputerPage.Introduced = introduced;
            WebManager.ComputerDatabase.AddANewComputerPage.Discontinued = discontinued;
            WebManager.ComputerDatabase.AddANewComputerPage.Company = company;

            WebManager.ComputerDatabase.AddANewComputerPage.CreateThisComputer();
            Assert.IsTrue(WebManager.ComputerDatabase.HomePage.IsVisible, "Home page of computer-database-website is not loaded");
        }

        [Then(@"Edited computer with (.*), (.*), (.*) and (.*) could be found on home page of computer-database website")]
        [Then(@"Newly created computer with (.*), (.*), (.*) and (.*) could be found on home page of computer-database website")]
        public void ComputerCouldBeFoundOnHomePageOfComputer_DatabaseWebsite(string computerName, string introduced, string discontinued, string company)
        {
            WebManager.ComputerDatabase.HomePage.FilterComputersByName(computerName);

            var computers = WebManager.ComputerDatabase.HomePage.GetAllComputers();
            Assert.IsTrue(computers.Any(x => x.ComputerName == computerName), "Newly created computer is not found");

            var computer = computers.First(x => x.ComputerName == computerName);

            Assert.IsTrue(computer.Introduced == introduced, $"Expected introduced value:{computer.Introduced}, Actual one:{introduced}");
            Assert.IsTrue(computer.Discontinued == discontinued, $"Expected discontinued value:{computer.Discontinued}, Actual one:{discontinued}");
            Assert.IsTrue(computer.Company== company, $"Expected company name:{computer.Company}, Actual one:{company}");
        }

        [When(@"I go to a random page of computer-table")]
        public void IGoToARandomPageOfComputer_Table()
        {
            var randomPage = new Random().Next(1, 10);

            Console.WriteLine($"Randomly choosen page:{randomPage}");
            while(randomPage-- > 0)
            {
                WebManager.ComputerDatabase.HomePage.GoToNextPageOfComputerTable();
            }
        }

        [When(@"I go to edit-or-delete-computer page of a random computer and edit it with (.*), (.*), (.*) and (.*)")]
        public void IGoToEdit_Or_Delete_ComputerPageOfARandomComputer(string computerName, string introduced, string discontinued, string company)
        {
            var computers = WebManager.ComputerDatabase.HomePage.GetAllComputers();

            // Clicking a random computer
            var randomComputer = computers.ElementAt(new Random().Next(computers.Count()));
            Console.WriteLine($"Randomly choosen computer for editing:{randomComputer.ComputerName}");
            WebManager.ComputerDatabase.HomePage.ClickComputerByName(randomComputer.ComputerName);

            WebManager.ComputerDatabase.EditOrDeleteComputerPage.ComputerName = computerName;
            WebManager.ComputerDatabase.EditOrDeleteComputerPage.Introduced = introduced;
            WebManager.ComputerDatabase.EditOrDeleteComputerPage.Discontinued = discontinued;
            WebManager.ComputerDatabase.EditOrDeleteComputerPage.Company = company;

            WebManager.ComputerDatabase.EditOrDeleteComputerPage.SaveThisComputer();
            Assert.IsTrue(WebManager.ComputerDatabase.HomePage.IsVisible, "Home page of computer-database-website is not loaded");
        }

        [When(@"I delete a computer with (.*), (.*), (.*) and (.*)")]
        public void IDeleteAComputer(string computerName, string introduced, string discontinued, string company)
        {
            var computers = WebManager.ComputerDatabase.HomePage.GetAllComputers().ToList();

            var computerToBeDeleted = computers.First(x => x.ComputerName == computerName
                                                           && x.Introduced == introduced
                                                           && x.Discontinued == discontinued
                                                           && x.Company == company);

            WebManager.ComputerDatabase.HomePage.ClickComputerByIndex(computers.IndexOf(computerToBeDeleted));
            Assert.IsTrue(WebManager.ComputerDatabase.EditOrDeleteComputerPage.IsVisible, "Edit-or-delete-computer page is not loaded");
            WebManager.ComputerDatabase.EditOrDeleteComputerPage.DeleteThisComputer();
            Assert.IsTrue(WebManager.ComputerDatabase.HomePage.IsVisible, "Home page of computer-database-website is not loaded");
            Assert.IsTrue(WebManager.ComputerDatabase.HomePage.AlertMessage == "Done! Computer has been deleted", "\"Done! Computer has been deleted\" message is not displayed");
        }

        [Then(@"Deleted computer with (.*), (.*), (.*) and (.*) could be not found on home page of computer-database website")]
        public void DeletedComputerCouldBeNotFoundOnHomePageOfComputer_DatabaseWebsite(string computerName, string introduced, string discontinued, string company)
        {
            WebManager.ComputerDatabase.HomePage.FilterComputersByName(computerName);

            var computers = WebManager.ComputerDatabase.HomePage.GetAllComputers();
            Assert.IsTrue(!computers.Any(x => x.ComputerName == computerName
                                             && x.Introduced == introduced
                                             && x.Discontinued == discontinued
                                             && x.Company == company)
                                       , $"Deleted computer:{computerName} is still present");
        }
    }
}
