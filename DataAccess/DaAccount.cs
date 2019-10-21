
namespace DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaAccount
    {
        public string GetLastCodeMembership(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.UserGetMembership]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool Exist(SqlConnection connection, int personId)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.PersonExist]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@IdPerson", personId);

            var result = int.Parse(sqlCommand.ExecuteScalar().ToString());

            if (result == 1)
            {
                answer = true;
            }

            return answer;
        }

        public bool Exist(SqlConnection connection, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.AccountExist]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var result = int.Parse(sqlCommand.ExecuteScalar().ToString());

            if (result == 1)
            {
                answer = true;
            }

            return answer;
        }

        public string GetTypesChange(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.TYPE.CHANGE.Gets]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //venta y compra
            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }

        public string GetUserNotConfirmedPayInitial(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetUserNotConfirmedPayInitial]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }

        public string GetAffiliateName(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetAffiliateName]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetStatus(SqlConnection connection, string userName)
        {
            string answer = "0";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetStatus.By.UserName]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public bool RefreshStatusBonusWallet(SqlConnection connection, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.BONUS.WALLET.Refresh.Status.Activation]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool DeleteAccountUnconfirmed(SqlConnection connection)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.DeleteAccountUnconfirmed]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            var result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool UpdateRange(SqlConnection connection, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.UpdateRange]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetSponsorInfo(SqlConnection connection, string usernameChildren)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetSponsorInfo]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", usernameChildren);

            var data = sqlCommand.ExecuteScalar();
            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public string GetFirtsPayCurrency(SqlConnection connection, object userName)
        {
            string answer = "0";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetFirtsPayCurrency]", connection);
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
