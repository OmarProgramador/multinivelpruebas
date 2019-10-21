
namespace BussinesRules
{
    using DataAccess;
    using System;
    using System.Data.SqlClient;

    public class BrWalletToken : brConnection
    {
        public bool PutToken(string userName, string token, DateTime dateEnd, string initialDate, int status, decimal amount, string usernameBen)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaWalletToken daWalletToken = new DaWalletToken();
                    answer = daWalletToken.PutToken(connection, userName, token, dateEnd, initialDate, status, amount, usernameBen);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetInfoToken(string userName, string token, decimal amount)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaWalletToken daWalletToken = new DaWalletToken();
                    answer = daWalletToken.GetInfoToken(connection, userName, token, amount);
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
    }
}
