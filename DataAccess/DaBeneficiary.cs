using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DaBeneficiary
    {
        public bool Put(SqlConnection sqlConnection, string name, string doc, string parent,string userName,string type)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.BENEFICIARY.Put]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@doc", doc);
            sqlCommand.Parameters.AddWithValue("@parent", parent);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@type", type);

            int rowAf = sqlCommand.ExecuteNonQuery();
            if (rowAf > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string Get(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.BENEFICIARY.Get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }
    }
}
