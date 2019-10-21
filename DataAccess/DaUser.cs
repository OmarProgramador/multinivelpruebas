
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaUser
    {
        public int putUser(SqlConnection sqlConnection, string data)
        {
            int answer = 0;
            SqlCommand sqlCommand = new SqlCommand("[usp.User.PutRegister]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@data", data);

            int obj = sqlCommand.ExecuteNonQuery();
            if (obj != 0) answer = 1;

            return answer;
        }

    }
}
