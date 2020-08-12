using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class BrowseSolutions : Interactions
    {
        public BrowseSolutions(IWebDriver driver) : base(driver)
        {
        }

        public void PageDisplayed()
        {
            wait.Until(d => d.FindElement(pages.BrowseSolutions.BrowseSolutionsHeading).Displayed);
        }

        public void WaitForPageNotToBeDisplayed()
        {
            wait.Until(d => d.FindElements(pages.BrowseSolutions.BrowseFoundationSolutions).Count == 0);
        }

        public void OpenAllSolutions()
        {
            PageDisplayed();
            wait.Until(d => d.FindElement(pages.BrowseSolutions.BrowseAllSolutions).Displayed);            
            driver.FindElement(pages.BrowseSolutions.BrowseAllSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public void OpenFoundationSolutions()
        {
            PageDisplayed();
            driver.FindElement(pages.BrowseSolutions.BrowseFoundationSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public bool CompareAllSolutionsTileIsDisplayed()
        {
            PageDisplayed();
            wait.Until(d => d.FindElements(pages.BrowseSolutions.CompareAllSolutions).Count > 0);
            return driver.FindElement(pages.BrowseSolutions.CompareAllSolutions).Displayed;
             
        }

        public void OpenCompareAllSolutions()
        {
            PageDisplayed();
            driver.FindElement(pages.BrowseSolutions.CompareAllSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }
    }
}