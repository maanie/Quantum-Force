using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuantumForce.Site
{
    public partial class Transactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvTransactions.DataSource = GetTableWithInitialData(); //get Initial data (Will be replaced by a select query
                this.gvTransactions.DataBind();
            }
 

        }

        public DataTable GetTableWithInitialData() 
        {
            //Replace the below code with a select query
            DataTable table = new DataTable();
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Amount", typeof(double));

            table.Rows.Add("Shopping", "Shannon buys New Clothes and Shoes", "1000000");
            return table;
        }

        protected void btnAddTransaction_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr;

            if (dt.Rows.Count == 0)
            {
                //Replace the below code with a select query
                dt.Columns.Add("Category", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Amount", typeof(double));
            }

            foreach (GridViewRow gvr in gvTransactions.Rows)
            {
                dr = dt.NewRow();

                TextBox txtCategory = (TextBox)gvTransactions.FindControl("txtCategory");
                TextBox txtDescription = (TextBox)gvTransactions.FindControl("txtDescription");
                TextBox txtAmount = (TextBox)gvTransactions.FindControl("txtAmount");

                dr[0] = "test1";
                dr[1] = "test2";
                dr[2] = 100.100;

                dt.Rows.Add(dr); // add grid values in to row and add row to the blank table
            }

            dr = dt.NewRow(); // add last empty row
            dt.Rows.Add(dr);

            gvTransactions.DataSource = dt; // bind new datatable to grid
            gvTransactions.DataBind();
        }

        protected void gvTransactions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvTransactions_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvTransactions_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvTransactions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}