using System;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.PublicViewBuyerGuide
{
    [Binding]
    public class PublicViewBuyerGuide
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public PublicViewBuyerGuide(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [When(@"the choose to access the Buyer Guide dedicated content page")]
        public void WhenTheChooseToAccessTheBuyerGuideDedicatedContentPage()
        {
            _context.Pending();
        }
        
        [Then(@"they can do so via a control on the Homepage")]
        public void ThenTheyCanDoSoViaAControlOnTheHomepage()
        {
            _context.Pending();
        }
        
        [Then(@"they can do so via a control in the Footer")]
        public void ThenTheyCanDoSoViaAControlInTheFooter()
        {
            _context.Pending();
        }
        
        [Then(@"they are presented with a control to access the Buyer Guide as a digital document download \(e\.g\. a PDF\)")]
        public void ThenTheyArePresentedWithAControlToAccessTheBuyerGuideAsADigitalDocumentDownloadE_G_APDF()
        {
            _context.Pending();
        }
        
        [Then(@"they are presented with guidance content about the Buying Catalogue")]
        public void ThenTheyArePresentedWithGuidanceContentAboutTheBuyingCatalogue()
        {
            _context.Pending();
        }
        
        [Then(@"they are presented with guidance content about the Service Desk")]
        public void ThenTheyArePresentedWithGuidanceContentAboutTheServiceDesk()
        {
            _context.Pending();
        }
    }
}
