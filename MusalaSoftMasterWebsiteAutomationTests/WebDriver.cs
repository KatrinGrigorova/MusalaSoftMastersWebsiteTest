using MusalaSoftMasterWebsiteAutomationTests.TestData;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace MusalaSoftMasterWebsiteAutomationTests
{
    public static class WebDriverFactory
    {
        public static IEnumerable<string> GetBrowsers()
        {
            var browsers = ConfigurationManager.AppSettings["browser"].Split(',').ToList();
            foreach (var browser in browsers)
            {
                yield return browser;
            }
        }

        public static IEnumerable<string[]> GetUserCredentials()
        {
            var browsers = ConfigurationManager.AppSettings["browser"].Split(',').ToList();
            ExcelUtil util = new ExcelUtil();
            var loginCredentials = util.GetCredentials(Path.GetFullPath(Path.Combine("TestData", "LoginCredentials.xlsx")));

            foreach (var browser in browsers)
            {
                foreach (KeyValuePair<string, string> entry in loginCredentials)
                {
                    var username = entry.Key;
                    var password = entry.Value;
                    string[] userCredential = new string[]
                    {
                        browser,
                        username,
                        password
                    };
                    yield return userCredential;
                }              
            }
        }
    }
}