using System;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
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
            var actualCount = _test.pages.SolutionsList.GetSolutionsCount();
            actualCount.Should().Be(_test.expectedSolutionsCount);
        }
    }
}
