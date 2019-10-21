
namespace BussinesRules
{
    using DataAccess;
    using System;
    using System.Data.SqlClient;

    public class BrBonus : brConnection
    {
        public string GetPeriod(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaBonus daBonus = new DaBonus();
                    answer = daBonus.GetPeriod(connection, userName);
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

        public string GetFullPeriod()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaBonus daBonus = new DaBonus();
                    answer = daBonus.GetFullPeriod(connection);
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

        public string GetListBonus(string userName, int idPeriod)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaBonus daBonus = new DaBonus();
                    answer = daBonus.GetListBonus(connection, userName, idPeriod);
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

        public bool ChangeStatus(int idBonusPeriod, int status)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaBonus daBonus = new DaBonus();
                    answer = daBonus.ChangeStatus(connection, idBonusPeriod, status);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool PutPeriod(string from, string until, string payDate)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaBonus daBonus = new DaBonus();
                    answer = daBonus.PutPeriod(connection, from, until, payDate);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool PayBonus(int id)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaBonus daBonus = new DaBonus();
                    answer = daBonus.PayBonus(connection, id);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetEmailPayWallet(int id)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaBonus daBonus = new DaBonus();
                    answer = daBonus.GetEmailPayWallet(connection, id);
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
