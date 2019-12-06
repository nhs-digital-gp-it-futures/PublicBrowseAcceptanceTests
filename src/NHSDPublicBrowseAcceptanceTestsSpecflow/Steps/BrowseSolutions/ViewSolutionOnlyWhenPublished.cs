using FluentAssertions;
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
            _test.solution = CreateSolution.CreateNewSolution();
            _test.solution.PublishedStatusId = status;
            var guid = Guid.NewGuid();
            _test.solutionDetail = CreateSolutionDetails.CreateNewSolutionDetail(_test.solution.Id, guid, 5);

            SqlHelper.CreateBlankSolution(_test.solution, _test.solutionDetail, _test.connectionString);
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
