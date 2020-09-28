using OpenQA.Selenium;
using System.Collections.Generic;

namespace MusalaSoftMasterWebsiteAutomationTests.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public IReadOnlyCollection<IWebElement> RightNavbarOptions => Wait.Until(d => d.FindElements(By.XPath("//ul[@class='nav navbar-nav navbar-right']//a")));

        public IWebElement MusalaSoftFooterLink => Wait.Until(d => d.FindElement(By.XPath("//div[@class='leftPartFooter']//a")));

        public IWebElement FacebookFooterLink => Wait.Until(d => d.FindElement(By.XPath("//div[@class='rightPartFooter']//a[contains(@href, 'facebook')]")));

        public IWebElement MusalaSoftLogo => Wait.Until(d => d.FindElement(By.XPath("//a[@class='brand']//span[@class='logo']")));

        public IWebElement MuffinConfFacebookProfilePic => Wait.Until(d => d.FindElement(By.XPath("//a[@aria-label='Profile picture']//img[@src='https://scontent.fsof3-1.fna.fbcdn.net/v/t1.0-1/p200x200/42965138_1113744825466495_6172932954377945088_n.jpg?_nc_cat=102&_nc_sid=dbb9e7&_nc_ohc=a2CAHLsWHrIAX8aef12&_nc_ht=scontent.fsof3-1.fna&tp=6&oh=be0b6b97c1f6f5b5f07c1156c7477dbc&oe=5F8F6515']")));

    }
}
