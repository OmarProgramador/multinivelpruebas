using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesRules
{
    public class BrDaysFree : brConnection
    {
        public bool Put(string userName, int numberDays, int idMembership)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaDaysFree daDaysFree = new DaDaysFree();
                    answer = daDaysFree.Put(connection, userName, numberDays, idMembership);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool Qualify(string userName, int idMembership)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaDaysFree daDaysFree = new DaDaysFree();
                    answer = daDaysFree.Qualify(connection, userName, idMembership);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetDaysByUserName(string userName, int idMembership)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaDaysFree daDaysFree = new DaDaysFree();
                    answer = daDaysFree.GetDaysByUserName(connection, userName, idMembership);
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
