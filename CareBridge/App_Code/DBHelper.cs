using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace CareBridge.App_Code
{
    public class DBHelper
    {   
        public static string ConnStr = ConfigurationManager.ConnectionStrings["CareBridgeDB"].ConnectionString;
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnStr);
        }
   
    }
}