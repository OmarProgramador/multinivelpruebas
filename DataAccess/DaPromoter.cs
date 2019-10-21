
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaPromoter
    {
        public string GetListByUserName(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PROMOTER.GetListByUserName]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public bool SaveCode(SqlConnection connection, string userName, string code)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.PROMOTER.SaveCode]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@code", code);

            var result = sqlCommand.ExecuteNonQuery();

            if (result == 1)
            {
                answer = true;
            }

            return answer;
        }

        public string GetCodeByUserName(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PROMOTER.GetCode]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public bool IsCodeValid(SqlConnection connection, string code, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.PROMOTER.IsCodeValid]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@code", code);

            var result = sqlCommand.ExecuteScalar();

            if (result != null)
            {
                if (Convert.ToInt32(result) == 1)
                {
                    answer = true;
                }
            }

            return answer;
        }
    }
}
