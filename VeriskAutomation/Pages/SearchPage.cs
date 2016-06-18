using MozartAutomtion.Fixtures;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VeriskAutomation.Pages
{  
    public static class SearchPage
    {

        private static int[] GetFormsIndexByNumber(string[] formNumbers)
        {
            ReadOnlyCollection<IWebElement> list = WebFixtures.Driver.FindElements(By.PartialLinkText("IL"));
            List<int> indexes = new List<int>();
            for (int form = 0; form < list.Count; form++)
            {
                for (int formNum = 0; formNum < formNumbers.Length; formNum++)
                {
                    if (list[form].Text.Replace(" ","") == formNumbers[formNum].Replace(" ", ""))
                    {
                        indexes.Add(form);
                    }
                }
            }
            return indexes.ToArray();
        }

        private static void SelectFormsByIndexes(int[] indexes)
        {
            ReadOnlyCollection<IWebElement> Checkboxes = WebFixtures.Driver.FindElements(By.CssSelector(".ui-grid-selection-row-header-buttons.ui-grid-icon-ok.ng-scope"));
            for (int i = 0; i < indexes.Length; i++)
            {
                Checkboxes[indexes[i]+1].Click();
            }
        }

        public static void SelectForms(string[] formNumbers)
        {
            SelectFormsByIndexes(GetFormsIndexByNumber(formNumbers));
      }

        public static void MoveToProject()
        {
            WebFixtures.Driver.FindElement(By.CssSelector(".btn.btn-primary.dropdown-toggle.ng-binding")).Click();
            WebFixtures.Driver.FindElement(By.LinkText("Move to Project")).Click();
            //WebFixtures.Driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            WebFixtures.Driver.FindElement(By.XPath("//button[contains(text(),'Cancel')]")).Click();

        }
        public static void Delete()
        {
            //Assert.IsNotNull(SearchPage.SelectForms());
            WebFixtures.Driver.FindElement(By.CssSelector(".btn.btn-primary.dropdown-toggle.ng-binding")).Click();
            WebFixtures.Driver.FindElement(By.LinkText("Delete")).Click();
            //Assert.IsNotNull(WebFixtures.Driver.FindElement(By.ClassName("close white")));
            WebFixtures.Driver.FindElement(By.XPath("//span[contains(text(),'Ok')]")).Click();

        }
        public static void Archive()
        {
            //Assert.IsNotNull(SearchPage.SelectForms());
            WebFixtures.Driver.FindElement(By.CssSelector(".btn.btn-primary.dropdown-toggle.ng-binding")).Click();
            WebFixtures.Driver.FindElement(By.LinkText("Archive")).Click();
            //Assert.IsNotNull(WebFixtures.Driver.FindElement(By.ClassName("close white")));
            WebFixtures.Driver.FindElement(By.CssSelector(".btn.ng-scope.btn-default")).Click();
        }
        public static void Email()
        {
            //Assert.IsNotNull(SearchPage.SelectForms());
            WebFixtures.Driver.FindElement(By.CssSelector(".btn.btn-primary.dropdown-toggle.ng-binding")).Click();
            //Assert.IsNotNull(WebFixtures.Driver.FindElement(By.ClassName("close white")));
            WebFixtures.Driver.FindElement(By.LinkText("Email")).Click();
            Thread.Sleep(3000);
            WebFixtures.Driver.FindElement(By.CssSelector(".close.white.ng-scope")).Click();
        }
    }
}
