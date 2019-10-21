

namespace DataAccess.User
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    public class DaUser
    {
        public string LoginUser(SqlConnection sqlConnection, string user, string pass)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.USER.Login]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@user", user);
            sqlCommand.Parameters.AddWithValue("@pass", pass);
            answer = sqlCommand.ExecuteScalar().ToString();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "";
            }
            return answer;
        }

        public string RegisterUser(SqlConnection sqlConnection, string data, string data2)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.USER.Register]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@data2", data2);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }/*testing*/

        public string GetPartnerDirect(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ARBOL.Direct]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            var data = sqlCommand.ExecuteScalar();

            if (data != null)
            {
                answer = data.ToString();
            }

            return answer;
        }

        public string GetAccountBank(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.BANK.GetAccountBank]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }
        public string GetDataPerson(SqlConnection sqlConnection, string data)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.DATA.Get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public string GetMembershipFirts(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetMembershipFirts]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public string GetUpliners(SqlConnection sqlConnection, string data)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.USER.UPLINERS.Get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPersonEntrada", data);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }
        public string GetSponsor(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.UPLINE.GetSponsor]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public string GetCronograma(SqlConnection connection, string codeMembership, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.User.GetCronograma]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@codeMembership", codeMembership);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            object obj = sqlCommand.ExecuteScalar();

            if (obj != null)
            {
                answer = obj.ToString();
            }

            return answer;
        }

        public string GetCoAfiliateInformation(SqlConnection connection, string userName)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.Account.GetCoAfiliateInformation]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", userName);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(obj.ToString())) obj = "ERROR";
            return obj.ToString();
        }

        public string LoginUserBackend(SqlConnection sqlConnection, string data)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.LoginBackend]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(obj.ToString())) obj = "ERROR";
            return obj.ToString();
        }

        public string GetBankInformation(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.GetBankInformation]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", data);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "ERROR";
            }
            return answer;
        }

        public string GenerateAccount(SqlConnection sqlConnection, string data)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.Generate]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public string getAmountPay(SqlConnection sqlConnection, string userName)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.getAmountPay]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", userName);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public string GetAmountPay(SqlConnection sqlConnection, int idAccountTypeMembership)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetAmountPay.By.idAccountTypeMembership]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idAccountTypeMembership", idAccountTypeMembership);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public string getPersons(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.List]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public string getAmountPay(SqlConnection sqlConnection, int idPayDetails, string userName)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.getAmountPayByid]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPayDetails", idPayDetails);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public string GetPointsQuotePay(SqlConnection sqlConnection, string userName)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.POINTS.Month]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            return sqlCommand.ExecuteScalar().ToString();
        }

        public string getName(SqlConnection sqlConnection, string userName)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.getName]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }
        public string PossibleUser(SqlConnection sqlConnection, string data)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.POSSIBLERegister]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public bool PorVerificar(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayDetail.PorVerificar]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool UpdateInitialQuoteDescription(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.UPDATEInitial]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public Int32 RegisterNmembership(SqlConnection sqlConnection, string data, string amountFinanced, int isPredetermined, string codeCurrency)
        {
            int answer = 0;
            //SqlCommand sqlCommand = new SqlCommand("[usp.N_MEMBERSHIP.Register]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.Nmembership.Register]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@data2", amountFinanced);
            sqlCommand.Parameters.AddWithValue("@data3", isPredetermined);
            sqlCommand.Parameters.AddWithValue("@codeCurrency", codeCurrency);
            int obj = (Int32)sqlCommand.ExecuteScalar();
            if (obj >= 1) answer = obj;
            return answer;
        }

        public bool RegisterRange(SqlConnection sqlConnection, string data, string data2)
        {
            bool answer = false;
            //SqlCommand sqlCommand = new SqlCommand("[usp.N_MEMBERSHIP.Register]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.ChangeRange]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@data2", data2);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool PayInitial(SqlConnection connection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.PayInitial.Membership]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool RegisterService(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            //SqlCommand sqlCommand = new SqlCommand("[usp.N_MEMBERSHIP.Register]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.SALE.SERVICES.put]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            //sqlCommand.Parameters.AddWithValue("@data2", data2);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }
        public bool RegisterTraveler(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            //SqlCommand sqlCommand = new SqlCommand("[usp.N_MEMBERSHIP.Register]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.NEW.TRAVELER.put]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            //sqlCommand.Parameters.AddWithValue("@data2", data2);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool RegisterNews(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            //SqlCommand sqlCommand = new SqlCommand("[usp.N_MEMBERSHIP.Register]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.News.put]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            //sqlCommand.Parameters.AddWithValue("@data2", data2);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }
        public string getNews(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.News.get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@userName");
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }
        public int getNewsCount(SqlConnection sqlConnection)
        {
            int answer = 0;
            SqlCommand sqlCommand = new SqlCommand("[usp.NEWS.Notification]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@userName");
            answer = (int)sqlCommand.ExecuteScalar();

            return answer;
        }
        public int GetCountAccountNews(SqlConnection sqlConnection, string data)
        {
            int answer = 0;
            SqlCommand sqlCommand = new SqlCommand("[usp.NEWS.CountAccount]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            //sqlCommand.Parameters.AddWithValue("@userName");
            answer = (int)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetLineActives(SqlConnection sqlConnection, string userName)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.Account.GetLineActives]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            string obj = sqlCommand.ExecuteScalar().ToString();
            if (string.IsNullOrEmpty(obj))
            {
                obj = "ERROR";
            }
            return obj;
        }

        public bool UpdateAccountNewsCount(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            //SqlCommand sqlCommand = new SqlCommand("[usp.N_MEMBERSHIP.Register]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.NEWS.UpdateCountAccount]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            //sqlCommand.Parameters.AddWithValue("@data2", data2);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }
        public bool RegNewsCount(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            //SqlCommand sqlCommand = new SqlCommand("[usp.N_MEMBERSHIP.Register]", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("[usp.NEWS.Count]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            //sqlCommand.Parameters.AddWithValue("@data2", data2);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }


        public bool NotAvailableUser(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.User.NotAvailable]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }
        public bool ActivateAccount(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.Activate.Account]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool DisabledAccount(SqlConnection sqlConnection, int data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.Disabled]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public string getSons(SqlConnection sqlConnection, string padre)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.CONVERNING.Son]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@padre", padre);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public string GetEmails(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.CHARGE]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public string GetIdPerson(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Account.GetIdPerson]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            answer = sqlCommand.ExecuteScalar().ToString();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "0";
            }
            return answer;
        }

        public string GetAccountStatus(SqlConnection sqlConnection, string data)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.Status]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public bool IsTeamCompleted(SqlConnection sqlConnection, int idPerson)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.IsTeamCompleted]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPerson", idPerson);
            int obj = int.Parse(sqlCommand.ExecuteScalar().ToString());
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool IsHelpTeam(SqlConnection sqlConnection, int idPerson)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.IsHelpTeam]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPerson", idPerson);
            string obj = sqlCommand.ExecuteScalar().ToString();
            int rows = int.Parse(obj);
            if (rows >= 1)
            {
                answer = true;
            }
            return answer;
        }

        public string commissionsVerification(SqlConnection sqlConnection, string idPerson)
        {
            SqlCommand sqlCommand = new SqlCommand("[usp.COMISSIONS.Verification]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", idPerson);
            object obj = sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty((string)obj)) obj = "ERROR";
            return (string)obj;
        }

        public bool UpdateUserDataAccount(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.UpdatePassword]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool UpdateNews(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.News.Update]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }
        public bool DeleteNews(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.News.Delete]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public string GetCountsAsociate(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.Account.GetCountsAsociate]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool enableAcount(SqlConnection sqlConnection, int idMembershipDetail, string nameTicket)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.enabled]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembershipDetail", idMembershipDetail);
            sqlCommand.Parameters.AddWithValue("@nameTicket", nameTicket);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public string GetNafiliate(SqlConnection sqlConnection, int idMembershipDetail)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.Enabled.Return.NAfiliate]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembershipDetail", idMembershipDetail);
            answer = sqlCommand.ExecuteScalar().ToString();

            return answer;
        }

        public bool UpdateDataPerson(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.USER.Register]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool UpdateDataAccountBanck(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.USER.Register]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public string GetDateUpgrade(SqlConnection sqlConnection, int idN_MemberUpgrate)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetDateUpgrade]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", idN_MemberUpgrate);
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string getPartner(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ARBOL.getTree]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string getShopping(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.SALE.SERVICES.get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public string getTravelers(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.NEW.TRAVELERS.get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public string getDoc(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.GetDoc]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }
        public string GetMembershipType(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.Get]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }
        public bool PutRegisterkIT(SqlConnection sqlConnection, string data, Int32 data2)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[MEMBERSHIP.PAYDETAIL.PutRegisterkIT]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@data2", data2);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool PutBankInformation(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[DATA.PERSON.BANK.PutData]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetPersonalInformation(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.GetPersonalInformation]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }

        public bool PutPersonalInformation(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.PutPersonalInformation]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool UPDATESENDEMAILDAY(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.UPDATESENDEMAILDAY]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string MailsRegPendients(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ALERTS.REGISTER.PENDING]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }

        public string NotifDates(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ALERTS.DATES.PENDING]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }

        public bool UpdateNotifications(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[USP.NOTIFICATION.Update]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool AlertRegister(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[USP.ReactStringEmail]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }


        public string GetAditionalInformation(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.GetAditionalInformation]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "ERROR";
            }
            return answer;
        }

        public string GetNotifications(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.ReviewNotification]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "ERROR";
            }
            return answer;/*forceChanged2*/
        }

        public string VerificarExiste(SqlConnection sqlConnection, string numberDocumentVa)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.User.VerificarExiste_Doc]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@numberDoc", numberDocumentVa);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }

        public string GetRange(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.RANGE.GetRange]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }

        public string GetName(SqlConnection sqlConnection, string dni)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.GetName]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userDni", dni);
            answer = (string)sqlCommand.ExecuteScalar();
            if (string.IsNullOrEmpty(answer))
            {
                answer = "error";
            }
            return answer;
        }
        public int ExistAccountLink(SqlConnection sqlConnection, string data)
        {
            int answer = 0;
            SqlCommand sqlCommand = new SqlCommand("[usp.Account.Exist.Link]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (int)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool GetNotPayInitial(SqlConnection sqlConnection, string dateinitial, string newUserName, int ansNmembershi)
        {
            bool answer = false;
            int row = 0;
            SqlCommand sqlCommand = new SqlCommand("[usp.Account.GetNotPayInitial]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@dateinitial", dateinitial);
            sqlCommand.Parameters.AddWithValue("@userName", newUserName);
            sqlCommand.Parameters.AddWithValue("@ansNmembershi", ansNmembershi);
            row = sqlCommand.ExecuteNonQuery();
            if (row > 1)
            {
                answer = true;
            }
            return answer;
        }

        public bool BiPayQuote(SqlConnection connection, int idMemberDetails, string imgTicket, decimal amountWallet, decimal amountOthers, string method, string method2, int statusPay, decimal typeChangeSend)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.BiPayQuote]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMemberDetails", idMemberDetails);
            sqlCommand.Parameters.AddWithValue("@imgTicket", imgTicket);
            sqlCommand.Parameters.AddWithValue("@amountWallet", amountWallet);
            sqlCommand.Parameters.AddWithValue("@amountOthers", amountOthers);
            sqlCommand.Parameters.AddWithValue("@method", method);
            sqlCommand.Parameters.AddWithValue("@methodAc", method2);
            sqlCommand.Parameters.AddWithValue("@statusPay", statusPay);
            sqlCommand.Parameters.AddWithValue("@typeChange", typeChangeSend);

            int obj = sqlCommand.ExecuteNonQuery();

            if (obj >= 1) answer = true;

            return answer;
        }

        public bool EnableAcountPromoter(SqlConnection connection, int idMemberDetails, string ticketImg)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.ACCOUNT.EnableAcountPromoter]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembershipDetail", idMemberDetails);
            sqlCommand.Parameters.AddWithValue("@nameTicket", ticketImg);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }
    }
}
