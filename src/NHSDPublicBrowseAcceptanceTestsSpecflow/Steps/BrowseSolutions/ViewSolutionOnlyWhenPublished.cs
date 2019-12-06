using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
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
            _context.Pending();
        }
        
        [Then(@"the Solution's Marketing Page availability is (.*)")]
        public void ThenTheSolutionSMarketingPageAvailabilityIsFalse(bool published)
        {
            _context.Pending();
        }
    }
}
