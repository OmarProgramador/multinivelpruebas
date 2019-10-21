

namespace DataAccess.Consuption
{
    using System.Data;
    using System.Data.SqlClient;
 
    public class DaConsuption
    {
        public string GetAmountConsuption(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.CONSUPTION.Query]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }
        public bool RegisterConsuptionPayDetail(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.CONSUPTION.PutPayRegister]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int affecteRows = sqlCommand.ExecuteNonQuery();
            if (affecteRows > 0)
            {
                answer = true;
            }           
            return answer;
        }
    }
}
