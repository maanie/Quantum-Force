using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace QuantumForce.Site.Helpers
{
    public static class HelperMethods
    {
        public static int FindUser(string username, string dbPath)
        {
            int userId = 0;

            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath + ";Persist Security Info=False;"))
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT UserID FROM tblUser WHERE UserName = '" + username + "'", Conn);
                userId = (int)cmd.ExecuteScalar();
                Conn.Close();
            }

            return userId;
        }
    }
}