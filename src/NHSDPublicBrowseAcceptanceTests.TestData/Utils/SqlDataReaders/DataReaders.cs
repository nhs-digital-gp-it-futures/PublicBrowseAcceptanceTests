using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils.SqlDataReaders
{
    public static class DataReaders
    {
        internal static object NoReturn(IDataReader dr)
        {
            dr.Read();
            return null;
        }

        internal static string GetSolutionSummary(IDataReader dr)
        {
            dr.Read();
            return dr["Summary"].ToString();
        }

        internal static string GetSolutionDescription(IDataReader dr)
        {
            dr.Read();
            return dr["FullDescription"].ToString();
        }

        internal static string GetFeatures(IDataReader dr)
        {
            dr.Read();
            return dr["Features"].ToString();
        }

        internal static int GetSupplierStatus(IDataReader dr)
        {
            dr.Read();
            int.TryParse(dr["SupplierStatusId"].ToString(), out int result);
            return result;
        }

        internal static int GetCount(IDataReader dr)
        {
            dr.Read();
            int.TryParse(dr["count"].ToString(), out int result);
            return result;
        }

        internal static SolutionDto GetSolutionObject(IDataReader dr)
        {
            dr.Read();

            SolutionDto dto = new SolutionDto
            {
                Id = dr["Id"].ToString(),
                Name = dr["Name"].ToString(),
                Summary = dr["Summary"].ToString(),
                LastUpdated = DateTime.Parse(dr["LastUpdated"].ToString()),
                SupplierName = dr["SupplierName"].ToString(),
                AboutUrl = dr["AboutUrl"].ToString()
            };

            return dto;
        }

        internal static string GetSolutionCapabilities(IDataReader dr)
        {
            dr.Read();
            return dr["Capabilities"].ToString();
        }
    }
}
