using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaDaysFree
    {
        public bool Put(SqlConnection connection, string userName, int numberDays, int idMembership)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.DAYS.FREE.Put]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;          
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@numberDays", numberDays);
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool Qualify(SqlConnection connection, string userName, int idMembership)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.DAYS.FREE.Qualify]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);

            answer = Convert.ToBoolean(sqlCommand.ExecuteScalar().ToString());
            
            return answer;
        }

        public string GetDaysByUserName(SqlConnection connection, string userName, int idMembership)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.DAYS.FREE.GetDaysByUserName]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@idAccountTypeMembership", idMembership);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }
    }
}
