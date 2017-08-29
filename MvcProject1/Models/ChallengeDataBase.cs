using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcProject1.Models
{
    public class ChallengeDataBase
    {
        private SqlConnection sqlConn;

        public SqlConnection ConnectDataBase()
        {
            string connString = "workstation id=dotachallengedb.mssql.somee.com;packet size=4096;user id=ionofrei_SQLLogin_1;pwd=9jhfklmuay;data source=dotachallengedb.mssql.somee.com;persist security info=False;initial catalog=dotachallengedb";
            try
            {
                sqlConn = new SqlConnection(connString);
                sqlConn.Open();
            }
            catch (SqlException ex)
            {
                return null;
            }
            return sqlConn;
        }
    }
}