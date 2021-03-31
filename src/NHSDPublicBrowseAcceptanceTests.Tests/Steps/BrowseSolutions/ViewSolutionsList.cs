namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Helpers;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class ViewSolutionsList
    {
        private readonly UITest test;
        private int expectedNumberOfSolutions;

        public ViewSolutionsList(UITest test)
        {
            this.test = test;
        }

        [When("Solutions are presented")]
        public static void SolutionsPresented()
        {
        }

        [Given(@"that a User has chosen to view a list of all Solutions")]
        public void GivenThatAUserHasChosenToViewAListOfAllSolutions()
        {
            // instantiated BrowseSolutions for reuse
            BrowseSolutions browse = new(test);
            browse.GivenIBrowseSolutions();
            browse.WhenTheUserChoosesToViewAllSolutions();
        }

        [Given(@"has not chosen to filter the solutions")]
        [When("the User chooses to continue")]
        public void GivenHasNotChosenToFilterTheSolutions()
        {
            test.Pages.CapabilityFilter.ClickCapabilityContinueButton();
        }

        [Then(@"there is a Card for each Solution")]
        [Then("no Solutions are excluded on the basis of the Capabilities they deliver")]
        public async Task ThenThereIsACardForEachSolution()
        {
            expectedNumberOfSolutions =
                (await SqlExecutor.ExecuteAsync<Solution>(test.ConnectionString, Queries.GetAllSolutions, null)).Count();
            var actualNumberOfSolutionCards = test.Pages.SolutionsList.GetSolutionsCount();
            actualNumberOfSolutionCards.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"there is a Card for each (.*) Solution")]
        public async Task ThenThereIsACardForEachDFOCVCSolutionAsync(string framework)
        {
            expectedNumberOfSolutions =
                await SolutionHelper.RetrieveFrameworkSolutionsCountAsync(framework, test.ConnectionString);
            var actualNumberOfSolutionCards = test.Pages.SolutionsList.GetSolutionsCount();
            actualNumberOfSolutionCards.Should().Be(expectedNumberOfSolutions);
        }


        [Then(@"the Card contains the Supplier Name")]
        public void ThenTheCardContainsTheSupplierName()
        {
            var actualNumberOfSupplierNames = test.Pages.SolutionsList.GetSolutionSupplierNameCount();
            actualNumberOfSupplierNames.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the Solution Name")]
        public void ThenTheSolutionName()
        {
            var actualNumberOfSolutionNames = test.Pages.SolutionsList.GetSolutionNameCount();
            actualNumberOfSolutionNames.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the Solution Summary Description")]
        public void ThenTheSolutionSummaryDescription()
        {
            var actualNumberOfSolutionSummaries = test.Pages.SolutionsList.GetSolutionSummaryCount();
            actualNumberOfSolutionSummaries.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the names of the Capabilities provided by the Solution")]
        public void ThenTheNamesOfTheCapabilitiesProvidedByTheSolution()
        {
            var actualNumberOfSolutionCapabilitiesList = test.Pages.SolutionsList.GetSolutionCapabilityListCount();
            actualNumberOfSolutionCapabilitiesList.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"capability '(.*)' is listed in the solution capabilities")]
        public async Task ThenCapabilityIsListedInTheSolutionCapabilities(string expectedCapabilityName)
        {
            var dbCount = await SqlExecutor.ExecuteScalarAsync(
                test.ConnectionString,
                Queries.GetSolutionsWithCapabilityCount,
                new { capabilityName = expectedCapabilityName });
            var uiCount = test.Pages.SolutionsList.GetSolutionsWithCapabilityCount(expectedCapabilityName);
            uiCount.Should().Be(dbCount);
        }

        [When(@"they choose to Go Back")]
        public void WhenTheyChooseToGoBack()
        {
            test.Pages.Common.ClickGoBack();
        }

    }
}
