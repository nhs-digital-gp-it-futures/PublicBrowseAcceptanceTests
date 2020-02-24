using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.BrowseSolutions
{
    [Binding]
    public class ViewSolutionsList
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;
        int expectedNumberOfSolutions = 0;

        public ViewSolutionsList(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a User has chosen to view a list of all Solutions")]
        public void GivenThatAUserHasChosenToViewAListOfAllSolutions()
        {
            //instantiated BrowseSolutions for reuse
            var bs = new BrowseSolutions(_test, _context);
            bs.GivenIBrowseSolutions();
            bs.WhenTheUserChoosesToViewAllSolutions();
        }

        [Given(@"has not chosen to filter the solutions")]
        [When("the User chooses to continue")]
        public void GivenHasNotChosenToFilterTheSolutions()
        {
            _test.pages.CapabilityFilter.ClickCapabilityContinueButton();
        }

        [When("Solutions are presented")]
        public void SolutionsPresented()
        {

        }


        [Then(@"there is a Card for each Solution")]
        [Then("no Solutions are excluded on the basis of the Capabilities they deliver")]
        public void ThenThereIsACardForEachSolution()
        {
            expectedNumberOfSolutions = SqlExecutor.ExecuteScalar(_test.connectionString, Queries.GetSolutionsCount, null);
            var actualNumberOfSolutionCards = _test.pages.SolutionsList.GetSolutionsCount();
            actualNumberOfSolutionCards.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the Card contains the Supplier Name")]
        public void ThenTheCardContainsTheSupplierName()
        {
            var actualNumberOfSupplierNames = _test.pages.SolutionsList.GetSolutionSupplierNameCount();
            actualNumberOfSupplierNames.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the Solution Name")]
        public void ThenTheSolutionName()
        {
            var actualNumberOfSolutionNames = _test.pages.SolutionsList.GetSolutionNameCount();
            actualNumberOfSolutionNames.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the Solution Summary Description")]
        public void ThenTheSolutionSummaryDescription()
        {
            var actualNumberOfSolutionSummaries = _test.pages.SolutionsList.GetSolutionSummaryCount();
            actualNumberOfSolutionSummaries.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the names of the Capabilities provided by the Solution")]
        public void ThenTheNamesOfTheCapabilitiesProvidedByTheSolution()
        {
            var actualNumberOfSolutionCapabilitiesList = _test.pages.SolutionsList.GetSolutionCapabilityListCount();
            actualNumberOfSolutionCapabilitiesList.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"capability '(.*)' is listed in the solution capabilities")]
        public void ThenCapabilityIsListedInTheSolutionCapabilities(string expectedCapabilityName)
        {
            var dbCount = SqlExecutor.ExecuteScalar(_test.connectionString, Queries.GetSolutionsWithCapabilityCount, new { capabilityName = expectedCapabilityName});
            var uiCount = _test.pages.SolutionsList.GetSolutionsWithCapabilityCount(expectedCapabilityName);
            uiCount.Should().Be(dbCount);
        }
    }
}
