using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbWorker.Tools
{
    public class DbConnection
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;port=3306;User=root;Password=1234;Database=monitoring_of_couriers;charset=utf8";
            return new MySqlConnection(connectionString);
        }
    }
}
