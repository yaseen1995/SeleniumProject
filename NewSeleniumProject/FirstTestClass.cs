using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace NewSeleniumProject
{
    [TestClass]
    public class FirstTestClass
    {


        [TestMethod]
        public void LoginToTwitter()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://twitter.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//*[@id='doc']/div/div[1]/div[1]/div[2]/div[2]/div/a[2]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("js-username-field")).SendKeys("yaseen_patel");
            driver.FindElement(By.ClassName("js-password-field")).SendKeys("************");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='page-container']/div/div[1]/form/div[2]/button")).Click();
            driver.FindElement(By.ClassName("global-dm-nav")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='dm_dialog-dialog']/div[2]/div[2]/div[2]/div/div[1]/ul/li[1]/div")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tweet-box-dm-conversation']")).SendKeys("This is an automated message sent via Selenium, hope you enjoy.");
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//*[@id='dm_dialog-dialog']/div[3]/div[2]/div/div[1]/div[2]/div[3]/div[3]/form/div[3]/button")).Click();
            Thread.Sleep(10000);
            driver.Close();
            driver.Quit();

        }


        [TestMethod]

        public void SelectRadioButtonFacebook()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("u_0_6")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("u_0_7")).Click();
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();


        }

        [TestMethod]
        public void SelectTwiterCheckbox()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://twitter.com/login");
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            driver.FindElement(By.Name("Remember_me")).Click();
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();
            
        }

        [TestMethod]
        public void WikiSearchByLanguages()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            driver.Manage().Window.Maximize();
            List<String> centralLanguages = new List<String>();
            ReadOnlyCollection<IWebElement> languages = driver.FindElements(By.ClassName("central-featured-lang"));
            foreach(IWebElement language in languages)
            {
                string lang = language.Text;
                lang = lang.Substring(0, lang.LastIndexOf("\r"));
                centralLanguages.Add(lang);
            }


            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.Id("searchLanguage")));

            selectLanguage.SelectByText("Deutsch");
            selectLanguage.SelectByValue("ar");
            selectLanguage.SelectByIndex(3);


            driver.Quit();


        }

        [TestMethod]
        public void WikiSearchByTagName()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            driver.Manage().Window.Maximize();
            List<String> textforanchors = new List<String>();
            
            // We are finding all of the <a> tagnames, and storing it as a web element collection read only
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("a"));

            // Looping through each <a> tag
            foreach(IWebElement anchor in anchorLists)
            {
                // If the <a> tag text containts more than one 1 character
                if (anchor.Text.Length > 0)
                {
                    // Searches if the <a> tag text contains the text 'English'
                    if (anchor.Text.Contains("English"))
                    {
                        //Storing anchor text in a List of type string
                        textforanchors.Add(anchor.Text);
                        anchor.Click();
                    }
                }

            }

             driver.FindElement(By.Id("searchInput")).SendKeys("Selenium");
             driver.FindElement(By.XPath("//*[@id='search-form']/fieldset/button")).Click();
             driver.Close();
             driver.Quit();
        }

        [TestMethod]
        public void WikiSearch()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("searchInput")).SendKeys("Selenium");
            driver.FindElement(By.XPath("//*[@id='search-form']/fieldset/button")).Click();
        //    driver.Close();
        //    driver.Quit();
        }

        [TestMethod]
        public void ChromeMethod()
        {
            string ActualResult;
            string ExpectedResult = "Google";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            ActualResult = driver.Title;

            if(ActualResult.Contains(ExpectedResult))
            {
                Console.WriteLine("Test Case Passed");
            }

            else
            {
                Console.WriteLine("Test case Failed");
            }

            // The below is done conventionally whenever we close a test
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void FirefoxMethod()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            driver.Close();
            driver.Quit();
        }
    }
}
