using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSeleniumProject
{
    class LoginPage
    {
        IWebDriver driver;
        By username = By.ClassName("js-username-field");
        By password = By.ClassName("js-password-field");
        By loginBtn = By.XPath("//*[@id='page-container']/div/div[1]/form/div[2]/button");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUsername()
        {
            driver.FindElement(username).SendKeys("yaseen_patel");

        }

        public void EnterPassword()
        {
            driver.FindElement(password).SendKeys("***********");

        }

        public void SubmitToLogin()
        {
            driver.FindElement(loginBtn).Click();

        }

    }
}

