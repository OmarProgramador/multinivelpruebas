using DataAccess;
using System;
using System.Data.SqlClient;

namespace BussinesRules
{
    public class BrBeneficiary : brConnection
    {
        public bool Put(string name, string doc, string parent,string username,string type)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaBeneficiary daBeneficiary = new DaBeneficiary();
                    answer = daBeneficiary.Put(connection, name, doc, parent, username, type);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string Get(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaBeneficiary daBeneficiary = new DaBeneficiary();
                    answer = daBeneficiary.Get(connection,userName);
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
