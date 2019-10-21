using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesRules
{
    public class BrPlacement : brConnection
    {
        public string GetSponsored(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPlacement daPlacement = new DaPlacement();
                    answer = daPlacement.GetSponsored(connection, userName);
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

        public string GetUpliners(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPlacement daPlacement = new DaPlacement();
                    answer = daPlacement.GetUpliners(connection, userName);
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
