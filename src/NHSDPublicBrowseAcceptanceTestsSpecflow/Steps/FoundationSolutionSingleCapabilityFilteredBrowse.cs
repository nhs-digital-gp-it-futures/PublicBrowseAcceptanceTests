using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public class FoundationSolutionSingleCapabilityFilteredBrowse
    {
        private UITest _test;
        private ScenarioContext _context;

        public FoundationSolutionSingleCapabilityFilteredBrowse(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"all the Foundation Capabilities are selected")]
        public void GivenAllTheFoundationCapabilitiesAreSelected()
        {
            _test.pages.CapabilityFilter.FoundationSolutionsFilter();
            _test.expectedSolutionsCount = _test.pages.SolutionsList.GetSolutionsCount();
        }
    }
}
