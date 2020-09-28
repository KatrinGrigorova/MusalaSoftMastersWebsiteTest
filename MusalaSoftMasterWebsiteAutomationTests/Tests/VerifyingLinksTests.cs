using MusalaSoftMasterWebsiteAutomationTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MusalaSoftMasterWebsiteAutomationTests
{
    [TestFixture, Parallelizable]
    public class VerifyingLinksTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        String url = "";

        [SetUp]
        public void OneTimeSetUp()
        {
            url = ConfigurationManager.AppSettings["url"];
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test, TestCaseSource(typeof(WebDriverFactory), "GetBrowsers")]
        public void When_ClickOnMusalaSoftFooterLink_Then_CorrectURLLoads(string browser)
        {
            //Arrange
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "firefox":
                    driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
            }

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver);
            var expectedURL = "http://www.musala.com/";

            //Act
            homePage.MusalaSoftFooterLink.Click();
            Thread.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            var currentURL = driver.Url;

            //Assert
            Assert.AreEqual(expectedURL, currentURL, "The loaded URL is not correct.");
        }

        [Test, TestCaseSource(typeof(WebDriverFactory), "GetBrowsers")] 
        public void When_GoToMusalaSoftWebsite_Then_CompanyLogoAppears(string browser)
        {
            //Arrange
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "firefox":
                    driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
            }

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver);

            //Act
            homePage.MusalaSoftFooterLink.Click();
            Thread.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var isLogoDisplayed = homePage.MusalaSoftLogo.Displayed;

            //Assert
            Assert.IsTrue(isLogoDisplayed, "The logo is not displayed.");
        }

        [Test, TestCaseSource(typeof(WebDriverFactory), "GetBrowsers")] 
        public void When_ClickOnFacebookFooterLink_Then_CorrectURLLoads(string browser)
        {
            //Arrange
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "firefox":
                    driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
            }

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver);
            var expectedURL = "https://www.facebook.com/MUFFINconference/";

            //Act
            homePage.FacebookFooterLink.Click();
            Thread.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var currentURL = driver.Url;

            //Assert
            Assert.AreEqual(expectedURL, currentURL, "The loaded URL is not correct.");
        }

        [Test, TestCaseSource(typeof(WebDriverFactory), "GetBrowsers")]
        public void When_GoToMuffinConfFacebookPage_Then_MuffinConfProfilePictureAppears(string browser)
        {
            //Arrange
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "firefox":
                    driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
            }

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver);

            //Act
            homePage.FacebookFooterLink.Click();
            Thread.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var isProfilePictureDisplayed = homePage.MuffinConfFacebookProfilePic.Displayed;

            //Assert
            Assert.IsTrue(isProfilePictureDisplayed, "The profile picture is not displayed.");
        }
    }
}
