namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    internal static class Queries
    {
        internal const string CreateNewSolution = "INSERT INTO Solution (Id, SupplierId, OrganisationId, Name, Version, PublishedStatusId, AuthorityStatusId, SupplierStatusId, OnCatalogueVersion, LastUpdatedBy, LastUpdated) values (@solutionId, (SELECT TOP (1) [Id] FROM [dbo].[Supplier]), (SELECT TOP (1) [Id] FROM [dbo].[Organisation]), @solutionName, @solutionVersion, @publishStatus,1,1, 0, @lastUpdatedBy, @lastUpdated)";
        internal const string GetSolution = "SELECT Summary, FullDescription, SupplierStatusId from [dbo].[Solution] where Id=@solutionId";
        internal const string UpdateSolutionSolutionDetailId = "UPDATE Solution SET SolutionDetailId=@solutionDetailId WHERE Id=@solutionId";
        internal const string DeleteSolution = "DELETE from Solution where Id=@solutionId";

        internal const string GetSolutionsCount = "SELECT COUNT (*) as count FROM [dbo].Solution WHERE Solution.PublishedStatusId = 3";
        internal const string GetFoundationSolutionsCount = "SELECT COUNT (*) as count FROM [dbo].Solution LEFT JOIN FrameworkSolutions ON Solution.Id = FrameworkSolutions.SolutionId WHERE COALESCE(FrameworkSolutions.IsFoundation, 0) = 1 AND Solution.PublishedStatusId = 3";
        internal const string GetNonFoundationSolutionsCount = "SELECT COUNT (*) as count FROM [dbo].Solution WHERE Solution.Id NOT IN ( SELECT SolutionId FROM [dbo].FrameworkSolutions WHERE IsFoundation = 1 ) AND Solution.PublishedStatusId = 3";
        internal const string GetSolutionsWithCapabilityCount = "SELECT COUNT(*) as count FROM [dbo].[SolutionCapability] AS sc LEFT JOIN .[dbo].[Capability] AS c ON c.Id = sc.CapabilityId WHERE Name = @capabilityName";

        internal const string GetSingleSolution = "SELECT Sol.[Id],Sol.[Name],Sol.[LastUpdated],Det.[AboutUrl],Det.[Summary],Det.[FullDescription],Org.[Name] as SupplierName,RTrim(Coalesce(MC.FirstName + ' ','') + Coalesce(MC.LastName + ' ', '')) as ContactName,MC.[PhoneNumber],MC.[Email],MC.[Department] FROM [dbo].[Solution] as Sol LEFT JOIN [dbo].[SolutionDetail] as Det ON Det.[Id] = Sol.[SolutionDetailId] LEFT JOIN [dbo].[Organisation] as Org ON Sol.OrganisationId = Org.Id LEFT JOIN [dbo].[MarketingContact] as MC ON Sol.Id = MC.SolutionId WHERE Sol.Id = @solutionId";
        internal const string GetSingleSolutionCapabilities = "SELECT STRING_AGG(CAPS.Name, ',') as Capabilities FROM Capability as CAPS Where CAPS.Id in (SELECT CapabilityId FROM SolutionCapability as SC where SC.SolutionId = @solutionId )";
        internal const string GetSingleSolutionMarketingContact = "";

        internal const string CreateSolutionDetail = "INSERT INTO SolutionDetail (Id, LastUpdatedBy, LastUpdated, SolutionId) values (@solutionDetailId, @lastUpdatedBy, @lastUpdated, @solutionId)";
        internal const string DeleteSolutionDetail = "DELETE from SolutionDetail where SolutionId=@solutionId";
        internal const string CreateMarketingContact = "INSERT INTO [MarketingContact] (SolutionId, FirstName, LastName, Email, PhoneNumber, Department, LastUpdated, LastUpdatedBy) VALUES(@solutionId, @firstName, @lastName, @email, @phoneNumber, @department, GETDATE(), '00000000-0000-0000-0000-000000000000')";
        internal const string DeleteMarketingContact = "DELETE FROM MarketingContact where SolutionId=@solutionId";

        internal const string UpdateLastUpdated = "UPDATE @table SET LastUpdated=@lastUpdated WHERE @whereKey=@whereValue";

        internal const string AddRandomSolutionCapability = "INSERT INTO SolutionCapability (SolutionId, CapabilityId, StatusId, LastUpdated, LastUpdatedBy) VALUES (@solutionId, (SELECT TOP 1 CapabilityId FROM FrameworkCapabilities ORDER BY RAND()), 1, GETDATE(), '00000000-0000-0000-0000-000000000000')";

        internal const string DeleteSolutionCapability = "DELETE FROM SolutionCapability WHERE SolutionId=@solutionId";
    }

}
