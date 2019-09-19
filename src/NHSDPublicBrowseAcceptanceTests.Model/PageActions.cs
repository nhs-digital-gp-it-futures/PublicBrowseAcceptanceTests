using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace NHSDPublicBrowseAcceptanceTests.Actions
{
    public sealed class PageActions
    {
        public PageActions(IWebDriver driver, ITestOutputHelper helper)
        {
            PageActionCollection = new PageActionCollection
            {
                SolutionsList = new SolutionsList(driver, helper),
                ViewSolution = new ViewSolution(driver, helper),
                CapabilityFilter = new CapabilityFilter(driver, helper),
                Common = new Common(driver, helper)
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
