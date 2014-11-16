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
        string UserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    //Response.Redirect("Dashboard.aspx");
                }

                BudgetID = Request.QueryString["BudgetID"];
                Session["BudgetID"] = BudgetID;

                UserId = Request.QueryString["UserId"];
                Session["UserId"] = UserId;

                if (BudgetID != string.Empty)
                {
                    FillBudget();
                }
            }
        }

        private void FillBudget()
        {
            //throw new NotImplementedException();
        }

        protected void SaveBudget_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                UserId = Session["UserId"].ToString();

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

                string sFilePath = Server.MapPath("QuantumForce.accdb");
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
    }
}