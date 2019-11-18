using FluentAssertions;
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
            _context.Pending();
            //get count from DB
            //get count from UI
            //should equal
        }
        
        [Then(@"all Foundation Solutions are presented in the results")]
        public void ThenAllFoundationSolutionsArePresentedInTheResults()
        {
            var numberOfSolutionCards = _test.pages.SolutionsList.GetSolutionsCount();
            var numberOfFoundationSolutionIndicators = _test.pages.SolutionsList.GetFoundationSolutionIndicatorCount();
            numberOfFoundationSolutionIndicators.Should().BeGreaterThan(0);
            numberOfSolutionCards.Should().BeGreaterThan(numberOfFoundationSolutionIndicators);
        }
        
        [Then(@"all Non-Foundation Solutions are included in the results")]
        public void ThenAllNon_FoundationSolutionsAreIncludedInTheResults()
        {
            _context.Pending();
        }
    }
}
