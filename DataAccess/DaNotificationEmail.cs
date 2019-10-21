
namespace DataAccess
{
    using System.Data;
    using System.Data.SqlClient;

    public class DaNotificationEmail
    {
        public string GetListEmail(SqlConnection connection, int days)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ALERTS.PayQuote]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@days", days);
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }

        public string GetListDeudaEmail(SqlConnection connection, int days, int deuda)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ALERTS.PayQuoteDeuda2]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@days", days);
            sqlCommand.Parameters.AddWithValue("@deuda", deuda);
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }
    }
}
