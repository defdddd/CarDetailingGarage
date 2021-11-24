using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository
{
    public class Connection : IConnection
    {
        public string DataBaseConnection { get; }
        public Connection(string connection)
        {
            DataBaseConnection = connection;
        }
    }
}
