
namespace DataAccess.TypeMembership
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaTypeMembership
    {
        public string GetTypeMembership(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.TYPE_MEMBERSHIP.GetData]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetKitData(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.TYPE_MEMBERSHIP.GetKit]", sqlConnection);
            //SqlCommand sqlCommand = new SqlCommand("[usp.TYPE_MEMBERSHIP.GetData]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetListAccount(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.N_MEMBERSHIP.GetList.Account]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetListCodeMemberships(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.N_MEMBERSHIP.GetListCodeMemberships]", connection);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }

        public string GetListMemberships(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.N_MEMBERSHIP.List]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }

        public string GetTotalMemberships(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.N_MEMBERSHIP.Count]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }
        public string GetUpdateBanner(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.Update.Banner]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idUser", userName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }
        public bool UpdateNextDay(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.Update.Banner]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            int filasAffec = sqlCommand.ExecuteNonQuery();
            if (filasAffec > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool AddMembershipUser(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.N_MEMBERSHIP.Add]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            int filasAffec = sqlCommand.ExecuteNonQuery();
            if (filasAffec > 0)
            {
                answer = true;
            }
            return answer;
        }
       

        public string GetMembersLastUser(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.N_MEMBERSHIP.Get.BY.UserName]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }

        public string GetTypeMembership(SqlConnection sqlConnection, int idAccount_N_Membership)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.N_MEMBERSHIP.Get.BY.Id]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", idAccount_N_Membership);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }

        public bool CancelMembershipUpgrate(SqlConnection sqlConnection, int codeUpgrate, int nuevoNmembershi)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.N_MEMBERSHIP.CancelMembershipUpgrate]", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idAccountTypeMembership", codeUpgrate);
            sqlCommand.Parameters.AddWithValue("@idnuevoMembership", nuevoNmembershi);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            int filasAffec = sqlCommand.ExecuteNonQuery();
            if (filasAffec > 0)
            {
                answer = true;
            }
            return answer;
        }
    }
}
