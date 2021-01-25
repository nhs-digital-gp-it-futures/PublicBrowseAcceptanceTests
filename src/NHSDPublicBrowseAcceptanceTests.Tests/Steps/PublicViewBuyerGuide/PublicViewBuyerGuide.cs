namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.PublicViewBuyerGuide
{
    using System;
    using System.IO;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class PublicViewBuyerGuide
    {
        private readonly UITest test;

        public PublicViewBuyerGuide(UITest test)
        {
            this.test = test;
        }

        [When(@"the choose to access the Buyer Guide dedicated content page")]
        public void WhenTheChooseToAccessTheBuyerGuideDedicatedContentPage()
        {
            test.Pages.Homepage.ClickBuyersGuideControl();
        }

        [Then(
            @"they are presented with a control to access the Buyer Guide as a digital document download \(e\.g\. a PDF\)")]
        public void ThenTheyArePresentedWithAControlToAccessTheBuyerGuideAsADigitalDocumentDownloadE_G_APDF()
        {
            test.Pages.BuyersGuide.DownloadLinkPresented();
            var downloadLink = test.Pages.BuyersGuide.GetDownloadLink();
            var fileName = "BuyersGuide.pdf";
            var downloadPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            Actions.Pages.Common.DownloadFile(fileName, downloadPath, downloadLink);
        }

        [Then(@"they are presented with guidance content about the Buying Catalogue")]
        public void ThenTheyArePresentedWithGuidanceContentAboutTheBuyingCatalogue()
        {
            test.Pages.BuyersGuide.CatalogueGuidanceContentDisplayed().Should().BeTrue();
        }

        [Then(@"they are presented with guidance content about the Service Desk")]
        public void ThenTheyArePresentedWithGuidanceContentAboutTheServiceDesk()
        {
            test.Pages.BuyersGuide.ServiceDeskGuidanceContentDisplayed().Should().BeTrue();
        }
    }
}
