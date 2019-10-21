using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesRules
{
    public class BrNotification : brConnection
    {
        public string GetList(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaNotification daNotification = new DaNotification();
                    answer = daNotification.GetList(connection, userName);
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
