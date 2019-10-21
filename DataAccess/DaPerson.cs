
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaPerson
    {
        public bool CoAfiliadoModiefied(SqlConnection connection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.CoAfiliadoModiefied]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetFullName(SqlConnection connection, string document)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.GetFullName]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@document", document);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetByUserName(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.GetByUserName]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }
    }
}
