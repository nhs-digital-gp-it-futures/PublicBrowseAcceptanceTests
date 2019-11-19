using FluentAssertions;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class Homepage : Interactions
    {
        public Homepage(IWebDriver driver) : base(driver)
        {
        }

        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(pages.Homepage.Title).Displayed);
        }

        public void AboutUsSectionDisplayed()
        {
            driver.FindElement(pages.Homepage.AboutSection).Displayed.Should().BeTrue();
        }

        public void BrowseSolutionsControlDisplayed()
        {
            driver.FindElement(pages.Homepage.BrowseSolutions).Displayed.Should().BeTrue();
        }

        public void ClickBrowseSolutions()
        {
            driver.FindElement(pages.Homepage.BrowseSolutions).Click();
            wait.Until(s => s.FindElement(pages.BrowseSolutions.BrowseLinkSections).Displayed);
        }

        public void GuidanceContentControlDisplayed()
        {
            driver.FindElement(pages.Homepage.GuidanceContent).Displayed.Should().BeTrue();
        }
    }
}