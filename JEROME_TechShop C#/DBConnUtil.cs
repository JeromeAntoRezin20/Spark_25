using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEROME_TechShop.Util
{
    public class DBConnUtil
    {
        private static readonly string connectionString = "Server=MSI;Database=JEROME_TechShop;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

}
