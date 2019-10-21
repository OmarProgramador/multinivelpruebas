
namespace BussinesRules
{
    using System;
    using System.Data.SqlClient;
    using DataAccess;

    public class BrPosibleRegisterCro : brConnection
    {
        public bool PosibleRegisterCro(string data, string docPerson)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaPosibleRegisterCro daInformacion = new DaPosibleRegisterCro();
                    answer = daInformacion.PosibleRegisterCro(connection, data, docPerson);
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
