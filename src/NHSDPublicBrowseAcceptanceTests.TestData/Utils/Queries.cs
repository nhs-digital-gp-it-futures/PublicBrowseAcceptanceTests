namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    public static class Queries
    {
        public const string CreateNewSolution =
            "INSERT INTO Solution (Id, SupplierId, Name, Version, PublishedStatusId, AuthorityStatusId, SupplierStatusId, OnCatalogueVersion, LastUpdatedBy, LastUpdated) values (@SolutionId, @SupplierId, @SolutionName, @SolutionVersion, @PublishedStatusId,@AuthorityStatusId,@SupplierStatusId, 0, @LastUpdatedBy, @LastUpdated)";

        public const string GetSolution = "SELECT * from [dbo].[Solution] WHERE Solution.Id=@solutionId";

        public const string UpdateSolution =
            "UPDATE Solution SET SolutionDetailId=@solutionDetailId, SupplierId=@supplierId, Name=@solutionName, Version=@solutionVersion, PublishedStatusId=@publishedStatusId, AuthorityStatusId=@authorityStatusId, SupplierStatusId=@supplierStatusId WHERE Id=@solutionId";

        public const string DeleteSolution = "DELETE FROM Solution WHERE Id=@solutionId";
        public const string GetAllSolutions = "SELECT * FROM [dbo].[Solution]";

        public const string GetSolutionsCount =
            "SELECT COUNT(DISTINCT(SolutionId)) FROM SolutionCapability c INNER JOIN Solution s on c.SolutionId=s.Id WHERE s.PublishedStatusId=3";

        public const string GetFoundationSolutionsCount =
            "SELECT COUNT(DISTINCT(sc.SolutionId)) FROM SolutionCapability sc INNER JOIN Solution s on sc.SolutionId=s.Id LEFT JOIN FrameworkSolutions fs ON s.Id = fs.SolutionId WHERE COALESCE(fs.IsFoundation, 0) = 1 AND s.PublishedStatusId = 3";

        public const string GetNonFoundationSolutionsCount =
            "SELECT COUNT(DISTINCT(sc.SolutionId)) FROM SolutionCapability sc INNER JOIN Solution s on SolutionId=s.Id WHERE s.Id NOT IN ( SELECT SolutionId FROM [dbo].FrameworkSolutions WHERE IsFoundation = 1 ) AND s.PublishedStatusId = 3";

        public const string GetSolutionsWithCapabilityCount =
            "SELECT COUNT(*) AS count FROM [dbo].[SolutionCapability] AS sc LEFT JOIN .[dbo].[Capability] AS c ON c.Id = sc.CapabilityId WHERE Name = @capabilityName";

        public const string GetCapabilityById = "SELECT * FROM Capability WHERE Id=@Id";
        public const string GetAllCapabilities = "SELECT * FROM Capability";

        public const string GetAllEpicsByCapabilityId =
            "SELECT e.Id,e.Name,e.CapabilityId,c.Name AS Level FROM Epic AS e INNER JOIN CompliancyLevel AS c ON e.CompliancyLevelId = c.Id WHERE e.CapabilityId=@Id";

        public const string CreateSolutionDetail =
            "INSERT INTO SolutionDetail (Id, LastUpdatedBy, LastUpdated, SolutionId,AboutUrl,Features,Summary,FullDescription) values (@solutionDetailId, @lastUpdatedBy, @lastUpdated, @solutionId,@AboutUrl,@Features,@Summary,@FullDescription)";

        public const string GetSolutionDetail = "SELECT * from [dbo].[SolutionDetail] where SolutionId=@solutionId";

        public const string UpdateSolutionDetail =
            "UPDATE SolutionDetail SET Features=@features, ClientApplication=@clientApplication, AboutUrl=@aboutUrl, Summary=@summary, FullDescription=@fullDescription, RoadMap=@roadMap, Hosting=@hostingTypes, IntegrationsUrl=@integrationsUrl, ImplementationDetail=@implementationTimescales WHERE SolutionId=@solutionId";

        public const string DeleteSolutionDetail = "DELETE from SolutionDetail where SolutionId=@solutionId";

        public const string CreateMarketingContact =
            "INSERT INTO [MarketingContact] (SolutionId, FirstName, LastName, Email, PhoneNumber, Department, LastUpdated, LastUpdatedBy) VALUES(@solutionId, @firstName, @lastName, @email, @phoneNumber, @department, GETDATE(), '00000000-0000-0000-0000-000000000000')";

        public const string DeleteMarketingContact = "DELETE FROM MarketingContact where SolutionId=@solutionId";

        public const string UpdateLastUpdated =
            "UPDATE @table SET LastUpdated=@lastUpdated WHERE @whereKey=@whereValue";

        public const string GetLatestLastUpdated =
            @"Select TOP (1) Solution.LastUpdated AS SolutionLastUpdated, SolutionDetail.LastUpdated AS SolutionDetailLastUpdated, MarketingContact.LastUpdated AS MarketingContactLastUpdated, (select max(LU) FROM (VALUES (Solution.LastUpdated), (SolutionDetail.LastUpdated), (MarketingContact.LastUpdated)) as value(LU)) as [LastestLastUpdated]
                from Solution
                Left JOIN SolutionDetail on SolutionDetail.SolutionId = Solution.Id
                Left Join MarketingContact on MarketingContact.SolutionId = Solution.Id
                where Solution.Id = @solutionId;
            ";

        internal const string GetLastUpdated = "SELECT LastUpdated FROM @table WHERE @whereKey=@whereValue";

        public const string AddRandomSolutionCapability =
            "INSERT INTO SolutionCapability (SolutionId, CapabilityId, StatusId, LastUpdated, LastUpdatedBy) VALUES (@solutionId, (SELECT TOP 1 CapabilityId FROM FrameworkCapabilities ORDER BY RAND()), 1, GETDATE(), '00000000-0000-0000-0000-000000000000')";

        public const string GetSolutionCapabilities =
            "Select c.Id, c.CapabilityRef, c.Name from SolutionCapability s inner join Capability c on s.CapabilityId = c.Id where s.SolutionId =@solutionId";

        public const string DeleteSolutionCapability = "DELETE FROM SolutionCapability WHERE SolutionId=@solutionId";
        public const string GetSolutionContactDetails = "SELECT * FROM MarketingContact WHERE SolutionId=@solutionId";

        public const string AddMarketingContact =
            "INSERT INTO MarketingContact (SolutionId, FirstName, LastName,Email,PhoneNumber,Department,LastUpdated,LastUpdatedBy) VALUES(@solutionId, @FirstName, @LastName, @Email, @PhoneNumber, @Department,@LastUpdated,@LastUpdatedBy)";

        public const string GetSelectedCapabilities =
            "SELECT DISTINCT(c.Name) FROM SolutionCapability sc INNER JOIN Solution s on sc.SolutionId=s.Id inner join Capability c on c.Id=sc.CapabilityId WHERE s.PublishedStatusId=3";

        public const string GetSolutionCountForCapability =
            "SELECT COUNT(*) FROM Solution s INNER JOIN SolutionCapability sc on sc.SolutionId=s.Id INNER JOIN Capability c on sc.CapabilityId = c.Id WHERE c.Name=@CapabilityName";
    }
}