using System;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public void CreateBlankSolution()
        {
            _test.solution = CreateSolution.CreateNewSolution();
            _test.solutionDetail = CreateSolutionDetails.CreateNewSolutionDetail(_test.solution.Id, Guid.NewGuid(), 0, false);
            var contact = CreateContactDetails.NewContactDetail();
            SqlHelper.CreateBlankSolution(_test.solution, _test.solutionDetail, _test.connectionString, contact);
        }

        public CommonSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [StepDefinition(@"Solutions are presented")]
        public void SolutionsArePresented()
        {
            _test.pages.SolutionsList.WaitForSolutionToBeDisplayed();
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
