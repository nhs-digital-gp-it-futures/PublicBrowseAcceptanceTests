namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using OpenQA.Selenium;

    public class ViewASolution : Interactions
    {
        public ViewASolution(IWebDriver driver)
            : base(driver)
        {
        }

        public void PageDisplayed(string url)
        {
            Wait.Until(s => s.FindElements(Objects.Pages.ViewSingleSolution.SolutionId).Count == 1);

            // Should be a better way to do this that doesn't rely on RegEx matching
            var actual = Driver.Url;
            var expectedPattern = $@"{url}/solutions/(capabilities-selector.*|foundation|dfocvc001)/*";
            Regex.Match(actual, expectedPattern).Success.Should()
                .BeTrue();
        }

        public string GetSolutionId()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionId).Text.Replace("Solution ID: ", string.Empty);
        }

        public void SupplierNameDisplayed()
        {
            Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionSupplierName).Displayed.Should().BeTrue();
        }

        public string GetSolutionName()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionName).Text;
        }

        public string GetSolutionSummary()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionSummary).Text;
        }

        public string GetSolutionLastUpdated()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionLastUpdated).Text
                .Replace("Solution information last updated: ", string.Empty);
        }

        public string GetSolutionAboutUrl()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionAboutUrl).Text;
        }

        public IList<string> GetFeatures()
        {
            return Driver.FindElements(Objects.Pages.ViewSingleSolution.Features).Select(s => s.Text).ToList();
        }

        public bool CapabilitiesListDisplayed()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionCapabilities).Displayed;
        }

        public bool AttachmentDownloadLinkDisplayed()
        {
            return Driver.FindElements(Objects.Pages.ViewSingleSolution.AttachmentDownloadLink).Count > 0;
        }

        public bool NhsAssuredIntegrationsDownloadLinkDisplayed()
        {
            return Driver.FindElements(Objects.Pages.ViewSingleSolution.DownloadNHSAssuredIntegrationsDocumentLink).Count > 0;
        }

        public bool RoadmapDownloadLinkDisplayed()
        {
            return Driver.FindElements(Objects.Pages.ViewSingleSolution.DownloadRoadmapDocumentLink).Count > 0;
        }

        public bool FoundationSolutionIndicatorDisplayed()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.FoundationSolutionIndicator).Displayed;
        }

        public IList<string> GetSolutionCapabilities()
        {
            var capabilities = Driver.FindElements(Objects.Pages.ViewSingleSolution.SolutionCapabilities)
                .Select(s => s.FindElement(Objects.Pages.ViewSingleSolution.CapabilityTitle).Text)
                .Select(s => s.Split(',')[0])
                .ToList();
            return capabilities;
        }

        public string GetAttachmentDownloadLinkUrl()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.AttachmentDownloadLink).GetAttribute("href");
        }

        public string GetNhsAssuredIntegrationsDownloadLinkUrl()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.DownloadNHSAssuredIntegrationsDocumentLink)
                .GetAttribute("href");
        }

        public string GetRoadmapDownloadLinkUrl()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.DownloadRoadmapDocumentLink)
                .GetAttribute("href");
        }

        public string GetSolutionFullDescription()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionFullDescription).Text;
        }

        public string GetFrameworks()
        {
            return Driver.FindElement(Objects.Pages.ViewSingleSolution.Frameworks).Text;
        }

        public SolutionContactDetails GetSolutionContactDetails(bool getName = true, bool getDepartment = true, bool getPhoneNumber = true, bool getEmail = true)
        {
            SolutionContactDetails contactDetails = new();
            if (getName)
            {
                contactDetails.FirstName = Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactName).Text.Split(' ')[0];
                contactDetails.LastName = Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactName).Text.Split(' ')[1];
            }

            if (getDepartment)
            {
                contactDetails.Department = Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactDepartment).Text;
            }

            if (getPhoneNumber)
            {
                contactDetails.PhoneNumber = Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactPhoneNumber).Text;
            }

            if (getEmail)
            {
                contactDetails.Email = Driver.FindElement(Objects.Pages.ViewSingleSolution.SolutionContactEmail).Text;
            }

            return contactDetails;
        }

        public void WaitForRoadmapSectionDisplayed()
        {
            Wait.Until(s =>
            {
                s.Navigate().Refresh();
                return s.FindElement(Objects.Pages.ViewSingleSolution.RoadmapSection).Displayed;
            });
        }

        public void WaitForIntegrationsSectionDisplayed()
        {
            Wait.Until(s =>
            {
                s.Navigate().Refresh();
                return s.FindElement(Objects.Pages.ViewSingleSolution.IntegrationsSection).Displayed;
            });
        }

        public bool WaitForLearnMoreSectionDisplayed()
        {
            try
            {
                Wait.Until(s =>
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