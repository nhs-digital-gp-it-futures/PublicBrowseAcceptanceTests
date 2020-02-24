using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.BrowseSolutions
{
    [Binding]
    public class ViewSolutionOnlyWhenPublished
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public ViewSolutionOnlyWhenPublished(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a Solution has a PublishedStatus of (.*)")]
        public void GivenThatASolutionHasAPublishedStatusOf(int status)
        {
            _test.solution = GenerateSolution.GenerateNewSolution(checkForUnique: true, connectionString: _test.connectionString, publishedStatus: status);
            _test.solution.Create(_test.connectionString);
            _test.solutionDetail = GenerateSolutionDetails.GenerateNewSolutionDetail(_test.solution.Id, Guid.NewGuid(), 0, false);
            _test.solutionDetail.Create(_test.connectionString);
            _test.solution.SolutionDetailId = _test.solutionDetail.SolutionDetailId;
            _test.solution.Update(_test.connectionString);
            new Capability().AddRandomCapabilityToSolution(_test.connectionString, _test.solution.Id);


            _test.driver.Navigate().Refresh();
        }
        
        [Then(@"the Solution's Marketing Page availability is (.*)")]
        public void ThenTheSolutionSMarketingPageAvailabilityIsFalse(bool published)
        {
            var solutions = _test.pages.SolutionsList.GetListOfSolutionNames();
            solutions.Any(s => s.Contains(_test.solution.Name)).Should().Be(published);
        }
    }
}
