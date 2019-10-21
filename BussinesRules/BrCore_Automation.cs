using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesRules
{
    public class BrCore_Automation : brConnection
    {
        public bool ExecuteCore()
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaCore_Automation daCore_Automation = new DaCore_Automation();
                    answer = daCore_Automation.ExecuteCore(connection);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }
        
    }
}
