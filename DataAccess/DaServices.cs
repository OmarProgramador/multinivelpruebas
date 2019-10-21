using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaServices
    {
        public string GetPendient(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.SALES.SERVICES.Pendent]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }

        public bool PayService(SqlConnection sqlConnection, int id, string userName, int status, string obs, decimal price)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.SALES.SERVICES.PayService]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@status", status);
            sqlCommand.Parameters.AddWithValue("@obs", obs);
            sqlCommand.Parameters.AddWithValue("@price", price);

            int rowAffected = sqlCommand.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetHotel2(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.SALE.SERVICES.GetHotel2]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }
    }
}
