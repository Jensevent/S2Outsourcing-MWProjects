using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OutsourcingMWProject
{
    class Databasehandler
    {
        public SqlConnectionStringBuilder builder { get; private set; }
        public SqlConnection con { get; private set; }
        public DataTable table { get; private set; }

        public Databasehandler()
        {
            builder = new SqlConnectionStringBuilder();

            builder.DataSource = "mssql.fhict.local";
            builder.UserID = "dbi435490_outsource";
            builder.Password = "mEyv2v4i&Hx4o%D65b*i";
            builder.InitialCatalog = "dbi435490_outsource";

            con = new SqlConnection(builder.ConnectionString);
            table = new DataTable();
        }

        public bool TestConnection()
        {
            bool open = false;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    open = true;
                    con.Close();
                }
            }
            catch (Exception)
            {
                open = false;
            }
            return open;
        }

        public void OpenConnectionToDB()
        {
            con.Open();
        }

        public void CloseConnectionToDB()
        {
            con.Close();
        }

        public SqlConnection GetCon()
        {
            return con;
        }

        public void ClearTable()
        {
            table.Clear();
        }

        public void FillTable(DataTable givenTable)
        {
            table = givenTable;
        }
    }
}
