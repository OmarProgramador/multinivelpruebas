using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DaPartner
    {
        public string Get(SqlConnection sqlConnection, int status)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Partner.Get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@status", status);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }


        public string Filter(SqlConnection connection, string value)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Partner.Filter]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@value", value);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetEmailBussines(SqlConnection sqlConnection, int status)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Partner.GetEmailBussines]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@status", status);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetNotEmailBussines(SqlConnection sqlConnection, int status)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Partner.GetNotEmailBussines]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@status", status);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool SetEmailBussines(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.Partner.SetEmailBussines]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }
        public bool DeleteEmailBussines(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.Partner.DeleteEmailBussines]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool Assign(SqlConnection connection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.Partner.Assign]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }
    }
}
