﻿namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    using System;
    using System.Diagnostics;
    using Bogus;

    public static class GenerateSolution
    {
        public static Solution GenerateNewSolution(
            string solutionId,
            int numFeatures = 1,
            bool clientApplication = true,
            bool roadMap = false,
            bool hostingTypes = false,
            bool integrationsUrl = false,
            bool implementationTimescales = false)
        {
            var faker = new Faker();

            var solution = new Solution
            {
                SolutionId = solutionId,
                Version = faker.System.Semver(),
                AboutUrl = faker.Internet.Url(),
                Features = GenerateFeatures(numFeatures, faker),
                ClientApplication =
                    clientApplication ? ClientApplicationStringBuilder.GetClientAppString() : string.Empty,
                Summary = faker.Commerce.ProductName(),
                FullDescription = faker.Name.JobTitle(),
                RoadMap = roadMap ? faker.Rant.Review() : string.Empty,
                Hosting = hostingTypes ? GetCompleteHostingTypes() : string.Empty,
                IntegrationsUrl = integrationsUrl ? faker.Internet.Url() : string.Empty,
                ImplementationDetail = implementationTimescales ? faker.Lorem.Sentences(2) : string.Empty,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = Guid.Empty,
            };

            if (Debugger.IsAttached)
            {
                Console.WriteLine(solution.ToString());
            }

            return solution;
        }

        private static string GetCompleteHostingTypes()
        {
            return HostingTypeStrings.CompleteHostingTypes;
        }

        private static string GenerateFeatures(int numFeatures, Faker faker)
        {
            if (numFeatures <= 0)
            {
                return string.Empty;
            }

            var featuresArray = new string[numFeatures];

            if (numFeatures > 0)
            {
                for (var i = 0; i < numFeatures; i++)
                {
                    featuresArray[i] = $"\"{faker.Commerce.ProductAdjective()}\"";
                }
            }

            return $"[{string.Join(",", featuresArray)}]";
        }
    }
}
