
namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DaPlacement
    {
        public string GetSponsored(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Placement.GetSponsored]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetUpliners(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Placement.GetUpliners]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }
    }
}
