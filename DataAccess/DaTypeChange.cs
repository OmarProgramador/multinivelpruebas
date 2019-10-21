
namespace DataAccess
{
    using System.Data;
    using System.Data.SqlClient;

    public class DaTypeChange
    {
        public bool PutTypeChange(SqlConnection sqlConnection, decimal venta, decimal compra)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[uspTYPE.CHANGE.put]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@venta", venta);
            sqlCommand.Parameters.AddWithValue("@compra", compra);
            int affectedRows = sqlCommand.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                answer = true;
            }
            return answer;

        }
    }
}
