

namespace BussinesRules
{
    using DataAccess;
    using System;
    using System.Data.SqlClient;

    public class BrNotificationEmail : brConnection
    {
        public string GetListEmail(int days)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaNotificationEmail daInformacion = new DaNotificationEmail();
                    answer = daInformacion.GetListEmail(connection, days);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "";
                }
            }
            return answer;
        }

        public string GetListDeudaEmail(int days, int deuda)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaNotificationEmail daInformacion = new DaNotificationEmail();
                    answer = daInformacion.GetListDeudaEmail(connection, days, deuda);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "";
                }
            }
            return answer;
        }
    }
}
