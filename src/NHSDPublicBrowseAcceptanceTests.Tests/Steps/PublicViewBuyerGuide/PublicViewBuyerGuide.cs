using System;
using System.IO;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.PublicViewBuyerGuide
{
    [Binding]
    public class PublicViewBuyerGuide
    {
        private readonly UITest _test;

        public PublicViewBuyerGuide(UITest test, ScenarioContext context)
        {
            _test = test;
        }

        [When(@"the choose to access the Buyer Guide dedicated content page")]
        public void WhenTheChooseToAccessTheBuyerGuideDedicatedContentPage()
        {
            _test.Pages.Homepage.ClickBuyersGuideControl();
        }

        [Then(
            @"they are presented with a control to access the Buyer Guide as a digital document download \(e\.g\. a PDF\)")]
        public void ThenTheyArePresentedWithAControlToAccessTheBuyerGuideAsADigitalDocumentDownloadE_G_APDF()
        {
            _test.Pages.BuyersGuide.DownloadLinkPresented();
            var downloadLink = _test.Pages.BuyersGuide.GetDownloadLink();
            var fileName = "BuyersGuide.pdf";
            var downloadPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            Actions.Pages.Common.DownloadFile(fileName, downloadPath, downloadLink);
        }

        [Then(@"they are presented with guidance content about the Buying Catalogue")]
        public void ThenTheyArePresentedWithGuidanceContentAboutTheBuyingCatalogue()
        {
            _test.Pages.BuyersGuide.CatalogueGuidanceContentDisplayed().Should().BeTrue();
        }

        [Then(@"they are presented with guidance content about the Service Desk")]
        public void ThenTheyArePresentedWithGuidanceContentAboutTheServiceDesk()
        {
            _test.Pages.BuyersGuide.ServiceDeskGuidanceContentDisplayed().Should().BeTrue();
        }
    }
}
