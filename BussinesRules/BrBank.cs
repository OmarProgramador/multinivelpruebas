
namespace BussinesRules
{
    using System;
    using System.Data.SqlClient;
    using DataAccess;

    public class BrBank :brConnection
    {
        public string GetData()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaBank oDaBank = new DaBank();
                    answer = oDaBank.GetData(connection);
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
