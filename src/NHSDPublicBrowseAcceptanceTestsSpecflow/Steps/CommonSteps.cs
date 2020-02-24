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

        public void CreateBlankSolution()
        {
            _test.solution = GenerateSolution.GenerateNewSolution(checkForUnique: true, connectionString: _test.connectionString);
            _test.solution.Create(_test.connectionString);
            _test.solutionDetail = GenerateSolutionDetails.GenerateNewSolutionDetail(_test.solution.Id, Guid.NewGuid(), 0, false);
            _test.solutionDetail.Create(_test.connectionString);
            _test.solution.SolutionDetailId = _test.solutionDetail.SolutionDetailId;
            _test.solution.Update(_test.connectionString);

            _context.Add("DeleteSolution", true);

            var contact = CreateContactDetails.NewContactDetail();
        }

        public CommonSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"no Capability is selected")]
        [Given(@"no other Capabilities are selected")]
        public void GivenNoOtherCapabilitiesAreSelected()
        {
            //blank
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
