using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace MusalaSoftMasterWebsiteAutomationTests.Pages
{
    public class ArchivePage : BasePage
    {
        public ArchivePage(IWebDriver driver) : base(driver) { }

        public IReadOnlyCollection<IWebElement> ArchivedEventsList => Wait.Until(d => d.FindElements(By.XPath("//div[@id='events-cont']//div[@class='event-box-home']")));

        public IReadOnlyCollection<IWebElement> EventsTitlesList => Wait.Until(d => d.FindElements(By.XPath("//ul[@class='list-group checked-list-box']"))).ToList();
    }
}
