
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaWalletToken
    {
        public bool PutToken(SqlConnection connection, string userName, string token, DateTime endDate, string initialDate, int status, decimal amount, string usernameBen)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.WALLET.TOKEN.PutToken]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@token", token);
            sqlCommand.Parameters.AddWithValue("@endDate", endDate);
            sqlCommand.Parameters.AddWithValue("@initialDate", initialDate);
            sqlCommand.Parameters.AddWithValue("@status", status);
            sqlCommand.Parameters.AddWithValue("@amount", amount);
            sqlCommand.Parameters.AddWithValue("@usernameBen", usernameBen);

            var result = sqlCommand.ExecuteNonQuery();

            if (result >= 1)
            {
                answer = true;
            }

            return answer;
        }

        public string GetInfoToken(SqlConnection connection, string userName, string token, decimal amount)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.WALLET.TOKEN.GetInfoToken]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@token", token);
            sqlCommand.Parameters.AddWithValue("@amount", amount);

            var reader =  sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                answer = reader[0].ToString();
                answer += "|" + reader[1].ToString();
                answer += "|" + reader[2].ToString();
            }
            
            return answer;
        }
    }
}
