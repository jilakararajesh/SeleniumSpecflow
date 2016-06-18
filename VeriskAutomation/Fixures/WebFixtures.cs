using TechTalk.SpecFlow;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using VeriskAutomation.Pages;
using System;


//using OpenQA.Selenium.Firefox;

namespace MozartAutomtion.Fixtures
{
    [Binding]
    public class WebFixtures
    {
        public static IWebDriver Driver;
        [BeforeFeature]
        public static void beforefeature()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Drivers"));
            Driver = new ChromeDriver(path);
            Assert.IsNotNull(Driver);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }


        [AfterScenario]
        public static void AfterScenario()
        {
            HomePage.Logout();
        }

        [AfterFeature]
        public static void afterfeature()
        {
            Driver.Quit() ;
        }

    }
}
