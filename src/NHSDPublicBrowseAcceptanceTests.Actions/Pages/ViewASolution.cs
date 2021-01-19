using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            var actual = driver.Url;
            var expectedPattern = $@"{url}/solutions/(capabilities-selector.*|foundation)/*";
            Regex.Match(actual, expectedPattern).Success.Should()
                .BeTrue();
        }

        public string GetSolutionId()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionId).Text.Replace("Solution ID: ", "");
        }

        public void SupplierNameDisplayed()
        {
            driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionSupplierName).Displayed.Should().BeTrue();
        }

        public string GetSolutionName()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionName).Text;
        }

        public string GetSolutionSummary()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionSummary).Text;
        }

        public string GetSolutionLastUpdated()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionLastUpdated).Text
                .Replace("Solution information last updated: ", "");
        }

        public string GetSolutionAboutUrl()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionAboutUrl).Text;
        }

        public IList<string> GetFeatures()
        {
            return driver.FindElements(Objects.Pages.ViewSingleSolution.Features).Select(s => s.Text).ToList();
        }

        public bool CapabilitiesListDisplayed()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionCapabilities).Displayed;
        }

        public bool AttachmentDownloadLinkDisplayed()
        {
            return driver.FindElements(Objects.Pages.ViewSingleSolution.AttachmentDownloadLink).Count > 0;
        }

        public bool NhsAssuredIntegrationsDownloadLinkDisplayed()
        {
            return driver.FindElements(Objects.Pages.ViewSingleSolution.DownloadNHSAssuredIntegrationsDocumentLink).Count > 0;
        }

        public bool RoadmapDownloadLinkDisplayed()
        {
            return driver.FindElements(Objects.Pages.ViewSingleSolution.DownloadRoadmapDocumentLink).Count > 0;
        }

        public bool FoundationSolutionIndicatorDisplayed()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.FoundationSolutionIndicator).Displayed;
        }

        public IList<string> GetSolutionCapabilities()
        {
            var capabilities = driver.FindElements(Objects.Pages.ViewSingleSolution.SolutionCapabilities)
                .Select(s => s.FindElement(Objects.Pages.ViewSingleSolution.CapabilityTitle).Text)
                .Select(s => s.Split(',')[0])
                .ToList();
            return capabilities;
        }

        public string GetAttachmentDownloadLinkUrl()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.AttachmentDownloadLink).GetAttribute("href");
        }

        public string GetNhsAssuredIntegrationsDownloadLinkUrl()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.DownloadNHSAssuredIntegrationsDocumentLink)
                .GetAttribute("href");
        }

        public string GetRoadmapDownloadLinkUrl()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.DownloadRoadmapDocumentLink)
                .GetAttribute("href");
        }

        public string GetSolutionFullDescription()
        {
            return driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionFullDescription).Text;
        }

        public SolutionContactDetails GetSolutionContactDetails(bool GetName = true, bool GetDepartment = true, bool GetPhoneNumber = true, bool GetEmail = true)
        {
            SolutionContactDetails contactDetails = new();
            if (GetName)
            {
                contactDetails.FirstName = driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactName).Text.Split(' ')[0];
                contactDetails.LastName = driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactName).Text.Split(' ')[1];
            }
            if (GetDepartment)
            {
                contactDetails.Department = driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactDepartment).Text;
            }
            if (GetPhoneNumber)
            {
                contactDetails.PhoneNumber = driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactPhoneNumber).Text;
            }
            if (GetEmail)
            {
                contactDetails.Email = driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactEmail).Text;
            }

            return contactDetails;
        }

        public void WaitForRoadmapSectionDisplayed()
        {
            wait.Until(s =>
            {
                s.Navigate().Refresh();
                return s.FindElement(Objects.Pages.ViewSingleSolution.RoadmapSection).Displayed;
            });
        }

        public void WaitForIntegrationsSectionDisplayed()
        {
            wait.Until(s =>
            {
                s.Navigate().Refresh();
                return s.FindElement(Objects.Pages.ViewSingleSolution.IntegrationsSection).Displayed;
            });
        }

        public bool WaitForLearnMoreSectionDisplayed()
        {
            try
            {
                wait.Until(s =>
                {
                    s.Navigate().Refresh();
                    return s.FindElement(Objects.Pages.ViewSingleSolution.LearnMoreSection).Displayed;
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