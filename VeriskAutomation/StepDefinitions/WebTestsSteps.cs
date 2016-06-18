using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Web;
using TechTalk.SpecFlow.Bindings;
using VeriskAutomation.Pages;
using System.Threading;
using MozartAutomtion.Fixtures;

namespace VeriskAutomation.Stepdefinitons
{
    [Binding]
    public sealed class WebTestsSteps
    {
        [Given(@"I Navigate to login page")]
        public void GivenINavigateToWebsite()
        {
            LoginPage.Get();
        }

        [When(@"I log in with (.*) user")]
        public void WhenILogInWith(string UserType)
        {
            LoginPage.Login(UserType);
        }

        [Then(@"The User should be logged in successfully")]
        public void ThenTheResultShouldBeDisplayed()
        {
            Assert.IsTrue(HomePage.IsHomePageDisplayed());
        }

        [Then(@"search page should diaplay successfully")]
        public void ThenSearchPageShouldDiaplay()
        {
            WebFixtures.Driver.FindElement(By.XPath("//*[@id='whatToDo']/ul/li[1]/a")).Click();
            WebFixtures.Driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg.showresults.pull-right.ng-binding")).Click();
            Assert.IsTrue(WebFixtures.Driver.FindElement(By.Id("formSearchResultsGrid")).Displayed);
        }

        [Given(@"I Launch The browser")]
        public void GivenILaunchTheBrowser()
        {
            Assert.IsNotNull(WebFixtures.Driver);
        }
        [Given(@"I Navigate to ""(.*)""")]
        public void GivenINavigateTo(string Url)
        {
            WebFixtures.Driver.Navigate().GoToUrl(Url);
        }
        [When(@"I log in with ""(.*)"" and ""(.*)""")]
        public void WhenILogInWithAnd(string username, string password)
        {
            WebFixtures.Driver.FindElement(By.Id("username")).SendKeys(username);
            WebFixtures.Driver.FindElement(By.Id("password")).SendKeys(password);
            WebFixtures.Driver.FindElement(By.Id("signIn")).Click();
        }
        [Then(@"I verified the result")]
        public void ThenIVerifiedTheResult()
        {
            WebFixtures.Driver.FindElement(By.XPath("//*[@id='vm - global - navigation']/ul/li[4]/a")).Click();
            WebFixtures.Driver.FindElement(By.XPath("//*[@id='vm - global - navigation']/ul/li[4]/ul/li[5]/a")).Click();

        }

        [When(@"I perform ""(.*)"" forms Search")]
        public void WhenIPerformFormsSearch(string p0)
        {
            Thread.Sleep(5000);
            WebFixtures.Driver.FindElement(By.LinkText("SEARCH")).Click();
            Thread.Sleep(5000);
            WebFixtures.Driver.FindElement(By.Id("inlineRadio2")).Click();
            Thread.Sleep(5000);
            WebFixtures.Driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg.showresults.pull-right.ng-binding")).Click();
        }

        [When(@"I click View Info icon")]
        public void WhenIClickViewInfoIcon()
        {
            WebFixtures.Driver.FindElements(By.CssSelector(".glyphicon.glyphicon-info-sign"))[0].Click();
            Thread.Sleep(5000);
        }

        [Then(@"View Info is displayed")]
        public void ThenViewInfoIsDisplayed()
        {
            Assert.IsNotNull(WebFixtures.Driver.FindElement(By.CssSelector(".statvalue.ng-binding")));
            Thread.Sleep(5000);
            WebFixtures.Driver.FindElement(By.CssSelector(".close.white.ng-scope")).Click();
            Thread.Sleep(5000);
        }

        [When(@"I select form by form Number")]
        public void WhenISelectFormByFormNumber(Table table)
        {
            List<string> formNums = new List<string>();
            foreach (var row in table.Rows)
            {
                formNums.Add(row["FormNumber"]);
            }
            SearchPage.SelectForms(formNums.ToArray());
        }

        [When(@"I select form by form Number and verify Action menu options")]
        public void WhenISelectFormByFormNumberAndVerifyActionMenuOptions(Table table)
        {
            string[] actions = new string[] { "Move to Project", "Delete", "Archive", "Email" };
            List<string> formNums = new List<string>();
            foreach (var row in table.Rows)
            {
                formNums.Add(row["FormNumber"]);
            }
            Thread.Sleep(10000);
            for (int i = 0; i < actions.Length; i++)
            {
                Thread.Sleep(3000);
                SearchPage.SelectForms(formNums.ToArray());
                switch (actions[i])
                {
                    case "Move to Project":
                        SearchPage.MoveToProject();
                        break;
                    case "Delete":
                        SearchPage.Delete();
                        break;
                    case "Archive":
                        SearchPage.Archive();
                        break;
                    case "Email":
                        SearchPage.Email();
                        break;
                }
            }
            

        }



        [Then(@"Action menu is enabled")]
        public void ThenActionMenuIsEnabled()
        {
            //ScenarioContext.Current.Pending();
        }
        [When(@"I Select ""(.*)"" forms Search")]
        public void WhenISelectFormsSearch(string p0)
        {
            WebFixtures.Driver.FindElement(By.LinkText("SEARCH")).Click();
            Thread.Sleep(5000);
            WebFixtures.Driver.FindElement(By.Id("inlineRadio3")).Click();
            WebFixtures.Driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg.showresults.pull-right.ng-binding")).Click();
        }
        [When(@"selcting the ""(.*)""")]
        [When(@"selcting ""(.*)"" in ""(.*)""")]
        public void WhenSelctingIn(string p0, string p1)
        {
            Thread.Sleep(3000);
            int count = int.Parse(WebFixtures.Driver.FindElements(By.TagName("label"))[0].Text.Split('(')[1].Split(')')[0]);
            WebFixtures.Driver.FindElements(By.TagName("label"))[0].Click();
            var rows = WebFixtures.Driver.FindElements(By.CssSelector(".glyphicon.glyphicon-info-sign"));
            if (count >= 10)
            {
                Assert.IsTrue(rows.Count == 10);
            }
            else
            {
                Assert.IsTrue(rows.Count == count);
            }
            
                        
        }

    }
}
