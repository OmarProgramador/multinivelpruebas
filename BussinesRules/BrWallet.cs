
namespace BussinesRules
{
    using DataAccess;
    using System;
    using System.Data.SqlClient;

    public class BrWallet : brConnection
    {
        public string Get(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.Get(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetAdminMake()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.GetAdminMake(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetAdmin()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.GetAdmin(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetBalance(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.GetBalance(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool Put(string data, string userName)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction;
                    // Start a local transaction.
                    transaction = connection.BeginTransaction("SampleTransaction");
                    DaWallet daWallet = new DaWallet();
                    //data=amount|@idInfo|@typeInfo|@walletOperationId|@currencyCode|@typeChange|idmembershipDetail|imgTicket
                    try
                    {
                        answer = daWallet.Put(connection, transaction, data, userName);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            string error = $"{ex.Message}|{ex2.Message}";
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool PutPayAmortization(decimal amountAmortSoles, decimal typeChangeBuy, string userName)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.PutPayAmortization(connection, amountAmortSoles, typeChangeBuy, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = false;
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutPayService(string data, string userName)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.PutPayService(connection, data, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = false;
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutVoucher(int id, string obs, string voucher)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.PutVoucher(connection, id, obs, voucher);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = false;
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutAdvancePay(decimal amount, decimal typeChange, string userName, int idMembership)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.PutAdvancePay(connection, amount, typeChange, userName, idMembership);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = false;
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetDocsByUser(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.GetDocsByUser(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool ChangeStatus(int id, string obs, int status)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.ChangeStatus(connection, id, obs, status);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = false;
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutDoc(string userName, string fileName, decimal RequestedAmount)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.PutDoc(connection, userName, fileName, RequestedAmount);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = false;
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetAmount(string userName)
        {
            string answer = "0";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWallet daWallet = new DaWallet();
                    answer = daWallet.GetAmount(connection, userName);
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

        public bool Put(string data, string userName, int moneyStatus)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction;
                    // Start a local transaction.
                    transaction = connection.BeginTransaction("SampleTransaction");
                    DaWallet daWallet = new DaWallet();
                    //data=amount|@idInfo|@typeInfo|@walletOperationId|@currencyCode|@typeChange|idmembershipDetail|imgTicket
                    try
                    {
                        answer = daWallet.Put(connection, transaction, data, userName, moneyStatus);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            string error = $"{ex.Message}|{ex2.Message}";
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool PutTransferenciaBetwenWallet(string userNameBeneficiary, string userName, decimal amount)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction;
                    // Start a local transaction.
                    transaction = connection.BeginTransaction("SampleTransaction");
                    DaWallet daWallet = new DaWallet();
                    //data=amount|@idInfo|@typeInfo|@walletOperationId|@currencyCode|@typeChange|idmembershipDetail|imgTicket
                    try
                    {
                        answer = daWallet.PutTransferenciaBetwenWallet(connection, transaction, userNameBeneficiary, userName, amount);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            string error = $"{ex.Message}|{ex2.Message}";
                        }
                    }
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
