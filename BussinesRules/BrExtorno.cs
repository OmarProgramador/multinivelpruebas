
namespace BussinesRules
{
    using System;
    using System.Data.SqlClient;
    using DataAccess;

    public class BrExtorno : brConnection
    {
        public string ExtornarAccount(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaExtorno daExtorno = new DaExtorno();
                    answer = daExtorno.ExtornarAccount(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = "";
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetListAdmin()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaExtorno daExtorno = new DaExtorno();
                    answer = daExtorno.GetListAdmin(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = "";
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
    }
}
