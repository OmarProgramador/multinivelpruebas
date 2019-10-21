using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaActivation
    {
        public string Get(SqlConnection sqlConnection,string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.ACTIVATION.Get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool PutCronograma(SqlConnection sqlConnection, string cronoActiv, string userName,int ansNmembershi)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.ACTIVATION.PutCronograma]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@cronoActiv", cronoActiv);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@ansNmembershi", ansNmembershi);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        
        public bool PutCronogramaUpgrade(SqlConnection connection, string date, string userName, int ansNmembershi,int idAccountTypeMembership)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.ACTIVATION.PutCronogramaUpgrade]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@date", date);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@ansNmembershi", ansNmembershi);
            sqlCommand.Parameters.AddWithValue("@idAccountTypeMembership", idAccountTypeMembership);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }
    }
}
