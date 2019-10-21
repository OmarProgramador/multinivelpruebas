
namespace DataAccess.User
{
    using System.Data;
    using System.Data.SqlClient;

    public class DaCommissions
    {
        public string getCommissions(SqlConnection sqlConnection, string name)
        {
            string answer = "";
            //SqlCommand sqlCommand = new SqlCommand("[usp.COMISSIONS.get]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.BONUS.Get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", name);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "";
            }
            return answer;
        }

        public string getCommissionsManagement(SqlConnection sqlConnection, string name)
        {
            string answer = "";
            //SqlCommand sqlCommand = new SqlCommand("[usp.COMISSIONS.get]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.BONUS.Get.Management]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", name);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "";
            }
            return answer;
        }

    }
}
