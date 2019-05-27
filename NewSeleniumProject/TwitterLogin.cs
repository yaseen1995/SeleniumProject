using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewSeleniumProject
{
    [TestClass]
    public class TwitterLogin
    {
        [TestMethod]
        public void LoginInToTwitter()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://twitter.com/login");
            driver.Manage().Window.Maximize();

            LoginPage login = new LoginPage(driver);
            login.EnterUsername();
            login.EnterPassword();
            login.SubmitToLogin();

            Thread.Sleep(5000);
            driver.Quit();
        }

    }
}
