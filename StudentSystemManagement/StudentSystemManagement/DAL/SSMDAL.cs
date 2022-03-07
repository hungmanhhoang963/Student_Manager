using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentSystemManagement.DAL
{
    class SSMDAL
    {
        private static string ConnectionString = @"Data Source=DESKTOP-7C35F03\SQLEXPRESS;Initial Catalog = StudentSystemManagement; Integrated Security = True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
