using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesRules
{
    public class BrPromoter : brConnection
    {
        public string GetListByUserName(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPromoter daPromoter = new DaPromoter();
                    answer = daPromoter.GetListByUserName(connection, userName);
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

        public bool SaveCode(string userName, string code)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaPromoter daPromoter = new DaPromoter();
                    answer = daPromoter.SaveCode(connection, userName, code);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetCodeByUserName(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPromoter daPromoter = new DaPromoter();
                    answer = daPromoter.GetCodeByUserName(connection, userName);
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

        public bool IsCodeValid(string code, string userName)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaPromoter daPromoter = new DaPromoter();
                    answer = daPromoter.IsCodeValid(connection, code, userName);
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
