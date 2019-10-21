using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Code
{
    public class DaCode
    {
        public string RegisterCode(SqlConnection sqlConnection, string data)
        {
            string answer = "ERROR";
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.Register]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            // if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            if (obj >= 1)
            {
                answer= "True";
            }return answer;
            
        }/*testing*/
        public string GetCode(SqlConnection sqlConnection)
        {
            string answer = "ERROR";
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.GetCodes]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
           
            object obj = sqlCommand.ExecuteScalar();
            // if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            if (!string.IsNullOrEmpty((string)obj))
            { 
                answer = (string)obj;
            }
            return answer;

        }/*testing*/
        public string UpdateCode(SqlConnection sqlConnection, string data)
        {
            string answer = "ERROR";
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.Update]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1)
            {
                answer = "True";
            }
            return answer;

        }

        public string GetCodeExist(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.GetExist]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }

        public string GetCodeSecreto(SqlConnection sqlConnection, string codSecreto)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.GetCodeSecreto]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@codSecreto", codSecreto);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }
    }
}
