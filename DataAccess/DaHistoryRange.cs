using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaHistoryRange
    {
        public string GetListRange(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.HISTORY.RANGE.AFILIATION.GetList]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }

        public bool PutHistoryRangePeriod(SqlConnection connection, int idBonusPeriod)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.HISTORY.RANGE.AFILIATION.Put]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idBonusPeriod", idBonusPeriod);

            int rowAf = sqlCommand.ExecuteNonQuery();
            if (rowAf > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool PutHistoryRangeResidualPeriod(SqlConnection connection, int idBonusPeriod)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.RANGE.HISTORY.Put]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idBonusPeriod", idBonusPeriod);

            int rowAf = sqlCommand.ExecuteNonQuery();
            if (rowAf > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetListRangeResidual(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.RANGE.HISTORY.GetList]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }
    }
}
