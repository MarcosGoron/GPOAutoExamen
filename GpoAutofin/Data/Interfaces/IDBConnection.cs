using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpoAutofin.Data.Interfaces
{
    public interface IDBConnection
    {
        SqlConnection GetConnection();
        void CloseConnection();
    }
}
