using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public sealed class SolutionsList : Interactions
    {
        public SolutionsList(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
        }

        /// <summary>
        /// Get the first solution in the list
        /// </summary>
        /// <returns></returns>
        public IWebElement GetFirstSolution()
        {
            return driver.FindElements(pages.SolutionsList.Solutions).First();
        }

        /// <summary>
        /// Ensure the first solution has a Capabilities section
        /// </summary>
        /// <returns></returns>
        public bool SolutionHasCapabilities()
        {
            IWebElement solution = GetFirstSolution();

            return solution.FindElements(By.CssSelector("[data-test-id=solution-sections] label.nhsuk-label--s")).Where(s => s.Text == "Capabilities").Count() == 1;
        }

        public bool SolutionsHaveAllSelectedCapabilities()
        {
            IList<string> selectedCapabilities = driver.FindElements(pages.CapabilityFilter.Capabilities).Where(s => s.FindElement(By.TagName("input")).GetProperty("checked") == "checked").Select(s => s.Text).ToList();

            var solutionsCount = GetSolutionsCount();

            foreach(var cap in selectedCapabilities)
            {
                if (GetSolutionsWithCapability(cap) != solutionsCount) return false;
            }

            return true;
        }

        /// <summary>
        /// Get number of solutions that contain a named capability
        /// </summary>
        /// <param name="capabilityName"></param>
        /// <returns>Count of solutions matching the capability</returns>
        public int GetSolutionsWithCapability(string capabilityName)
        {
            int solCount = 0;

            var solutionsCount = driver.FindElements(pages.SolutionsList.Solutions).Count;

            for (int i = 0; i < solutionsCount; i++)
            {
                var solution = driver.FindElements(pages.SolutionsList.Solutions)[i];

                var capabilities = solution.FindElements(By.CssSelector("[data-test-id=capability-section-value]"));

                foreach (var cap in capabilities.Select(s => s.Text))
                {
                    if (cap.ToLower().Contains(capabilityName.ToLower()))
                    {
                        solCount++;
                        break;
                    }
                }
            }

            return solCount;
        }

        /// <summary>
        /// Ensure each solution has a summary section
        /// </summary>
        /// <returns></returns>
        public bool SolutionHasSummary()
        {
            IWebElement solution = GetFirstSolution();

            return solution.FindElement(CustomBy.DataTestId("summary-section-value")).Displayed;
        }

        /// <summary>
        /// Get total number of solutions
        /// </summary>
        /// <returns></returns>
        public int GetSolutionsCount()
        {
            return driver.FindElements(pages.SolutionsList.Solutions).Count;
        }

        /// <summary>
        /// Ensure the solution contains the name of the solution
        /// </summary>
        /// <returns>True if the solution has a name displayed</returns>
        public bool SolutionHasTitle()
        {
            IWebElement solution = GetFirstSolution();

            return solution.FindElement(By.TagName("h3")).Displayed;
        }

        /// <summary>
        /// Wait for the solution list to be displayed
        /// </summary>
        public void WaitForSolutionToBeDisplayed()
        {
            wait.Until(s => s.FindElement(pages.SolutionsList.Solutions));
        }

        /// <summary>
        /// Get list of features for a particular solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns>List of names of features</returns>
        public IList<string> GetFeaturesForSolution(IWebElement solution)
        {
            return solution.FindElements(CustomBy.DataTestId("features-value")).Select(s => s.Text).ToList();
        }


        /// <summary>
        /// Clicks on the name of the first solution
        /// </summary>
        /// <returns>Solution name (string)</returns>
        public string SolutionCanBeViewed()
        {
            IWebElement solution = GetFirstSolution();

            return SolutionCanBeViewed(solution);
        }

        /// <summary>
        /// Clicks on the name of the supplied solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns>Solution name (string)</returns>
        public string SolutionCanBeViewed(IWebElement solution)
        {
            var solutionName = solution.FindElement(By.TagName("h3")).Text;

            solution.FindElement(By.TagName("h3")).Click();            

            return solutionName;
        }

        /// <summary>
        /// Get a list of the capabilities for the chosen solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns>List of capability names</returns>
        public IList<string> GetCapabilitiesForSolution(IWebElement solution)
        {
            IList<IWebElement> capabilities = solution.FindElements(CustomBy.DataTestId("capability-section-value"));

            return capabilities.Select(s => s.Text).ToList();
        }
    }
}
