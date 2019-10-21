
namespace BussinesRules
{
    using System;
    using System.Data.SqlClient;
    using DataAccess;

    public class BrFundation : brConnection
    {
        public string GetCount()
        {
            string answer = "0";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaFundation daFundation = new DaFundation();
                    answer = daFundation.GetCount(connection);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    answer = "0";
                    RecordLog(ex.Message, ex.StackTrace);
                }
            }
            return answer;
        }

        public string GetEmail()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaFundation daFundation = new DaFundation();
                    answer = daFundation.GetEmail(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
    }
}
