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
            wait.Until(d => d.FindElement(Objects.Pages.BrowseSolutions.BrowseSolutionsHeading).Displayed);
        }

        public void WaitForPageNotToBeDisplayed()
        {
            wait.Until(d => d.FindElements(Objects.Pages.BrowseSolutions.BrowseFoundationSolutions).Count == 0);
        }

        public void OpenAllSolutions()
        {
            PageDisplayed();
            wait.Until(d => d.FindElement(Objects.Pages.BrowseSolutions.BrowseAllSolutions).Displayed);
            driver.FindElement(Objects.Pages.BrowseSolutions.BrowseAllSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public void OpenFoundationSolutions()
        {
            PageDisplayed();
            driver.FindElement(Objects.Pages.BrowseSolutions.BrowseFoundationSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public bool CompareAllSolutionsTileIsDisplayed()
        {
            PageDisplayed();
            wait.Until(d => d.FindElements(Objects.Pages.BrowseSolutions.CompareAllSolutions).Count > 0);
            return driver.FindElement(Objects.Pages.BrowseSolutions.CompareAllSolutions).Displayed;

        }

        public void OpenCompareAllSolutions()
        {
            PageDisplayed();
            driver.FindElement(Objects.Pages.BrowseSolutions.CompareAllSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }
    }
}