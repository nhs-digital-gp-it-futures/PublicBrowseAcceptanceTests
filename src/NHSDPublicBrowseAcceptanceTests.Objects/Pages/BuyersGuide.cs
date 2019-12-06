using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class BuyersGuide
    {
        public By DownloadButton => CustomBy.DataTestId("subsection-button", "a");

        public By CatalogueSolutionGuide => By.Id("catalogue-solution");

        public By ServiceDeskGuide => By.Id("contact-us");
    }
}
