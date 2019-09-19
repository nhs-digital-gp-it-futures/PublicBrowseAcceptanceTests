using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public sealed class ViewSolution : Interactions
    {
        public ViewSolution(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
        }

        /// <summary>
        /// Ensure the View solution page is displayed
        /// </summary>
        public void ViewSolutionPageDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(s => s.FindElement(pages.ViewSolution.SolutionName));
        }

        /// <summary>
        /// Get list of capabilities for solution
        /// </summary>
        /// <returns></returns>
        public IList<string> GetCapabilities()
        {
            var capabilities = driver.FindElements(pages.ViewSolution.Capabilities).Select(s => s.Text);

            return capabilities.ToList();
        }

        /// <summary>
        /// Get the solution name from the heading on the page
        /// </summary>
        /// <returns>The solution name (string)</returns>
        public string GetSolutionName()
        {
            return driver.FindElement(pages.ViewSolution.SolutionName).Text;
        }

        /// <summary>
        /// Get list of features for the solution
        /// </summary>
        /// <returns>List of names of features for the solution</returns>
        public IList<string> GetFeatures()
        {
            return driver.FindElements(pages.ViewSolution.Features).Select(s => s.Text).ToList();
        }
    }
}