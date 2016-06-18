using MozartAutomtion.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriskAutomation.TestDataSet;

namespace VeriskAutomation.Pages
{
    public class LoginPage
    {

        public static void Get()
        {
            WebFixtures.Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["Login_URL"]);
        }

        public static void Login(string userType)
        {
            switch (userType)
            {
                case "Admin":
                    WebFixtures.Driver.FindElement(By.Id(UIControl.UserNameTextBox)).SendKeys(TestData.Admin_UserName);
                    WebFixtures.Driver.FindElement(By.Id(UIControl.PasswordTextBox)).SendKeys(TestData.Admin_Password);

                    break;
                case "Reviewer":
                    WebFixtures.Driver.FindElement(By.Id(UIControl.UserNameTextBox)).SendKeys(TestData.Reviewer_UserName);
                    WebFixtures.Driver.FindElement(By.Id(UIControl.PasswordTextBox)).SendKeys(TestData.Reviewer_Password);
                    break;
                case "Author":
                    WebFixtures.Driver.FindElement(By.Id(UIControl.UserNameTextBox)).SendKeys(TestData.Author_UserName);
                    WebFixtures.Driver.FindElement(By.Id(UIControl.PasswordTextBox)).SendKeys(TestData.Author_Password);
                    break;
            }
            WebFixtures.Driver.FindElement(By.Id(UIControl.SignInButton)).Click();
        }
    }
}
