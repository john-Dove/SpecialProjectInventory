using System.Data.SqlClient;

namespace SpecialProjectInventory
{
    public static class DatabaseConfig
    {
        public static string ConnectionString
        {
            get
            {
                // My local connection string @NManning
                return @"Data Source=DESKTOP-CAAM698\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True";

                //My work connection string @NManning
                //return @"Data Source=DESKTOP-A8SQOHK\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True";

                /* Team member's connection string @OGayle*/
                //return @"Data Source=DESKTOP-78II3F3\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True";
            }
        }
    }
}
