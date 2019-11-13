using FluentAssertions;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public class NoSelectionCriteriaBrowse
    {
        private UITest _test;
        private ScenarioContext _context;
        private int solutionsCount;

        public NoSelectionCriteriaBrowse(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that Solutions are presented")]
        [Given(@"no selection criteria are applied")]
        [When(@"no selection criteria are applied")]
        public void GivenNoSelectionCriteriaAreApplied()
        {
            _test.pages.SolutionsList.WaitForSolutionToBeDisplayed();
        }

        [Then(@"no Solutions are excluded")]
        public void ThenNoSolutionsAreExcluded()
        {
            _test.pages.SolutionsList.GetSolutionsCount().Should().Be(solutionsCount);
        }

        [Then(@"the Card will contain the correct contents")]
        public void ThenTheCardWillContainTheCorrectContents()
        {
            _test.pages.SolutionsList.SolutionHasCapabilities().Should().BeTrue();
            _test.pages.SolutionsList.SolutionHasTitle().Should().BeTrue();
            _test.pages.SolutionsList.SolutionHasSummary().Should().BeTrue();
        }
    }
}
