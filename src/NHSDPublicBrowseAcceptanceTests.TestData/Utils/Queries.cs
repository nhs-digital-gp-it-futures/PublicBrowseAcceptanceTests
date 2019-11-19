namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    internal static class Queries
    {
        internal const string CreateNewSolution = "INSERT INTO Solution (Id, OrganisationId, Name, Version, PublishedStatusId, AuthorityStatusId, SupplierStatusId, OnCatalogueVersion) values (@solutionId, 1000000, @solutionName, @solutionVersion, 1,1,1, 0)";
        internal const string GetSolution = "SELECT Summary, FullDescription, SupplierStatusId from [dbo].[Solution] where Id=@solutionId";
        internal const string DeleteSolution = "DELETE from Solution where Id=@solutionId";

        internal const string GetFoundationSolutionsCount = "SELECT COUNT (SolutionId) as count FROM [dbo].Solution LEFT JOIN FrameworkSolutions ON Solution.Id = FrameworkSolutions.SolutionId WHERE COALESCE(FrameworkSolutions.IsFoundation, 0) = 1";
        internal const string GetNonFoundationSolutionsCount = "SELECT COUNT (Solution.Id) as count FROM [dbo].Solution WHERE Solution.Id NOT IN ( SELECT SolutionId FROM [dbo].FrameworkSolutions WHERE IsFoundation = 1 )";
    }
}
