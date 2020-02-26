using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps
{
    [Binding]
    public class CommonSteps
    {
        internal readonly UITest _test;
        internal readonly ScenarioContext _context;

        public CommonSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Then(@"only Solutions that deliver all the Foundation Capabilities are included")]
        [Then(@"only Solutions that deliver all of the selected Capabilities are included")]
        [Then(@"Additional Services are not included in the results")]
        public void NumberOfSolutionsShownMatchExpected()
        {
            var actualCount = _test.Pages.SolutionsList.GetSolutionsCount();
            actualCount.Should().Be(_test.expectedSolutionsCount);
        }
    }
}
