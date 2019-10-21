using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaCore_Automation
    {
        public bool ExecuteCore(SqlConnection sqlConnection)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("CORE", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }
    }
}
