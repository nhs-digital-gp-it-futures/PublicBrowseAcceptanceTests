using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
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
            _test.solution = GenerateSolution.GenerateNewSolution(checkForUnique: true, connectionString: _test.ConnectionString, publishedStatus: status);
            _test.solution.Create(_test.ConnectionString);
            _test.solutionDetail = GenerateSolutionDetails.GenerateNewSolutionDetail(_test.solution.Id, Guid.NewGuid(), 0, false);
            _test.solutionDetail.Create(_test.ConnectionString);
            _test.solution.SolutionDetailId = _test.solutionDetail.SolutionDetailId;
            _test.solution.Update(_test.ConnectionString);
            _context.Add("DeleteSolution", true);
            new Capability().AddRandomCapabilityToSolution(_test.ConnectionString, _test.solution.Id);


            _test.driver.Navigate().Refresh();
        }

        [Then(@"the Solution's Marketing Page availability is (.*)")]
        public void ThenTheSolutionSMarketingPageAvailabilityIsFalse(bool published)
        {
            var solutions = _test.Pages.SolutionsList.GetListOfSolutionNames();
            solutions.Any(s => s.Contains(_test.solution.Name)).Should().Be(published);
        }
    }
}
