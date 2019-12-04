using System;
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
            Regex.Match(driver.Url, $@"{url}/solutions/(foundation|all)/.*").Success.Should().BeTrue();            
        }

        public string GetSolutionId()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionId).Text.Replace("Solution ID: ", "");
        }

        public string GetSupplierName()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionOrganisationName).Text;
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
            return driver.FindElement(pages.ViewSingleSolution.SolutionLastUpdated).Text.Replace("Page last updated: ","");
        }

        public string GetSolutionAboutUrl()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionAboutUrl).Text;
        }

        public bool CapabilitiesListDisplayed()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionCapabilities).Displayed;
        }

        public bool AttachmentDownloadLinkDisplayed()
        {
            return driver.FindElement(pages.ViewSingleSolution.AttachmentDownloadLink).Displayed;
        }

        public bool FoundationSolutionIndicatorDisplayed()
        {
            return driver.FindElement(pages.ViewSingleSolution.FoundationSolutionIndicator).Displayed;
        }

        public IList<string> GetSolutionCapabilities()
        {
            var capabilities = driver.FindElements(pages.ViewSingleSolution.SolutionCapabilities).Select(s => s.Text).ToList();
            return capabilities;
        }

        public string GetDownloadUrl()
        {
            return driver.FindElement(pages.ViewSingleSolution.AttachmentDownloadLink).GetAttribute("href");            
        }

        public string GetSolutionFullDescription()
        {
            return driver.FindElement(pages.ViewSingleSolution.SolutionFullDescription).Text;
        }

        public SolutionContactDetails GetSolutionContactDetails()
        {
            SolutionContactDetails contactDetails = new SolutionContactDetails
            {
                ContactName = driver.FindElement(pages.ViewSingleSolution.SolutionContactName).Text,
                Department = driver.FindElement(pages.ViewSingleSolution.SolutionContactDepartment).Text,
                PhoneNumber = driver.FindElement(pages.ViewSingleSolution.SolutionContactPhoneNumber).Text,
                Email = driver.FindElement(pages.ViewSingleSolution.SolutionContactEmail).Text
            };

            return contactDetails;
        }
    }
}