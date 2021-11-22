using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository
{
    public abstract class Connection
    {
      protected static string Con => Properties.Resources.ConnectionString;       
    }
}
