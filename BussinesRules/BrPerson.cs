
namespace BussinesRules
{
    using System;
    using System.Data.SqlClient;
    using DataAccess;

    public class BrPerson : brConnection
    {
        public bool CoAfiliadoModiefied(string data)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaPerson daPerson = new DaPerson();
                    answer = daPerson.CoAfiliadoModiefied(connection, data);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetFullName(string document)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPerson daPerson = new DaPerson();
                    answer = daPerson.GetFullName(connection, document);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetByUserName(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPerson daPerson = new DaPerson();
                    answer = daPerson.GetByUserName(connection, userName);
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
