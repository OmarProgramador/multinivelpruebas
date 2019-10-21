using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesRules
{
    public class BrCodeTravel : brConnection
    {
        public bool Put(int idPerson, int idAccount, string firstName, string lastName, string email, string phone, string expirationDate)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaCodeTravel daCodeTravel = new DaCodeTravel();
                    answer = daCodeTravel.Put(connection, idPerson, idAccount,firstName,lastName,email,phone,expirationDate);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool EditBenef(string name, string lastName, string email, string telef, int id, string codeCountry)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaCodeTravel daCodeTravel = new DaCodeTravel();
                    answer = daCodeTravel.EditBenef(connection, name, lastName, email,telef,id, codeCountry);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public bool DisposeBenef(int id)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaCodeTravel daCodeTravel = new DaCodeTravel();
                    answer = daCodeTravel.DisposeBenef(connection, id);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string GetNotConfirmed()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaCodeTravel daCodeTravel = new DaCodeTravel();
                    answer = daCodeTravel.GetNotConfirmed(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool VerifMaximo(string userName)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaCodeTravel daCodeTravel = new DaCodeTravel();
                    answer = daCodeTravel.VerifMaximo(connection,userName);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                RecordLog(e.Message, e.StackTrace);
            }
            return answer;
        }

        public string Get(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaCodeTravel daCodeTravel = new DaCodeTravel();
                    answer = daCodeTravel.Get(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool Acceptance(int idCodeTravel, string userTravel, string passTravel, string code)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaCodeTravel daCodeTravel = new DaCodeTravel();
                    answer = daCodeTravel.Acceptance(connection, idCodeTravel, userTravel, passTravel, code);
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
