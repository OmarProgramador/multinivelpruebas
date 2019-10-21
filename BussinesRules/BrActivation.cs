using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesRules
{
    public class BrActivation : brConnection
    {
        public string Get(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaActivation daActivation  = new DaActivation();
                    answer = daActivation.Get(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutCronograma(string cronoActiv, string userName ,int ansNmembershi)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaActivation daActivation = new DaActivation();
                    answer = daActivation.PutCronograma(connection, cronoActiv, userName, ansNmembershi);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool PutCronogramaUpgrade(string date, string userName, int ansNmembershi,int idAccountTypeMembership)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaActivation daActivation = new DaActivation();
                    answer = daActivation.PutCronogramaUpgrade(connection, date, userName, ansNmembershi, idAccountTypeMembership);
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
