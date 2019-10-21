
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaWallet
    {
        public string Get(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.Get]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool Put(SqlConnection connection, SqlTransaction transaction, string data, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.PutPayQuote]", connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                transaction.Commit();
                answer = true;
            }
            return answer;
        }

        public string GetAdminMake(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.WALLET.DOC.GetAdminMake]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public string GetAdmin(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.WALLET.DOC.GetAdmin]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetAmount(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.GetAmount]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetBalance(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.GetBalance]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool PutDoc(SqlConnection connection, string userName, string fileName, decimal requestedAmount)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.WALLET.DOC.PutDoc]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@fileName", fileName);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@amount", requestedAmount);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool ChangeStatus(SqlConnection connection, int id, string obs, int status)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.WALLET.DOC.ChangeStatus]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idWalletDoc", id);
            sqlCommand.Parameters.AddWithValue("@obs", obs);
            sqlCommand.Parameters.AddWithValue("@status", status);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool PutPayAmortization(SqlConnection connection, decimal amountAmort, decimal typeChangeBuy, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.PutPayAmortization]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@amountAmort", amountAmort);
            sqlCommand.Parameters.AddWithValue("@typeChange", typeChangeBuy);
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool PutPayService(SqlConnection connection, string data, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.PutPayService]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool PutVoucher(SqlConnection connection, int id, string obs, string voucher)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.WALLET.DOC.PutVoucher]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@obs", obs);
            sqlCommand.Parameters.AddWithValue("@voucher", voucher);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetDocsByUser(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.GetDocsByUser]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public bool PutAdvancePay(SqlConnection connection, decimal amount, decimal typeChange, string userName, int idMembership)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.PutAdvancePay]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@amount", amount);
            sqlCommand.Parameters.AddWithValue("@typeChange", typeChange);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool Put(SqlConnection connection, SqlTransaction transaction, string data, string userName, int moneyStatus)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.PossibleReturn]", connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@moneyStatus", moneyStatus);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                transaction.Commit();
                answer = true;
            }
            return answer;
        }

        public bool PutTransferenciaBetwenWallet(SqlConnection connection, SqlTransaction transaction, string userNameBeneficiary, string userName, decimal amount)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.PutTransferenciaBetwenWallet]", connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userNameBeneficiary", userNameBeneficiary);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@amount", amount);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                transaction.Commit();
                answer = true;
            }
            return answer;
        }
    }
}
