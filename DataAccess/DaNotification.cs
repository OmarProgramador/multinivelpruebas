using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaNotification
    {
        public string GetList(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.NOTIFICATION.GetList.By.UserName]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            if (answer == null)
            {
                answer = "";
            }
            return answer;
        }
    }
}
