

namespace BussinesRules.Consuption
{
    using DataAccess.Consuption;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class BrConsuption:brConnection
    {
        public string GetAmountConsuption(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaConsuption odaConsution = new DaConsuption();
                    answer = odaConsution.GetAmountConsuption(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public bool RegisterConsuptionPayDetail(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaConsuption  odaConsuption = new DaConsuption();
                    answer = odaConsuption.RegisterConsuptionPayDetail(connection, data);
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
