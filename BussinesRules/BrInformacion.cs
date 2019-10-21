
namespace BussinesRules
{
    using DataAccess;
    using System;
    using System.Data.SqlClient;

    public class BrInformacion : brConnection
    {
        public string GetInformation()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetInformation(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetTextExonerarDB()
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetTextExonerarDB(connection);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }
        public string GetBYIdMembershipDetail(int idMemDetail)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetBYIdMembershipDetail(connection, idMemDetail);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }
        public string GetBYNunDoc(string numDoc)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetBYNunDoc(connection, numDoc);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetPointsLines(string userName)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetPointsLines(connection, userName);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
                answer = "0|0";
            }
            return answer;
        }

        public bool ActiveUp()
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.ActiveUp(connection);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetNextRange(string userName)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetNextRange(connection, userName);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
                answer = "--|--";
            }
            return answer;
        }

        public string GetCurrentAndNextRange(string range)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetCurrentAndNextRange(connection, range);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
                answer = "--|--";
            }
            return answer;
        }

        public string GetPointsLinesResid(string userName)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetPointsLinesResid(connection, userName);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
                answer = "0|0";
            }
            return answer;
        }

        public string GetMaximiumMinium(string range)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetMaximiumMinium(connection, range);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
                answer = "0|0";
            }
            return answer;
        }

        public string GetRangeResidualCurrent(string userName)
        {
            string answer = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetRangeResidualCurrent(connection, userName);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
                answer = "0|0";
            }
            return answer;
        }

        public string GetPointsRange(string range)
        {
            string answer = ""; //obtener los puntos establecidos o 
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetPointsRange(connection, range);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
                answer = "0|0";
            }
            return answer;
        }

        public string GetPointsRangeProximo(string range)
        {
            string answer = ""; //obtener los puntos establecidos o 
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaInformacion daInformacion = new DaInformacion();
                    answer = daInformacion.GetPointsRangeProximo(connection, range);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
                answer = "0|0";
            }
            return answer;
        }
    }
}
