
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaInformacion
    {
        public string GetInformation(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PARAMETER.Get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
          
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetTextExonerarDB(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.INFORMATION.BD.GetTextExon]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }
        public string GetBYIdMembershipDetail(SqlConnection sqlConnection,int data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.INFORMATION.Get.BY.IdMembershipDetail]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
           // sqlCommand.Parameters.AddWithValue("@data2", data2);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }
        public string GetBYNunDoc(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.INFORMATION.Get.BY.NumDoc]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            if (answer == null)
            {
                answer = "";
            }
            return answer;
        }

        public string GetPointsLines(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            //SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetCurrentPoints.PowerLine]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetPointsLines]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "0|0";
            }
            return answer;
        }

        public bool ActiveUp(SqlConnection sqlConnection)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.VALIDATION.ActiveUp]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
           
            int row = sqlCommand.ExecuteNonQuery();
            if (row > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetNextRange(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            if (answer == null)
            {
                answer = "";
            }
            return answer;
        }

        public string GetCurrentAndNextRange(SqlConnection sqlConnection, string range)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Account.GetCurrentAndNextRange]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@range", range);
            answer = (string)sqlCommand.ExecuteScalar();
            if (answer == null)
            {
                answer = "";
            }
            return answer;
        }

        public string GetPointsLinesResid(SqlConnection connection, string userName)
        {
            string answer = "0|1¬0|2¬0|3¬0|4";
            //SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetCurrentPoints.PowerLine]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetPointsLinesResidual]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
                if (string.IsNullOrEmpty(answer))
                {
                    answer = "0|1¬0|2¬0|3¬0|4";
                }
            }
            return answer;
        }

        public string GetMaximiumMinium(SqlConnection connection, string range)
        {
            string answer = "0|1¬0|2¬0|3¬0|4";
            //SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetCurrentPoints.PowerLine]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.RANGE.GetMaximiumMinium]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@range", range);
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
                if (string.IsNullOrEmpty(answer))
                {
                    answer = "0|1¬0|2¬0|3¬0|4";
                }
            }
            return answer;
        }

        public string GetRangeResidualCurrent(SqlConnection connection, string userName)
        {
            string answer = "";
            //SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetCurrentPoints.PowerLine]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.RANGE.GetRangeResidualCurrent]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();                 
            }
            return answer;
        }

        public string GetPointsRange(SqlConnection connection, string range)
        {
            string answer = "";
            //SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetCurrentPoints.PowerLine]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.RANGE.GetPointsRange]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@range", range);
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }

        public string GetPointsRangeProximo(SqlConnection connection, string range)
        {
            string answer = "";
            //SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetCurrentPoints.PowerLine]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.RANGE.GetPointsRangeProximo]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@range", range);
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }
    }
}
