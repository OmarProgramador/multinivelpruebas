
namespace DataAccess
{
    using System.Data;
    using System.Data.SqlClient;

    public class DaTesteo
    {
        public bool Put(SqlConnection sqlConnection, string error)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.TESTEO.Put]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@error", error);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }
    }
}
