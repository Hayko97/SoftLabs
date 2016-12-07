using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCore.DbHelpers
{
    public class HelperBase
    {
        protected const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\H.Harutyunyan\documents\visual studio 2015\Projects\SoftLabs\src\SoftLabs\App-Data\SoftLabsDb.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection cnct = new SqlConnection(ConnectionString);
        private StringBuilder stBuilder = new StringBuilder();
        protected SqlConnection Connection { get { return cnct; }}
        protected StringBuilder StringBuilder { get { return stBuilder;} }

    }
}
