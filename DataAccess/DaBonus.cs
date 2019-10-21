
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaBonus
    {
      
        public string GetPeriod(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.BONUS.PERIOD.GetPeriod]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }

        public string GetListBonus(SqlConnection connection, string userName, int idPeriod)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.BONUS.GetListBonus]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@idPeriod", idPeriod);

            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public string GetFullPeriod(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.BONUS.PERIOD.GetFullPeriod]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public bool ChangeStatus(SqlConnection connection, int idBonusPeriod, int status)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.BONUS.PERIOD.ChangeStatus]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idBonusPeriod", idBonusPeriod);
            sqlCommand.Parameters.AddWithValue("@status", status);

            var result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool PutPeriod(SqlConnection connection, string from, string until, string payDate)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.BONUS.PERIOD.PutPeriod]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@from", from);
            sqlCommand.Parameters.AddWithValue("@until", until);
            sqlCommand.Parameters.AddWithValue("@payDate", payDate);

            var result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool PayBonus(SqlConnection connection, int id)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.WALLET.PERIOD.PayCommissions]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", id);

            var result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetEmailPayWallet(SqlConnection connection, int id)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.WALLET.GetEmailPayWallet]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPeriod", id); 
            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }
    }
}
