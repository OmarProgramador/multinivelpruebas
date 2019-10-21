using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaPosibleRegisterCro
    {
        public bool PosibleRegisterCro(SqlConnection sqlConnection, string data,string docPerson)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[POSIBLE.REGISTER.Put]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@DocPerson", docPerson);
            sqlCommand.Parameters.AddWithValue("@DataCronograma", data);
            int affectedRows = sqlCommand.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                answer = true;
            }         
            return answer;
        }
    }
}
