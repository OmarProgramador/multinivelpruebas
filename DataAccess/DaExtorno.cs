
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaExtorno
    {
        public string ExtornarAccount(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.EXTORNO.ExtornarAccount]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetListAdmin(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.EXTORNO.GetListAdmin]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }
    }
}
