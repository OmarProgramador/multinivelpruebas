
namespace BussinesRules
{
    using DataAccess;
    using System;
    using System.Data.SqlClient;

    public class BrMembershipPayDetail : brConnection
    {
        public string GetQuote(int id, string userName)
        {
            //monto| fecha de expiration |codecurrency | description| typechange
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetQuote(connection, id, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0|";
                }
            }
            return answer;
        }

        public string GetValueQuoteMaxQuote(int idMembership, string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetValueQuoteMaxQuote(connection, idMembership, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0|0";
                }
            }
            return answer;
        }

        public bool PayQuote(int idMembership, string userName, string ticketImage)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.PayQuote(connection, idMembership, userName, ticketImage);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetFullSchedule(string userName, int idAccountTypeMembership)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetFullSchedule(connection, userName, idAccountTypeMembership);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "";
                }
            }
            return answer;
        }

        public string GetDescriptionQuote(int idMembership)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetDescriptionQuote(connection, idMembership);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0|0";
                }
            }
            return answer;
        }

        public string GetFullDescriptionQuote(int idMembership, string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetFullDescriptionQuote(connection, idMembership, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0|0";
                }
            }
            return answer;
        }

        public string GetValueQuoteMaxQuoteChangeSchedule(int idMembership, string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetValueQuoteMaxQuoteChangeSchedule(connection, idMembership, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0|0";
                }
            }
            return answer;
        }

        public bool EnableByInitial(string data, string data2)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.EnableByInitial(connection, data, data2);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool IsPayQuote(string idMembershipDetail)
        {
            bool answer = true;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.IsPayQuote(connection, idMembershipDetail);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetInfoForRecibo(int idMembership)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetInfoForRecibo(connection, idMembership);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0";
                }
            }
            return answer;
        }


        public string GetInfoQuoteForRecibo(int idMembership)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetInfoQuoteForRecibo(connection, idMembership);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0";
                }
            }
            return answer;
        }

        public bool PutQuotes(int idMembership, int numQuote, string image, int verif)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail oMemb = new DaMembershipPayDetail();
                    answer = oMemb.PutQuotes(connection, idMembership, numQuote, image, verif);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutQuotesChangingSchedule(int idMembership, int numQuote, string nameImage, int verif)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail oMemb = new DaMembershipPayDetail();
                    answer = oMemb.PutQuotesChangingSchedule(connection, idMembership, numQuote, nameImage, verif);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutRecibo(string userName_ticket)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail oMemb = new DaMembershipPayDetail();
                    answer = oMemb.PutRecibo(connection, userName_ticket);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool UpdateRange(string userName)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail oMemb = new DaMembershipPayDetail();
                    answer = oMemb.UpdateRange(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        /// <summary>
        /// Cambiar el estado colocando que ya esta pagando (Si type es 1 indica que tambien pagara la primera cuota)
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="type">Si es 1 indica que tambien pagara la primera cuota</param>
        /// <returns></returns>
        public bool UpgrateStatusPaymentInitial(int idAccountTypeMembership, int type, string nameTicket)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail oMemb = new DaMembershipPayDetail();
                    answer = oMemb.UpgrateStatusPaymentInitial(connection, idAccountTypeMembership, type, nameTicket);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetDuration(string codeMembership)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail daMembershipPayDetail = new DaMembershipPayDetail();
                    answer = daMembershipPayDetail.GetDuration(connection, codeMembership);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0";
                }
            }
            return answer;
        }

        public bool PutReceiptQuote(string idMembershipDetail, string nameFile)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaMembershipPayDetail oMemb = new DaMembershipPayDetail();
                    answer = oMemb.PutReceiptQuote(connection, idMembershipDetail, nameFile);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
    }
}
