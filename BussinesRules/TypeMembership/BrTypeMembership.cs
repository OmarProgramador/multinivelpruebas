

namespace BussinesRules.TypeMembership
{
    using DataAccess.TypeMembership;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class BrTypeMembership : brConnection
    {
        public string GetTypeMembership()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetTypeMembership(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetListCodeMemberships(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetListCodeMemberships(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetListMemberships(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetListMemberships(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetTotalMemberships(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetTotalMemberships(connection, userName);
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
        public string GetUpdateBanner(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetUpdateBanner(connection, userName);
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
        public bool UpdateNextDay(string idUser)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.UpdateNextDay(connection, idUser);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetKitData()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetKitData(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool AddMembershipUser(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.AddMembershipUser(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetMembersLastUser(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetMembersLastUser(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetListAccount(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetListAccount(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool CancelMembershipUpgrate(int codeUpgrate, int nuevoNmembershi)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.CancelMembershipUpgrate(connection, codeUpgrate, nuevoNmembershi);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetTypeMembership(int idAccount_N_Membership)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaTypeMembership odaTypeMembership = new DaTypeMembership();
                    answer = odaTypeMembership.GetTypeMembership(connection, idAccount_N_Membership);
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
