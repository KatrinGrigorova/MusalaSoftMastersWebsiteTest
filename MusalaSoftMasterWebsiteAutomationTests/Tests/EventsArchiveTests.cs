using MusalaSoftMasterWebsiteAutomationTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MusalaSoftMasterWebsiteAutomationTests
{
    [TestFixture, Parallelizable]
    public class EventsArchiveTests
    {
        public IWebDriver driver;
        private HomePage homePage;
        private ArchivePage archivePage;
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

        [Test, TestCaseSource(typeof(WebDriverFactory), "GetBrowsers")]
        public void PrintTheEventSchedule(string browser)
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
            archivePage = new ArchivePage(driver);

            //Act
            var archiveButton = homePage.RightNavbarOptions.Where(e => e.Text == "Archive").FirstOrDefault();
            archiveButton.Click();
            Thread.Sleep(2000);

            archivePage.ArchivedEventsList.LastOrDefault().Click();
            Thread.Sleep(2000);

            var titleslist = new List<string>();

            foreach (var item in archivePage.EventsTitlesList)
            {
                if (item.FindElements(By.XPath(".//div[(@class='speaker-info')]")).Count == 0)
                {
                    titleslist.Add(item.FindElement(By.XPath(".//span")).Text);
                }
                else
                {
                    var v = item.FindElement(By.XPath(".//div[(@class='speaker-info')]")).Text;
                    titleslist.Add(v.Split("\n").LastOrDefault());
                };
            }

            foreach (var item in titleslist)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
    }
}
