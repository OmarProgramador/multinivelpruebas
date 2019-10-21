
namespace BussinesRules
{
    using System;
    using System.Data.SqlClient;
    using DataAccess;

    public class BrUser: brConnection
    {
        public int putUser(string data)
        {
            int answer = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.putUser(connection, data);
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = 0;
                }
            }
            return answer;
        }
    }
}
