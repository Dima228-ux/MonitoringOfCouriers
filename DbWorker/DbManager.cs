using DbWorker.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbWorker
{
    public class DbManager
    {
        private static DbManager _instance;

        public TableOrders TableOrders { get; private set; }
        public TableUsers TableUsers { get; private set; }

        private DbManager()
        {
            TableOrders = new TableOrders();
            TableUsers = new TableUsers();
        }

        public static DbManager GetInstance()
        {
            if (_instance == null)
                _instance = new DbManager();
            return _instance;
        }
    }
}
