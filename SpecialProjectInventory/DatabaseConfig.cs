using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialProjectInventory
{
    public static class DatabaseConfig
    {
        public static string ConnectionString
        {
            get
            {
                return @"Data Source=DESKTOP-CAAM698\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True";
            }
        }
    }
}
