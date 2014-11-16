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
    public partial class Budget : System.Web.UI.Page
    {
        string BudgetID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("Dashboard.aspx");
                }

                if (Request.QueryString["BudgetID"] != null)
                {
                    BudgetID = Request.QueryString["BudgetID"];
                    Session["BudgetID"] = BudgetID;
                    FillBudget();
                }
                else
                {
                    Session["BudgetID"] = null;
                }
            }
        }

        private void FillBudget()
        {
            string sFilePath = Server.MapPath("QuantumForce.accdb");
            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand(
                    "select * from tblBudget where BudgetId = " + Session["BudgetID"].ToString(), Conn);

                OleDbDataAdapter oDA = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                oDA.Fill(dt);

                #region SetTextFields
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "DomHomePayments")
                            {
                                DomHomePayments.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomRates")
                            {
                                DomRates.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomLevyExp")
                            {
                                DomLevyExp.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomInsurance")
                            {
                                DomInsurance.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomTelephone")
                            {
                                DomTelephone.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomTVExp")
                            {
                                DomTVExp.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomSchoolExp")
                            {
                                DomSchoolExp.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomLoans")
                            {
                                DomLoans.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomHouseholdExp")
                            {
                                DomHouseholdExp.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomEntertainment")
                            {
                                DomEntertainment.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "DomOther")
                            {
                                DomOther.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "PersLifeAssurance")
                            {
                                PersLifeAssurance.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "PersProvidentFund")
                            {
                                PersProvidentFund.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "PersMedicalAid")
                            {
                                PersMedicalAid.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "PersTransport")
                            {
                                PersTransport.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "PersClothing")
                            {
                                PersClothing.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "PersOther")
                            {
                                PersOther.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "CarMontlyPayments")
                            {
                                CarMonthlyPayments.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "CarInsurance")
                            {
                                CarInsurance.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "CarExpenses")
                            {
                                CarExpenses.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "CarPetrol")
                            {
                                CarPetrol.Value = row[col].ToString();
                            }
                            else if (col.ColumnName == "MonthlyIncome")
                            {
                                MonthlyIncome.Value = row[col].ToString();
                            }
                        }
                    }
                }
                #endregion

                cmd.CommandText = ("select BudgetName from tblUserBudget where BudgetID = " + Session["BudgetID"].ToString());
                BudgetName.Value = cmd.ExecuteScalar().ToString();
            }
        }

        protected void SaveBudget_Click(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                string sFilePath = Server.MapPath("QuantumForce.accdb");
                int UserId = HelperMethods.FindUser(User.Identity.Name, sFilePath);

                int intDomHomePayments = 0, intDomRates = 0, intDomLevyExp = 0, intDomInsurance = 0, intDomTelephone = 0, intDomTVExp = 0,
                    intDomSchoolExp = 0, intDomLoans = 0, intDomHouseholdExp = 0, intDomEntertainment = 0, intDomOther = 0, intPersLifeAssurance = 0,
                    intPersProvidentFund = 0, intPersMedicalAid = 0, intPersTransport = 0, intPersClothing = 0, intPersOther = 0,
                    intCarMonthlyPayments = 0, intCarInsurance = 0, intCarExpenses = 0, intCarPetrol = 0, intMonthlyIncome = 0;
                int validInt = 0;

                #region AssignVariables
                if (Int32.TryParse(DomHomePayments.Value, out validInt))
                {
                    intDomHomePayments = validInt;
                }

                if (Int32.TryParse(DomRates.Value, out validInt))
                {
                    intDomRates = validInt;
                }

                if (Int32.TryParse(DomLevyExp.Value, out validInt))
                {
                    intDomLevyExp = validInt;
                }

                if (Int32.TryParse(DomInsurance.Value, out validInt))
                {
                    intDomInsurance = validInt;
                }

                if (Int32.TryParse(DomTelephone.Value, out validInt))
                {
                    intDomTelephone = validInt;
                }

                if (Int32.TryParse(DomTVExp.Value, out validInt))
                {
                    intDomTVExp = validInt;
                }

                if (Int32.TryParse(DomSchoolExp.Value, out validInt))
                {
                    intDomSchoolExp = validInt;
                }

                if (Int32.TryParse(DomLoans.Value, out validInt))
                {
                    intDomLoans = validInt;
                }

                if (Int32.TryParse(DomHouseholdExp.Value, out validInt))
                {
                    intDomHouseholdExp = validInt;
                }

                if (Int32.TryParse(DomEntertainment.Value, out validInt))
                {
                    intDomEntertainment = validInt;
                }

                if (Int32.TryParse(DomOther.Value, out validInt))
                {
                    intDomOther = validInt;
                }

                if (Int32.TryParse(PersLifeAssurance.Value, out validInt))
                {
                    intPersLifeAssurance = validInt;
                }

                if (Int32.TryParse(PersProvidentFund.Value, out validInt))
                {
                    intPersProvidentFund = validInt;
                }

                if (Int32.TryParse(PersMedicalAid.Value, out validInt))
                {
                    intPersMedicalAid = validInt;
                }

                if (Int32.TryParse(PersTransport.Value, out validInt))
                {
                    intPersTransport = validInt;
                }

                if (Int32.TryParse(PersClothing.Value, out validInt))
                {
                    intPersClothing = validInt;
                }

                if (Int32.TryParse(PersOther.Value, out validInt))
                {
                    intPersOther = validInt;
                }

                if (Int32.TryParse(CarMonthlyPayments.Value, out validInt))
                {
                    intCarMonthlyPayments = validInt;
                }

                if (Int32.TryParse(CarInsurance.Value, out validInt))
                {
                    intCarInsurance = validInt;
                }

                if (Int32.TryParse(CarExpenses.Value, out validInt))
                {
                    intCarExpenses = validInt;
                }

                if (Int32.TryParse(CarPetrol.Value, out validInt))
                {
                    intCarPetrol = validInt;
                }

                if (Int32.TryParse(MonthlyIncome.Value, out validInt))
                {
                    intMonthlyIncome = validInt;
                }
                #endregion

                using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
                {
                    if (Session["BudgetID"] != null)
                    {
                        BudgetID = Session["BudgetID"].ToString();
                        int budgetId = Int32.Parse(BudgetID);

                        Conn.Open();
                        OleDbCommand cmd = new OleDbCommand(
                            "update tblBudget set DomHomePayments = " + intDomHomePayments + ", DomRates = " + intDomRates + ", DomLevyExp = " + intDomLevyExp + ", DomInsurance = " + intDomInsurance + ", DomTelephone = " + intDomTelephone + ", DomTVExp = " + intDomTVExp + ", DomSchoolExp = " + intDomSchoolExp + ", DomLoans = " + intDomLoans + ", DomHouseholdExp = " + intDomHouseholdExp + ", DomEntertainment = " + intDomEntertainment + ", DomOther = " + intDomOther
                            + ", PersLifeAssurance = " + intPersLifeAssurance + ", PersProvidentFund = " + intPersProvidentFund + ", PersMedicalAid = " + intPersMedicalAid + ", PersTransport = " + intPersTransport + ", PersClothing = " + intPersClothing + ", PersOther = " + intPersOther
                            + ", CarMonthlyPayments = " + intCarMonthlyPayments + ", CarInsurance = " + intCarInsurance + ", CarExpenses = " + intCarExpenses + ", CarPetrol = " + intCarPetrol + ", MonthlyIncome = " + intMonthlyIncome + " where BudgetID = " + budgetId, Conn);

                        int result = cmd.ExecuteNonQuery();

                        Conn.Close();
                        if (result == 1)
                        {
                            Response.Redirect("BudgetManagement.aspx");
                        }
                    }
                    else
                    {
                        Conn.Open();
                        OleDbCommand cmd = new OleDbCommand(
                            "insert into tblBudget(DomHomePayments, DomRates, DomLevyExp, DomInsurance, DomTelephone, DomTVExp, DomSchoolExp, DomLoans, DomHouseholdExp, DomEntertainment, DomOther, PersLifeAssurance, PersProvidentFund, PersMedicalAid, PersTransport, PersClothing, PersOther, CarMontlyPayments, CarInsurance, CarExpenses, CarPetrol, MonthlyIncome)"
                          + "values(" + intDomHomePayments + "," + intDomRates + "," + intDomLevyExp + "," + intDomInsurance + "," + intDomTelephone + "," + intDomTVExp + "," + intDomSchoolExp + "," + intDomLoans + "," + intDomHouseholdExp + "," + intDomEntertainment + "," + intDomOther + "," + intPersLifeAssurance + "," + intPersProvidentFund + "," + intPersMedicalAid + "," + intPersTransport + "," + intPersClothing + "," + intPersOther + "," + intCarMonthlyPayments + "," + intCarInsurance + "," + intCarExpenses + "," + intCarPetrol + "," + intMonthlyIncome + ")", Conn);

                        int result = cmd.ExecuteNonQuery();

                        cmd.CommandText = "select @@IDENTITY";

                        int latestId = (int)cmd.ExecuteScalar();

                        cmd.CommandText = "insert into tblUserBudget(UserId, BudgetName, BudgetId) values(" + UserId + ", '" + BudgetName.Value + "', " + latestId + ")";

                        result = cmd.ExecuteNonQuery();

                        Conn.Close();
                        if (result == 1)
                        {
                            Response.Redirect("BudgetManagement.aspx");
                        }
                    }
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("BudgetManagement.aspx");
        }
    }
}