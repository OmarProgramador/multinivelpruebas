using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BussinesRules
{
    public class BrServices : brConnection
    {
        public string GetPendient()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaServices daServices = new DaServices();
                    answer = daServices.GetPendient(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PayService(int id, string userName, int status, string obs, decimal price)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaServices daServices = new DaServices();
                    answer = daServices.PayService(connection, id, userName, status, obs, price);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetHotel2(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaServices daServices = new DaServices();
                    answer = daServices.GetHotel2(connection, userName);
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
