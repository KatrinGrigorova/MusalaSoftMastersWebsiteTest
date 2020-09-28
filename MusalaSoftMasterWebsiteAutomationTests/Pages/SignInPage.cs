using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace MusalaSoftMasterWebsiteAutomationTests.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver) { }

        public IWebElement UserName => Wait.Until(d => d.FindElement(By.Id("login-form_username")));

        public IWebElement Password => Wait.Until(d => d.FindElement(By.Id("login-form_password")));

        public IWebElement SignInButtonLoginPage => Wait.Until(d => d.FindElement(By.Id("btn-sign-in")));

        public IReadOnlyCollection<IWebElement> WrongUserOrPassMessage => Wait.Until(d => d.FindElements(By.XPath("//p[@class='state-muffin-message']"))).ToList();
        
    }
}
