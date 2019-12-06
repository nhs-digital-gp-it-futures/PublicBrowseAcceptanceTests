using Bogus;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    public static class CreateSolution
    {
        const string prefix = "AutoSol";

        public static Solution CreateNewSolution(bool published = false)
        {
            var faker = new Faker();

            var Id = RandomSolId(faker);
            Solution solution = new Solution
            {
                Id = Id,
                Name = faker.Name.JobTitle(),
                Version = faker.System.Semver(),
                PublishedStatusId = published ? 3 : 1
            };

            return solution;
        }

        private static string RandomSolId(Faker faker)
        {
            var suffix = faker.Random.Digits(14 - prefix.Length);

            return $"{prefix}{string.Join("", suffix)}";
        }

        public static SolutionDetail CreateCompleteSolutionDetail(Solution solution, SolutionDetail solutionDetail)
        {
            return CreateSolutionDetails.CreateNewSolutionDetail(solution.Id, solutionDetail.SolutionDetailId, 5);
        }
    }
}
