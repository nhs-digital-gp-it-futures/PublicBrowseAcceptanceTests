using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class BrowseSolutions : Interactions
    {
        public BrowseSolutions(IWebDriver driver) : base(driver)
        {
        }

        public void OpenAllSolutions()
        {
            driver.FindElement(pages.BrowseSolutions.BrowseAllSolutions).Click();
        }

        public void OpenFoundationSolutions()
        {
            driver.FindElement(pages.BrowseSolutions.BrowseFoundationSolutions).Click();
        }
    }
}