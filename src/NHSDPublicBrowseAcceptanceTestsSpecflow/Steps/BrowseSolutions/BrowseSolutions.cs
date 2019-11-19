using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.BrowseSolutions
{
    [Binding]
    public class BrowseSolutions
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public BrowseSolutions(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"the User wants to view Foundation Solutions only")]
        [Given(@"the User wants to view all Solutions")]
        public void GivenTheUserWantsToViewFoundationSolutionsOnly()
        {
            _test.pages.Homepage.ClickBrowseSolutions(); 
        }
        
        [When(@"the User chooses to view Foundation Solutions")]
        public void WhenTheUserChoosesToViewFoundationSolutions()
        {
            _test.pages.BrowseSolutions.OpenFoundationSolutions();
        }
        
        [When(@"the User chooses to view all Solutions")]
        public void WhenTheUserChoosesToViewAllSolutions()
        {
            _test.pages.BrowseSolutions.OpenAllSolutions();
        }
        
        [Then(@"only Foundation Solutions are presented in the results")]
        public void ThenOnlyFoundationSolutionsArePresentedInTheResults()
        {
            var numberOfSolutionCards = _test.pages.SolutionsList.GetSolutionsCount();
            var numberOfFoundationSolutionIndicators = _test.pages.SolutionsList.GetFoundationSolutionIndicatorCount();
            numberOfFoundationSolutionIndicators.Should().Be(numberOfSolutionCards);
        }
        
        [Then(@"all the Foundation Solutions are included in the results")]
        public void ThenAllTheFoundationSolutionsAreIncludedInTheResults()
        {
            var numberOfFoundationSolutionsFromDb = SqlHelper.GetNumberOfFoundationSolutions(_test.connectionString);
            var numberOfFoundationSolutionIndicatorsOnUi = _test.pages.SolutionsList.GetFoundationSolutionIndicatorCount();
            numberOfFoundationSolutionsFromDb.Should().Be(numberOfFoundationSolutionIndicatorsOnUi);

        }
        
        [Then(@"all Non-Foundation Solutions are included in the results")]
        public void ThenAllNon_FoundationSolutionsAreIncludedInTheResults()
        {
            var numberOfNonFoundationSolutionsFromDb = SqlHelper.GetNumberOfNonFoundationSolutions(_test.connectionString);
            var numberOfFoundationSolutionsFromDb = SqlHelper.GetNumberOfFoundationSolutions(_test.connectionString);
            var totalNumberOfSolutionsOnUi = _test.pages.SolutionsList.GetSolutionsCount();
            var numberOfNonFoundationsOnUI = totalNumberOfSolutionsOnUi - numberOfFoundationSolutionsFromDb;
            numberOfNonFoundationsOnUI.Should().Be(numberOfNonFoundationSolutionsFromDb);
        }
    }
}
