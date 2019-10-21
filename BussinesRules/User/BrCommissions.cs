
namespace BussinesRules.User
{
    using System;
    using System.Data.SqlClient;
    using DataAccess.User;

    public class BrCommissions : brConnection
    {
        public string getCommissions(string name)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaCommissions odaUser = new DaCommissions();
                    answer = odaUser.getCommissions(connection, name);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getCommissionsManagement(string name)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaCommissions odaUser = new DaCommissions();
                    answer = odaUser.getCommissionsManagement(connection, name);
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
