using QuantumForce.Site.Helpers;
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
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("Dashboard.aspx");
                }
                LoadBudgets();
            }
        }

        protected void LoadBudgets()
        {
            string sFilePath = Server.MapPath("QuantumForce.accdb");
            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                int userId = HelperMethods.FindUser(User.Identity.Name, sFilePath);

                if (userId != 0)
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT UserBudgetID, BudgetName, BudgetID FROM tblUserBudget WHERE UserID = " + userId, Conn);
                    OleDbDataAdapter oDA = new OleDbDataAdapter(cmd);
                    dt = new DataTable();
                    oDA.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        gvBudgets.DataSource = dt;
                        gvBudgets.DataBind();
                    }
                }
            }
        }

        protected void CreateBudget_Click(object sender, EventArgs e)
        {
            Response.Redirect("Budget.aspx");
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect("Budget.aspx?BudgetID=" + button.ToolTip);
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string sFilePath = Server.MapPath("QuantumForce.accdb");
            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand("delete from tblBudget where BudgetID = " + button.ToolTip, Conn);
                int result = cmd.ExecuteNonQuery();

                if(result == 1)
                {
                    cmd.CommandText = "delete from tblUserBudget where BudgetID = " + button.ToolTip;
                    result = cmd.ExecuteNonQuery();
                    if(result == 1)
                    {
                        Response.Redirect("BudgetManagement.aspx");
                    }
                }
            }
        }
    }
}