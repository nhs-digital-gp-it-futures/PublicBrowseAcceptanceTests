﻿using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.PublicViewBuyerGuide
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
            _test.Pages.Homepage.ClickBuyersGuideControl();
        }

        [Then(@"they are presented with a control to access the Buyer Guide as a digital document download \(e\.g\. a PDF\)")]
        public void ThenTheyArePresentedWithAControlToAccessTheBuyerGuideAsADigitalDocumentDownloadE_G_APDF()
        {
            _test.Pages.BuyersGuide.DownloadLinkPresented();
            string downloadLink = _test.Pages.BuyersGuide.GetDownloadLink();
            string fileName = "BuyersGuide.pdf";
            string downloadPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            _test.Pages.Common.DownloadFile(fileName, downloadPath, downloadLink);
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
