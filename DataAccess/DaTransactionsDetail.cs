using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaTransactionsDetail
    {
        public string Get(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.TRANSACTIONS.Get]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

    }
}
