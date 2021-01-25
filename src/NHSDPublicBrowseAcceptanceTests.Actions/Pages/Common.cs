namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using System.IO;
    using System.Net;
    using FluentAssertions;
    using OpenQA.Selenium;

    public class Common : Interactions
    {
        public Common(IWebDriver driver)
            : base(driver)
        {
        }

        public static void DownloadFile(
            string fileName,
            string downloadPath,
            string downloadLink)
        {
            using var client = new WebClient();
            client.DownloadFile(downloadLink, Path.Combine(downloadPath, fileName));
        }

        /// <summary>
        ///     Ensure the page has loaded fully
        ///     note; footer is the last element to fully render
        /// </summary>
        public void WaitForPageLoad()
        {
            Wait.Until(s => s.FindElement(By.ClassName("nhsuk-footer")));
        }

        /// <summary>
        ///     Click the NHS logo in the header
        /// </summary>
        public void ClickLogo()
        {
            Driver.FindElement(Objects.Pages.Common.NHSLogo).Click();
        }

        public void PageDisplayed(string pageTitle)
        {
            Driver.FindElement(Objects.Pages.Common.PageTitle).Text.Should().Be(pageTitle);
        }

        public void URLContains(string href)
        {
            Driver.Url.Should().Contain(href);
        }

        public string GetUrl()
        {
            return Driver.Url;
        }
    }
}
