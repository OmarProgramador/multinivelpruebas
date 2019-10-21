
namespace DataAccess
{
    using System.Data;
    using System.Data.SqlClient;

    public class DaMembershipPayDetail
    {
        public bool EnableByInitial(SqlConnection sqlConnection, string data, string data2)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.ENABLE.BY.INICIAL]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@data2", data2);
            int afferredRows = sqlCommand.ExecuteNonQuery();
            //sqlCommand.Parameters.Clear();
            //sqlCommand.CommandText = "CORE";
            //int i = sqlCommand.ExecuteNonQuery();

            if (afferredRows > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetQuote(SqlConnection sqlConnection, int id, string userName)
        {
            string answer = "0";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.GetAmount]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            var obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                answer = obj.ToString();
            }

            return answer;
        }

        public string GetValueQuoteMaxQuote(SqlConnection connection, int idMembership, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.GetValueQuoteMaxQuote]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }

        public bool PutRecibo(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.PutRecibo]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool PayQuote(SqlConnection connection, int idMembership, string userName, string ticketImage)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.PayQuote]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@ticketImage", ticketImage);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj > 0) answer = true;
            return answer;
        }

        public string GetFullSchedule(SqlConnection connection, string userName, int idAccountTypeMembership)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.GetFullSchedule]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idAccountTypeMembership);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }

        public string GetDescriptionQuote(SqlConnection connection, int idMembership)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.GetDescriptionQuote]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            var data = sqlCommand.ExecuteScalar().ToString();
            if (data != null)
            {
                answer = data.ToString();
            }
            return answer;
        }

        public string GetValueQuoteMaxQuoteChangeSchedule(SqlConnection connection, int idMembership, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.GetValueQuoteMaxQuoteChangeSchedule]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }

        public string GetFullDescriptionQuote(SqlConnection connection, int idMembership, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.GetFullDescriptionQuote]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public bool UpgrateStatusPaymentInitial(SqlConnection sqlConnection, int idAccountTypeMembership, int type, string nameTicket)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.Upgrate.Change.Status.Payment]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@IdAccountTypeMembership", idAccountTypeMembership);
            sqlCommand.Parameters.AddWithValue("@type", type);
            sqlCommand.Parameters.AddWithValue("@nameTicket", nameTicket);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj > 0) answer = true;
            return answer;
        }

        public bool IsPayQuote(SqlConnection connection, string idMembershipDetail)
        {
            bool answer = true;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.IsPayQuote]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembershipDetail", idMembershipDetail);
            int isPay = int.Parse(sqlCommand.ExecuteScalar().ToString());
            if (isPay == 1)
            {
                answer = false;
            }
            return answer;
        }

        public string GetInfoForRecibo(SqlConnection connection, int idMembership)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.GetInfoForRecibo]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }

        public string GetInfoQuoteForRecibo(SqlConnection connection, int idMembership)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.GetInfoQuoteForRecibo]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }

        public bool PutQuotes(SqlConnection connection, int idMembership, int numQuote, string image, int verif)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.PutQuotes]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            sqlCommand.Parameters.AddWithValue("@numQuote", numQuote);
            sqlCommand.Parameters.AddWithValue("@image", image);
            sqlCommand.Parameters.AddWithValue("@verif", verif);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj > 0) answer = true;
            return answer;
        }

        public bool PutQuotesChangingSchedule(SqlConnection connection, int idMembership, int numQuote, string nameImage, int verif)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.PutQuotesChangingSchedule]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembership", idMembership);
            sqlCommand.Parameters.AddWithValue("@numQuote", numQuote);
            sqlCommand.Parameters.AddWithValue("@image", nameImage);
            sqlCommand.Parameters.AddWithValue("@verif", verif);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj > 0) answer = true;
            return answer;
        }

        public string GetDuration(SqlConnection sqlConnection, string codeMembership)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.GetDuration]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@codeMembership", codeMembership);
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }


        public bool UpdateRange(SqlConnection connection, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.RANGE.ACCOUNT.Update]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj > 0) answer = true;
            return answer;
        }

        public bool PutReceiptQuote(SqlConnection connection, string idMembershipDetail, string nameFile)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.PutReceiptQuote]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembershipDetail", idMembershipDetail);
            sqlCommand.Parameters.AddWithValue("@ticketImage", nameFile);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj > 0) answer = true;
            return answer;
        }
    }
}
