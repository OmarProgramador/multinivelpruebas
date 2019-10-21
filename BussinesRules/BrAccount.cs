
namespace BussinesRules
{
    using DataAccess;
    using System;
    using System.Data.SqlClient;

    public class BrAccount : brConnection
    {
        public string GetLastCodeMembership(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.GetLastCodeMembership(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = "";
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetUserNotConfirmedPayInitial()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.GetUserNotConfirmedPayInitial(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = "";
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool Exist(int personId)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.Exist(connection, personId);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool Exist(string userName)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.Exist(connection, userName);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetAffiliateName(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.GetAffiliateName(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = "";
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool DeleteAccountUnconfirmed()
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.DeleteAccountUnconfirmed(connection);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetSponsorInfo(string usernameChildren)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.GetSponsorInfo(connection, usernameChildren);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = "";
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetStatus(string userName)
        {
            string answer = "0";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.GetStatus(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = "0";
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetFirtsPayCurrency(string username)
        {
            string answer = "0";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.GetFirtsPayCurrency(connection, username);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = "0";
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool RefreshStatusBonusWallet(string userName)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.RefreshStatusBonusWallet(connection, userName);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool UpdateRange(string userName)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.UpdateRange(connection, userName);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }
    }
}
