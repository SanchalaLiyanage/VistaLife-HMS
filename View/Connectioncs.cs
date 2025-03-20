using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaLife.View
{
    class Connectioncs
    {
        string connstring = @"Data Source=DESKTOP-D8JJN1J\MSSQLSERVER01;Initial catalog=VistaLife;Integrated Security=True";

        public SqlConnection GetDBCon()
        {
            SqlConnection connobj = new SqlConnection(connstring);
            connobj.Open();

            return connobj;
        }

    }
}
