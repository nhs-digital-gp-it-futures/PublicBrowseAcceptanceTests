﻿namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    public static class Queries
    {
        public const string CreateNewSolution =
            "INSERT INTO Solution (Id, Version, Summary, FullDescription, Features, ClientApplication, Hosting, ImplementationDetail, RoadMap, IntegrationsUrl, AboutUrl, ServiceLevelAgreement, LastUpdatedBy, LastUpdated) values (@SolutionId, @Version, @Summary, @FullDescription, @Features, @ClientApplication, @Hosting, @ImplementationDetail, @RoadMap, @IntegrationsUrl, @AboutUrl, @ServiceLevelAgreement, @LastUpdatedBy, @LastUpdated);";

        public const string GetSolution = "SELECT * from [dbo].[Solution] WHERE Solution.Id=@solutionId;";

        public const string UpdateSolution =
            "UPDATE Solution SET Version=@solutionVersion, Summary=@Summary, FullDescription=@FullDescription, Features=@Features, ClientApplication=@ClientApplication, Hosting=@Hosting, ImplementationDetail=@ImplementationDetail, RoadMap=@RoadMap, IntegrationsUrl=@IntegrationsUrl, AboutUrl=@AboutUrl, ServiceLevelAgreement=@ServiceLevelAgreement, LastUpdatedBy=@LastUpdatedBy, LastUpdated=@LastUpdated WHERE Id=@solutionId;";

        public const string DeleteSolution = "DELETE FROM Solution WHERE Id=@solutionId;";
        public const string GetAllSolutions = @"SELECT DISTINCT 
                   ci.CatalogueItemId AS SolutionId, ci.[Name] AS SolutionName, sol.Summary AS SolutionSummary,
                   sup.Id AS SupplierId, sup.[Name] AS SupplierName,
                   fs.IsFoundation AS IsFoundation
              FROM dbo.CatalogueItem AS ci
                   INNER JOIN dbo.Solution AS sol
                           ON sol.Id = ci.CatalogueItemId
                   INNER JOIN dbo.Supplier AS sup
                           ON sup.Id = ci.SupplierId
                   INNER JOIN dbo.PublicationStatus AS ps
                           ON ps.Id = ci.PublishedStatusId
                   INNER JOIN dbo.SolutionCapability AS sc
                           ON sol.Id = sc.SolutionId
                   INNER JOIN dbo.FrameworkSolutions AS fs
                           ON sol.Id = fs.SolutionId
             WHERE ps.[Name] = 'Published';";

        public const string GetSolutionsCount =
            "SELECT COUNT(DISTINCT(SolutionId)) FROM SolutionCapability c INNER JOIN CatalogueItem ci on c.SolutionId=ci.CatalogueItemId WHERE ci.PublishedStatusId=3;";

        public const string GetFoundationSolutionsCount =
            "SELECT COUNT(DISTINCT(sc.SolutionId)) FROM SolutionCapability sc INNER JOIN CatalogueItem s on sc.SolutionId=s.CatalogueItemId LEFT JOIN FrameworkSolutions fs ON s.CatalogueItemId = fs.SolutionId WHERE COALESCE(fs.IsFoundation, 0) = 1 AND s.PublishedStatusId = 3;";

        public const string GetNonFoundationSolutionsCount =
            "SELECT COUNT(DISTINCT(sc.SolutionId)) FROM SolutionCapability sc INNER JOIN CatalogueItem s on SolutionId=s.CatalogueItemId WHERE s.CatalogueItemId NOT IN ( SELECT SolutionId FROM [dbo].FrameworkSolutions WHERE IsFoundation = 1 ) AND s.PublishedStatusId = 3;";

        public const string GetSolutionsWithCapabilityCount =
            @"SELECT DISTINCT 
                   COUNT(*)
              FROM dbo.CatalogueItem AS ci
                   INNER JOIN dbo.Solution AS sol
                           ON sol.Id = ci.CatalogueItemId
                   INNER JOIN dbo.Supplier AS sup
                           ON sup.Id = ci.SupplierId
                   INNER JOIN dbo.PublicationStatus AS ps
                           ON ps.Id = ci.PublishedStatusId
                    INNER JOIN dbo.SolutionCapability AS sc
                           ON sol.Id = sc.SolutionId
                   INNER JOIN dbo.FrameworkSolutions AS fs
                           ON sol.Id = fs.SolutionId
             WHERE ps.[Name] = 'Published'
             AND sc.CapabilityId = (SELECT c.Id FROM Capability AS c WHERE c.[Name] = @capabilityName);";

        public const string GetCapabilityById = "SELECT * FROM Capability WHERE Id=@Id;";
        public const string GetAllCapabilities = "SELECT * FROM Capability WHERE Id IN (SELECT CapabilityId FROM dbo.FrameworkCapabilities WHERE FrameworkId = 'NHSDGP001') AND CategoryId = 1;";

        public const string GetAllEpicsByCapabilityId =
            "SELECT e.Id,e.Name,e.CapabilityId,c.Name AS Level FROM Epic AS e INNER JOIN CompliancyLevel AS c ON e.CompliancyLevelId = c.Id WHERE e.CapabilityId=@Id;";

        public const string CreateMarketingContact =
            "INSERT INTO [MarketingContact] (SolutionId, FirstName, LastName, Email, PhoneNumber, Department, LastUpdated, LastUpdatedBy) VALUES(@solutionId, @firstName, @lastName, @email, @phoneNumber, @department, GETDATE(), '00000000-0000-0000-0000-000000000000');";

        public const string DeleteMarketingContact = "DELETE FROM MarketingContact where SolutionId=@solutionId;";

        public const string UpdateLastUpdated =
            "UPDATE @table SET LastUpdated=@lastUpdated WHERE @whereKey=@whereValue;";

        public const string GetLatestLastUpdated =
            @"Select TOP (1) Solution.LastUpdated AS SolutionLastUpdated, MarketingContact.LastUpdated AS MarketingContactLastUpdated, (select max(LU) FROM (VALUES (Solution.LastUpdated), (MarketingContact.LastUpdated)) as value(LU)) as [LastestLastUpdated]
                from Solution
                Left Join MarketingContact on MarketingContact.SolutionId = Solution.Id
                where Solution.Id = @solutionId;
            ";

        public const string AddRandomSolutionCapability =
            "INSERT INTO SolutionCapability (SolutionId, CapabilityId, StatusId, LastUpdated, LastUpdatedBy) VALUES (@solutionId, (SELECT TOP 1 CapabilityId FROM FrameworkCapabilities ORDER BY RAND()), 1, GETDATE(), '00000000-0000-0000-0000-000000000000');";

        public const string GetSolutionCapabilities =
            "Select c.Id, c.CapabilityRef, c.Name from SolutionCapability s inner join Capability c on s.CapabilityId = c.Id where s.SolutionId =@solutionId;";

        public const string DeleteSolutionCapability = "DELETE FROM SolutionCapability WHERE SolutionId=@solutionId;";
        public const string GetSolutionContactDetails = "SELECT * FROM MarketingContact WHERE SolutionId=@solutionId;";

        public const string AddMarketingContact =
            "INSERT INTO MarketingContact (SolutionId, FirstName, LastName,Email,PhoneNumber,Department,LastUpdated,LastUpdatedBy) VALUES(@solutionId, @FirstName, @LastName, @Email, @PhoneNumber, @Department,@LastUpdated,@LastUpdatedBy);";

        public const string GetSelectedCapabilities =
            "SELECT DISTINCT(c.Name) FROM SolutionCapability sc INNER JOIN CatalogueItem s on sc.SolutionId=s.CatalogueItemId inner join Capability c on c.Id=sc.CapabilityId WHERE s.PublishedStatusId=3;";

        public const string GetSolutionCountForCapability =
            "SELECT COUNT(*) FROM Solution s INNER JOIN SolutionCapability sc on sc.SolutionId=s.Id INNER JOIN Capability c on sc.CapabilityId = c.Id WHERE c.Name=@CapabilityName;";

        public const string CreateNewCatalogueItem =
            "INSERT INTO CatalogueItem (CatalogueItemId, Name, CatalogueItemTypeId, SupplierId, PublishedStatusId, Created) values (@CatalogueItemId, @Name, @CatalogueItemTypeId, @SupplierId, @PublishedStatusId, @Created);";

        public const string GetCatalogueItem = "SELECT * from [dbo].[CatalogueItem] WHERE CatalogueItemId=@CatalogueItemId;";

        public const string UpdateCatalogueItem =
            "UPDATE CatalogueItem SET Name=@Name, CatalogueItemTypeId=@CatalogueItemTypeId, SupplierId=@SupplierId, PublishedStatusId=@publishedStatusId, Created=@Created WHERE CatalogueItemId=@CatalogueItemId;";

        public const string DeleteCatalogueItem = "DELETE FROM CatalogueItem WHERE CatalogueItemId=@CatalogueItemId;";
        public const string GetAllCatalogueItems = "SELECT * FROM [dbo].[CatalogueItem];";

        public const string GetFrameworkSolutionCount = @"SELECT DISTINCT 
                                                        ci.CatalogueItemId,
                                                        Count(sc.CapabilityId) AS Capabilities
                                                    FROM dbo.CatalogueItem AS ci
                                                        INNER JOIN dbo.Solution AS sol
                                                                ON sol.Id = ci.CatalogueItemId
                                                        INNER JOIN dbo.Supplier AS sup
                                                                ON sup.Id = ci.SupplierId
                                                        INNER JOIN dbo.PublicationStatus AS ps
                                                                ON ps.Id = ci.PublishedStatusId
                                                        INNER JOIN dbo.FrameworkSolutions AS fs
                                                                ON sol.Id = fs.SolutionId   
                                                        INNER JOIN dbo.SolutionCapability AS sc
                                                                ON sol.Id = sc.SolutionId                          
                                                    WHERE ps.[Name] = 'Published'
                                                    AND fs.FrameworkId = ISNULL(@frameworkId, fs.FrameworkId)
                                                    GROUP BY ci.CatalogueItemId";

        internal const string GetLastUpdated = "SELECT LastUpdated FROM @table WHERE @whereKey=@whereValue;";
        internal const string GetFrameworkId = "SELECT Id FROM Framework WHERE ShortName = @frameworkName;";
    }
}
