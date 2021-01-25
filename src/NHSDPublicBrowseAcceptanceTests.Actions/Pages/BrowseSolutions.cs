namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using OpenQA.Selenium;

    public class BrowseSolutions : Interactions
    {
        public BrowseSolutions(IWebDriver driver)
            : base(driver)
        {
        }

        public void PageDisplayed()
        {
            Wait.Until(d => d.FindElement(Objects.Pages.BrowseSolutions.BrowseSolutionsHeading).Displayed);
        }

        public void WaitForPageNotToBeDisplayed()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.BrowseSolutions.BrowseFoundationSolutions).Count == 0);
        }

        public void OpenAllSolutions()
        {
            PageDisplayed();
            Wait.Until(d => d.FindElement(Objects.Pages.BrowseSolutions.BrowseAllSolutions).Displayed);
            Driver.FindElement(Objects.Pages.BrowseSolutions.BrowseAllSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public void OpenFoundationSolutions()
        {
            PageDisplayed();
            Driver.FindElement(Objects.Pages.BrowseSolutions.BrowseFoundationSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public bool CompareAllSolutionsTileIsDisplayed()
        {
            PageDisplayed();
            Wait.Until(d => d.FindElements(Objects.Pages.BrowseSolutions.CompareAllSolutions).Count > 0);
            return Driver.FindElement(Objects.Pages.BrowseSolutions.CompareAllSolutions).Displayed;
        }

        public void OpenCompareAllSolutions()
        {
            PageDisplayed();
            Driver.FindElement(Objects.Pages.BrowseSolutions.CompareAllSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }
    }
}