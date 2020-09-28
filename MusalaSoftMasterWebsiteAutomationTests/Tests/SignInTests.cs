using MusalaSoftMasterWebsiteAutomationTests.Pages;
using MusalaSoftMasterWebsiteAutomationTests.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MusalaSoftMasterWebsiteAutomationTests
{
    [TestFixture, Parallelizable]
    public class SignInTests
    {
        public IWebDriver driver;
        private HomePage homePage;
        private SignInPage signInPage;
        String url = "";

        [SetUp]
        public void SetUp()
        {
            url = ConfigurationManager.AppSettings["url"];
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test, TestCaseSource(typeof(WebDriverFactory), "GetUserCredentials")]
        public void When_SigningInWithInvalidCredential_Then_AnErrorMessageAppears(string browser, string username, string password)
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
            signInPage = new SignInPage(driver);
            ExcelUtil util = new ExcelUtil();

            //Act
            var signInButton = homePage.RightNavbarOptions.Where(e => e.Text == "Sign In").FirstOrDefault();
            signInButton.Click();

            signInPage.UserName.SendKeys(username);

            signInPage.Password.SendKeys(password);

            signInPage.SignInButtonLoginPage.Click();

            var errorMessage = signInPage.WrongUserOrPassMessage.Where(x => x.Text == "Wrong user or password.").FirstOrDefault().Displayed;

            //Assert
            Assert.IsTrue(errorMessage, "The error message for wrong username or password doesn't appear.");            
        }
    }
}
