using System;
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
            _context.Pending();
        }
        
        [Given(@"no other Capabilities are selected")]
        public void GivenNoOtherCapabilitiesAreSelected()
        {
            _context.Pending();
        }
        
        [Then(@"only Solutions that deliver all the Foundation Capabilities are included")]
        public void ThenOnlySolutionsThatDeliverAllTheFoundationCapabilitiesAreIncluded()
        {
            _context.Pending();
        }
    }
}
