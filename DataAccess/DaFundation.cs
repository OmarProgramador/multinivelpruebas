
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaFundation
    {
        public string GetCount(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.FUNDATION.COUNT.Get]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
           
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetEmail(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.FUNDATION.COUNT.GetEmail]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }
    }
}
