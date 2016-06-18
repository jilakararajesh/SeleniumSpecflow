using VeriskAutomation;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MozartAutomtion.Fixtures;
using VeriskAutomation.TestDataSet;
using System.Threading;

namespace VeriskAutomation.Pages
{
    public class HomePage
    {
        public static bool IsHomePageDisplayed()
        {
            return WebFixtures.Driver.FindElement(By.CssSelector(UIControl.UserProfile)).Displayed;
        }

        public static void Logout()
        {
            //Thread.Sleep(3000);
            WebFixtures.Driver.FindElement(By.CssSelector(UIControl.UserProfile)).Click();
            //Thread.Sleep(3000);
            WebFixtures.Driver.FindElement(By.LinkText(UIControl.LogoutMenuOption)).Click();
        }
    }
}
