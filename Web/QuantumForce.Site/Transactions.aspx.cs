using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Drawing;

namespace QuantumForce.Site
{
    public partial class Transactions : System.Web.UI.Page
    {
        DataTable dt;
        OleDbConnection Conn;
        protected void Page_Load(object sender, EventArgs e)
        {

            string sFilePath = Server.MapPath("QuantumForce.accdb");
            Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;");
            
            if (!IsPostBack)
            {
                loadTransactions();
            }
        }

        protected void loadTransactions()
        {
            using (Conn)
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT ID, refCategory, tblCategory.CategoryName as Category, Description, Amount FROM tblTransaction LEFT JOIN tblCategory ON tblTransaction.refCategory = tblCategory.CategoryID ", Conn);
                OleDbDataAdapter oDA = new OleDbDataAdapter(cmd);
                dt = new DataTable();
                oDA.Fill(dt);

                int count = dt.Rows.Count;
                Conn.Close();
                if (dt.Rows.Count > 0)
                {
                    gvTransactions.DataSource = dt;
                    gvTransactions.DataBind();
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    gvTransactions.DataSource = dt;
                    gvTransactions.DataBind();
                    int columncount = gvTransactions.Rows[0].Cells.Count;
                    lblmsg.Text = " No data found !!!";
                }
            }
        }

        protected void gvTransactions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvTransactions.DataKeys[e.RowIndex].Values["ID"].ToString();
            Conn.Open();
            OleDbCommand cmd = new OleDbCommand("DELETE from tblTransaction where ID=" + id, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            if (result == 1)
            {
                loadTransactions();
                //Add delete msg later
                lblmsg.BackColor = Color.Red;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = "Transaction " + id + "      Deleted successfully.......    ";
            }
        }

        protected void gvTransactions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTransactions.EditIndex = e.NewEditIndex;
            loadTransactions();
        }

        protected void gvTransactions_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTransactions.EditIndex = -1;
            loadTransactions();
        }

        protected void gvTransactions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gvTransactions.DataKeys[e.RowIndex].Values["ID"].ToString();
            DropDownList txtCategory = (DropDownList)gvTransactions.Rows[e.RowIndex].FindControl("txtCategory");
            TextBox Description = (TextBox)gvTransactions.Rows[e.RowIndex].FindControl("txtDescription");
            TextBox Amount = (TextBox)gvTransactions.Rows[e.RowIndex].FindControl("txtAmount");

            Conn.Open();
            OleDbCommand cmd = new OleDbCommand("update tblTransaction set refCategory= " + txtCategory.SelectedValue + ", Description='" + Description.Text + "', Amount=" + Amount.Text + " where ID=" + id, Conn);
            cmd.ExecuteNonQuery();
            Conn.Close();
            lblmsg.BackColor = Color.Blue;
            lblmsg.ForeColor = Color.White;
            lblmsg.Text = "Transaction " + id + "        Updated successfully........    ";
            gvTransactions.EditIndex = -1;
            loadTransactions();
        }

        protected void gvTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                DropDownList inCategory = (DropDownList)gvTransactions.FooterRow.FindControl("inCategory");
                TextBox inDescription = (TextBox)gvTransactions.FooterRow.FindControl("inDescription");
                TextBox inAmount = (TextBox)gvTransactions.FooterRow.FindControl("inAmount");
            
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand(
                        "insert into tblTransaction(refCategory, Description, Amount) values(" + (inCategory.SelectedValue == "" ? "-1" : inCategory.SelectedValue) + ",'" +
                        inDescription.Text + "'," + (inAmount.Text == "" ? "0": inAmount.Text) + ")", Conn);
                int result = cmd.ExecuteNonQuery();
                Conn.Close();
                if (result == 1)
                {
                    loadTransactions();
                    lblmsg.BackColor = Color.Green;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = "Transaction Added successfully......    ";
                }
                else
                {
                    lblmsg.BackColor = Color.Red;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = " Error while adding row.....";
                }
            }
        }

        protected void gvTransactions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlList = (DropDownList)e.Row.FindControl("txtCategory");
                    // bind DropDown manually
                    ddlList.DataSource = getCategories();
                    ddlList.DataTextField = "CategoryName";
                    ddlList.DataValueField = "CategoryID";
                    ddlList.DataBind();
                    ddlList.Items.Insert(0, new ListItem("Select", "-1"));

                  
                }
            }

            /*DropDownList ddlList2 = (DropDownList)e.Row.FindControl("inCategory");
            // bind DropDown manually
            ddlList2.DataSource = getCategories();
            ddlList2.DataTextField = "CategoryName";
            ddlList2.DataValueField = "CategoryID";
            ddlList2.DataBind();
            ddlList2.Items.Insert(0, new ListItem("Select", "-1"));*/

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + id + "')");
                }
            }
         
        }

        protected DataTable getCategories()
        {
             string sFilePath = Server.MapPath("QuantumForce.accdb");

            OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;");
            dt = new DataTable();
            using (Conn)
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CategoryID, CategoryName FROM tblCategory Order by CategoryName", Conn);
                OleDbDataAdapter oDA = new OleDbDataAdapter(cmd);
                
                oDA.Fill(dt);
            }
            return dt;
        }


    }
}