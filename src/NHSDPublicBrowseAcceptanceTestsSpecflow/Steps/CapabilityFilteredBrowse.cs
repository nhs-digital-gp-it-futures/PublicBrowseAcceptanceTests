using System;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public class CapabilityFilteredBrowse
    {
        private UITest _test;
        private ScenarioContext _context;

        public CapabilityFilteredBrowse(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"no Capability is selected")]
        public void GivenNoCapabilityIsSelected()
        {
            _context.Pending();
        }
        
        [Given(@"one or more Capability is selected")]
        public void GivenOneOrMoreCapabilityIsSelected()
        {
            _context.Pending();
        }
        
        [Given(@"a Capability is de-selected")]
        public void GivenACapabilityIsDe_Selected()
        {
            _context.Pending();
        }
        
        [Given(@"there is one or more Capability selected")]
        public void GivenThereIsOneOrMoreCapabilitySelected()
        {
            _context.Pending();
        }
        
        [When(@"Solutions are presented")]
        public void WhenSolutionsArePresented()
        {
            _context.Pending();
        }
        
        [Then(@"no Solutions are excluded on the basis of the Capabilities they deliver")]
        public void ThenNoSolutionsAreExcludedOnTheBasisOfTheCapabilitiesTheyDeliver()
        {
            _context.Pending();
        }
        
        [Then(@"only Solutions that deliver all of the selected Capabilities are included")]
        public void ThenOnlySolutionsThatDeliverAllOfTheSelectedCapabilitiesAreIncluded()
        {
            _context.Pending();
        }
        
        [Then(@"Additional Services are not included in the results")]
        public void ThenAdditionalServicesAreNotIncludedInTheResults()
        {
            _context.Pending();
        }
    }
}
