﻿namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public sealed class SolutionsList : Interactions
    {
        public SolutionsList(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        ///     Clicks on the name of the supplied solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns>Solution name (string)</returns>
        public static string SolutionCanBeViewed(IWebElement solution)
        {
            var solutionName = solution.FindElement(By.TagName("h3")).Text;

            solution.FindElement(By.TagName("h3")).Click();

            return solutionName;
        }

        /// <summary>
        ///     Get a list of the capabilities for the chosen solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns>List of capability names</returns>
        public static IList<string> GetCapabilitiesForSolution(IWebElement solution)
        {
            IList<IWebElement> capabilities = solution.FindElements(CustomBy.DataTestId("capability-section-value"));

            return capabilities.Select(s => s.Text).ToList();
        }

        /// <summary>
        ///     Get the first solution in the list
        /// </summary>
        /// <returns></returns>
        public IWebElement GetFirstSolution()
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.Solutions).First();
        }

        /// <summary>
        ///     Ensure the first solution has a Capabilities section.
        /// </summary>
        /// <returns>true id=f capabilities section is found</returns>
        public bool SolutionHasCapabilities()
        {
            var solution = GetFirstSolution();

            return solution.FindElements(By.CssSelector("[data-test-id=solution-sections] label.nhsuk-label--s"))
                .Where(s => s.Text == "Capabilities").Count() == 1;
        }

        public void OpenRandomSolution()
        {
            var solutions = Driver.FindElements(Objects.Pages.SolutionsList.Solutions);
            var random = new Random();
            var solution = solutions[random.Next(solutions.Count)].FindElement(Objects.Pages.SolutionsList.SolutionName)
                .FindElement(By.TagName("a"));
            solution.Click();
        }

        public void OpenNamedSolution(string solutionName)
        {
            var solution = Driver.FindElements(Objects.Pages.SolutionsList.SolutionName).Where(s => s.Text.Equals(solutionName))
                .First().FindElement(By.TagName("a"));
            solution.Click();
        }

        public IList<string> GetListOfSolutionNames()
        {
            var solutions = Driver.FindElements(Objects.Pages.SolutionsList.Solutions)
                .Select(s => s.FindElement(Objects.Pages.SolutionsList.SolutionName).Text).ToList();
            return solutions;
        }

        public void OpenRandomFoundationSolution()
        {
            var solutions = Driver.FindElements(Objects.Pages.SolutionsList.Solutions)
                .Where(s => FoundationIndicatorDisplayed(s)).ToList();
            var random = new Random();
            var solution = solutions[random.Next(solutions.Count)].FindElement(Objects.Pages.SolutionsList.SolutionName)
                .FindElement(By.TagName("a"));
            solution.Click();
        }

        public bool SolutionsHaveAllSelectedCapabilities()
        {
            IList<string> selectedCapabilities = Driver.FindElements(Objects.Pages.CapabilityFilter.Capabilities)
                .Where(s => s.FindElement(By.TagName("input")).GetProperty("checked") == "checked").Select(s => s.Text)
                .ToList();

            var solutionsCount = GetSolutionsCount();

            foreach (var cap in selectedCapabilities)
            {
                if (GetSolutionsWithCapability(cap) != solutionsCount)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetSolutionSupplierNameCount()
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.SolutionSupplierName).Where(s => s.Text.Length > 0).Count();
        }

        public int GetSolutionNameCount()
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.SolutionName).Where(s => s.Text.Length > 0).Count();
        }

        /// <summary>
        ///     Get number of solutions that contain a named capability.
        /// </summary>
        /// <param name="capabilityName">Name of capability.</param>
        /// <returns>Count of solutions matching the capability.</returns>
        public int GetSolutionsWithCapability(string capabilityName)
        {
            var solCount = 0;

            var solutionsCount = Driver.FindElements(Objects.Pages.SolutionsList.Solutions).Count;

            for (var i = 0; i < solutionsCount; i++)
            {
                var solution = Driver.FindElements(Objects.Pages.SolutionsList.Solutions)[i];

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

        public int GetSolutionCapabilityListCount()
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.SolutionCapabilityList).Count;
        }

        public int GetSolutionSummaryCount()
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.SolutionSummary).Where(s => s.Text.Length > 0).Count();
        }

        public int GetSolutionsWithCapabilityCount(string capabilityName)
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.SolutionCapabilityName)
                .Where(s => s.Text.Equals(capabilityName)).Count();
        }

        /// <summary>
        ///     Get total number of solutions.
        /// </summary>
        /// <returns>number of solutions found.</returns>
        public int GetSolutionsCount()
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.Solutions).Count;
        }

        /// <summary>
        ///     Ensure the solution contains the name of the solution
        /// </summary>
        /// <returns>True if the solution has a name displayed</returns>
        public bool SolutionHasTitle()
        {
            var solution = GetFirstSolution();

            return solution.FindElement(By.TagName("h3")).Displayed;
        }

        /// <summary>
        ///     Wait for the solution list to be displayed
        /// </summary>
        public void WaitForSolutionToBeDisplayed()
        {
            Wait.Until(s => s.FindElement(Objects.Pages.SolutionsList.Solutions));
        }

        /// <summary>
        ///     Get total number of foundation solution indicators
        ///     used to tell the number of foundation solutions on screen
        /// </summary>
        /// <returns></returns>
        public int GetFoundationSolutionIndicatorCount()
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.FoundationSolutionIndicators).Count;
        }

        public bool CompareSolutionsButtonIsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.SolutionsList.CompareSolutions).Count > 0;
        }

        public string GetCompareSolutionsButtonUrl()
        {
            return Driver.FindElement(Objects.Pages.SolutionsList.CompareSolutions).GetAttribute("href");
        }

        private static bool FoundationIndicatorDisplayed(IWebElement element)
        {
            try
            {
                element.FindElement(Objects.Pages.SolutionsList.FoundationSolutionIndicators);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}