﻿using System;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class ViewASolution : Interactions
    {
        public ViewASolution(IWebDriver driver) : base(driver)
        {
        }

        public void PageDisplayed()
        {
            wait.Until(s => s.Url.Contains("/view-solution/"));
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
    }
}