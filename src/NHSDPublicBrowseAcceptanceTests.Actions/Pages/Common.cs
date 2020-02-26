using FluentAssertions;
using OpenQA.Selenium;
using System.IO;
using System.Net;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class Common : Interactions
    {
        public Common(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Ensure the page has loaded fully
        /// note; footer is the last element to fully render
        /// </summary>
        public void WaitForPageLoad()
        {
            wait.Until(s => s.FindElement(By.ClassName("nhsuk-footer")));
        }

        /// <summary>
        /// Click the NHS logo in the header
        /// </summary>
        public void ClickLogo()
        {
            driver.FindElement(pages.Common.NHSLogo).Click();
        }

        public void PageDisplayed(string pageTitle)
        {
            driver.FindElement(pages.Common.PageTitle).Text.Should().Be(pageTitle);
        }

        public void URLContains(string href)
        {
            driver.Url.Should().Contain(href);
        }

        public string GetUrl()
        {
            return driver.Url;
        }
        public void DownloadFile(string fileName, string downloadPath, string downloadLink)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(downloadLink, Path.Combine(downloadPath, fileName));
            }
        }
    }
}