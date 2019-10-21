using DataAccess;
using System;
using System.Data.SqlClient;

namespace BussinesRules
{
    public class BrHistoryRange : brConnection
    {
        public string GetListRange(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaHistoryRange daHistoryRange = new DaHistoryRange();
                    answer = daHistoryRange.GetListRange(connection, userName);
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

        public bool PutHistoryRangePeriod(int idBonusPeriod)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaHistoryRange daHistoryRange = new DaHistoryRange();
                    answer = daHistoryRange.PutHistoryRangePeriod(connection, idBonusPeriod);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = false;
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutHistoryRangeResidualPeriod(int idBonusPeriod)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaHistoryRange daHistoryRange = new DaHistoryRange();
                    answer = daHistoryRange.PutHistoryRangeResidualPeriod(connection, idBonusPeriod);
                    connection.Close();
                }
                catch (Exception e)
                {
                    answer = false;
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetListRangeResidual(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaHistoryRange daHistoryRange = new DaHistoryRange();
                    answer = daHistoryRange.GetListRangeResidual(connection, userName);
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
