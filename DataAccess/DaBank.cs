
namespace DataAccess
{
    using System.Data;
    using System.Data.SqlClient;

    public class DaBank
    {
        public string GetData(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.BANK.GetData]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

    }
}
