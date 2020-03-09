using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    [Binding]
    public class BrowseSolutions
    {
        private readonly ScenarioContext _context;
        private readonly UITest _test;

        public BrowseSolutions(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"the User wants to view Foundation Solutions only")]
        [Given(@"the User wants to view all Solutions")]
        public void GivenIBrowseSolutions()
        {
            _test.Pages.Homepage.ClickBrowseSolutions();
        }

        [When(@"the User chooses to view Foundation Solutions")]
        public void WhenTheUserChoosesToViewFoundationSolutions()
        {
            _test.Pages.BrowseSolutions.OpenFoundationSolutions();
        }

        [When(@"the User chooses to view all Solutions")]
        public void WhenTheUserChoosesToViewAllSolutions()
        {
            _test.Pages.BrowseSolutions.OpenAllSolutions();
            _test.Pages.CapabilityFilter.ClickCapabilityContinueButton();
        }

        [Then(@"only Foundation Solutions are presented in the results")]
        public void ThenOnlyFoundationSolutionsArePresentedInTheResults()
        {
            var numberOfSolutionCards = _test.Pages.SolutionsList.GetSolutionsCount();
            var numberOfFoundationSolutionIndicators = _test.Pages.SolutionsList.GetFoundationSolutionIndicatorCount();
            numberOfFoundationSolutionIndicators.Should().Be(numberOfSolutionCards);
        }

        [Then(@"all the Foundation Solutions are included in the results")]
        public void ThenAllTheFoundationSolutionsAreIncludedInTheResults()
        {
            var numberOfFoundationSolutionsFromDb =
                SqlExecutor.ExecuteScalar(_test.ConnectionString, Queries.GetFoundationSolutionsCount, null);
            var numberOfFoundationSolutionIndicatorsOnUi =
                _test.Pages.SolutionsList.GetFoundationSolutionIndicatorCount();
            numberOfFoundationSolutionsFromDb.Should().Be(numberOfFoundationSolutionIndicatorsOnUi);
        }

        [Then(@"all Non-Foundation Solutions are included in the results")]
        public void ThenAllNon_FoundationSolutionsAreIncludedInTheResults()
        {
            var numberOfNonFoundationSolutionsFromDb = SqlExecutor.ExecuteScalar(_test.ConnectionString,
                Queries.GetNonFoundationSolutionsCount, null);
            var numberOfFoundationSolutionsFromDb =
                SqlExecutor.ExecuteScalar(_test.ConnectionString, Queries.GetFoundationSolutionsCount, null);
            var totalNumberOfSolutionsOnUi = _test.Pages.SolutionsList.GetSolutionsCount();
            var numberOfNonFoundationsOnUI = totalNumberOfSolutionsOnUi - numberOfFoundationSolutionsFromDb;
            numberOfNonFoundationsOnUI.Should().Be(numberOfNonFoundationSolutionsFromDb);
        }
    }
}