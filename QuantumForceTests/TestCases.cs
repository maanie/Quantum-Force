using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.OleDb;

namespace QuantumForceTests
{
    [TestClass]
    public class TestCases
    {

        private static string sFilePath = "QuantumForce.accdb";

        [ClassInitialize]
        public static void Initialise(TestContext context)
        {
            //Setup User
            string username = "testuser";
            string email = "test@email.com";
            DateTime lastLoginDate = DateTime.Now;

            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand(
                            "insert into tblUser(UserName, Email, LastLoginDate) values('" + username + "','" + email + "','" + lastLoginDate.ToString() + "')", Conn);
                int result = cmd.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void IsUserPresent()
        {
            string userId = null;

            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand(
                    "SELECT UserID FROM tblUser WHERE UserName = 'testuser'", Conn);

                try
                {
                    userId = cmd.ExecuteScalar().ToString();
                }
                catch (Exception e) { }
            }

            Assert.IsNotNull(userId, "User does not exist");
        }

        [TestMethod]
        public void InsertBudget()
        {
            int result = 0;

            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand(
                    "INSERT INTO tblBudget (DomHomePayments, DomRates, DomLevyExp, DomInsurance, DomTelephone, DomTVExp, DomSchoolExp, DomLoans, DomHouseholdExp, DomEntertainment, DomOther, PersLifeAssurance, PersProvidentFund, PersMedicalAid, PersTransport, PersClothing, PersOther, CarMontlyPayments, CarInsurance, CarExpenses, CarPetrol, MonthlyIncome)"
                  + "VALUES (50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,5000)", Conn);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception e) { }

                if (result == 1)
                {
                    cmd.CommandText = "select @@IDENTITY";
                    int latestId = (int)cmd.ExecuteScalar();

                    int userId = FindUser("testuser");

                    cmd.CommandText = "insert into tblUserBudget(UserId, BudgetName, BudgetId) values(" + userId + ", 'TestBudget', " + latestId + ")";

                    result = cmd.ExecuteNonQuery();
                }
            }

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void FindNoBudget()
        {
            string budgetId = null;
            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                int userId = FindUser("testNoUser");

                Conn.Open();
                OleDbCommand cmd = new OleDbCommand(
                    "SELECT BudgetID FROM tblUserBudget WHERE UserID = " + userId, Conn);

                var id = cmd.ExecuteScalar();

                if(id != null)
                {
                    budgetId = id.ToString();
                }
            }

            Assert.IsNull(budgetId, budgetId + " should be null");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM tblBudget", Conn);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM tblUserBudget";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM tblUser";
                cmd.ExecuteNonQuery();
            }
        }

        private static int FindUser(string username)
        {
            int userId = 0;

            using (OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;"))
            {
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT UserID FROM tblUser WHERE UserName = '" + username + "'", Conn);
                var id = cmd.ExecuteScalar();
                Conn.Close();

                if(id != null)
                {
                    userId = (int)id;
                }
            }

            return userId;
        }
    }
}
