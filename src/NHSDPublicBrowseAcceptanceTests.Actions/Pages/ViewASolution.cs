using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class ViewASolution : Interactions
    {
        public ViewASolution(IWebDriver driver) : base(driver)
        {
        }

        public void PageDisplayed(string url)
        {
            // Should be a better way to do this that doesn't rely on RegEx matching
            Regex.Match(driver.Url, $@"{url}/solutions/(capabilities-selector.*|foundation)/.*").Success.Should()
                .BeTrue();
        }

        public string GetSolutionId()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionId).Text.Replace("Solution ID: ", "");
        }

        public void SupplierNameDisplayed()
        {
            driver.FindElement(pages.ViewSingleSolution.SolutionSupplierName).Displayed.Should().BeTrue();
        }

        public string GetSolutionName()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionName).Text;
        }

        public string GetSolutionSummary()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionSummary).Text;
        }

        public string GetSolutionLastUpdated()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionLastUpdated).Text
                .Replace("Solution information last updated: ", "");
        }

        public string GetSolutionAboutUrl()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionAboutUrl).Text;
        }

        public IList<string> GetFeatures()
        {
            return driver.FindElements(pages.ViewSingleSolution.Features).Select(s => s.Text).ToList();
        }

        public bool CapabilitiesListDisplayed()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionCapabilities).Displayed;
        }

        public bool AttachmentDownloadLinkDisplayed()
        {
            return driver.FindElements(pages.ViewSingleSolution.AttachmentDownloadLink).Count > 0;
        }

        public bool NhsAssuredIntegrationsDownloadLinkDisplayed()
        {
            return driver.FindElements(pages.ViewSingleSolution.DownloadNHSAssuredIntegrationsDocumentLink).Count > 0;
        }

        public bool RoadmapDownloadLinkDisplayed()
        {
            return driver.FindElements(pages.ViewSingleSolution.DownloadRoadmapDocumentLink).Count > 0;
        }

        public bool FoundationSolutionIndicatorDisplayed()
        {
            return driver.FindElement(pages.ViewSingleSolution.FoundationSolutionIndicator).Displayed;
        }

        public IList<string> GetSolutionCapabilities()
        {
            var capabilities = driver.FindElements(pages.ViewSingleSolution.SolutionCapabilities)
                .Select(s => s.FindElement(pages.ViewSingleSolution.CapabilityTitle).Text)
                .Select(s => s.Split(',')[0])
                .ToList();
            return capabilities;
        }

        public string GetAttachmentDownloadLinkUrl()
        {
            return driver.FindElement(pages.ViewSingleSolution.AttachmentDownloadLink).GetAttribute("href");
        }

        public string GetNhsAssuredIntegrationsDownloadLinkUrl()
        {
            return driver.FindElement(pages.ViewSingleSolution.DownloadNHSAssuredIntegrationsDocumentLink)
                .GetAttribute("href");
        }

        public string GetRoadmapDownloadLinkUrl()
        {
            return driver.FindElement(pages.ViewSingleSolution.DownloadRoadmapDocumentLink)
                .GetAttribute("href");
        }

        public string GetSolutionFullDescription()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionFullDescription).Text;
        }

        public SolutionContactDetails GetSolutionContactDetails()
        {
            var contactDetails = new SolutionContactDetails
            {
                FirstName = driver.FindElement(pages.ViewSingleSolution.SolutionContactName).Text.Split(' ')[0],
                LastName = driver.FindElement(pages.ViewSingleSolution.SolutionContactName).Text.Split(' ')[1],
                Department = driver.FindElement(pages.ViewSingleSolution.SolutionContactDepartment).Text,
                PhoneNumber = driver.FindElement(pages.ViewSingleSolution.SolutionContactPhoneNumber).Text,
                Email = driver.FindElement(pages.ViewSingleSolution.SolutionContactEmail).Text
            };

            return contactDetails;
        }

        public void WaitForRoadmapSectionDisplayed()
        {
            wait.Until(s =>
            {
                s.Navigate().Refresh();
                return s.FindElement(pages.ViewSingleSolution.RoadmapSection).Displayed;
            });
        }

        public void WaitForIntegrationsSectionDisplayed()
        {
            wait.Until(s =>
            {
                s.Navigate().Refresh();
                return s.FindElement(pages.ViewSingleSolution.IntegrationsSection).Displayed;
            });
        }

        public bool WaitForLearnMoreSectionDisplayed()
        {
            try
            {
                wait.Until(s =>
                {
                    s.Navigate().Refresh();
                    return s.FindElement(pages.ViewSingleSolution.LearnMoreSection).Displayed;
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}