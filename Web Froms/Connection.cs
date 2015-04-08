using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace MyWebsite
{
    public class Connection
    {
        public DataSet ds = new DataSet();

        static string connectionString = @"Provider=Microsoft.jet.OleDb.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/SiteDatabase.mdb");
        public OleDbConnection connection = new OleDbConnection(connectionString);
        public OleDbCommand cmd = new OleDbCommand();

        public Connection()
        {
        }

        public Connection(string cmdCommand)
        {
            cmd.CommandText = cmdCommand;
            cmd.Connection = connection;
        }

        public void initDS()
        {
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(ds);
            connection.Close();
        }
    }
}