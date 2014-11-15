using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuantumForce.Site
{
    public partial class BudgetManagement : System.Web.UI.Page
    {
        DataTable dt;
        OleDbConnection Conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sFilePath = Server.MapPath("QuantumForce.accdb");
            Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;");

            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    //Response.Redirect("Dashboard.aspx");
                }
                LoadBudgets();
            }
        }

        protected void LoadBudgets()
        {
            using (Conn)
            {
                int userId;
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT UserID FROM tblUser WHERE UserName = '" + User.Identity.Name + "'", Conn);
                userId = (int)cmd.ExecuteScalar();
            }
        }
    }
}