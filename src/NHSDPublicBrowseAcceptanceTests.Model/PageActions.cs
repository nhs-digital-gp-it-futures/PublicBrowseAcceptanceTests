using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions
{
    public sealed class PageActions
    {
        public PageActions(IWebDriver driver)
        {
            PageActionCollection = new PageActionCollection
            {
                SolutionsList = new SolutionsList(driver),
                ViewSolution = new ViewSolution(driver),
                CapabilityFilter = new CapabilityFilter(driver),
                Common = new Common(driver)
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
