
namespace BussinesRules
{
    using System;
    using System.Data.SqlClient;
    using DataAccess;

    public class BrTypeChange : brConnection
    {
        public bool PutTypeChange(decimal venta, decimal compra)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeChange daTypeChange = new DaTypeChange();
                    answer = daTypeChange.PutTypeChange(connection, venta, compra);
                    connection.Close();
                }
                catch (Exception e)
                {
                    //RecordLog(e.Message, e.StackTrace);
                    return answer;
                }
            }
            return answer;
        }

        public string GetTypesChange()
        {
            string answer = "";//venta y compra
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaAccount daAccount = new DaAccount();
                    answer = daAccount.GetTypesChange(connection);
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
