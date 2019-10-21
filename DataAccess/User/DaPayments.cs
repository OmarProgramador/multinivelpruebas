
namespace DataAccess.User
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DaPayments
    {
        public string getCommissions(SqlConnection sqlConnection, string name)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.GetPartnetSchedule]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", name);
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public string GetComissionUsers(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.GetPersons]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            answer = sqlCommand.ExecuteScalar().ToString();
            return answer;
        }


        public string getFatherData(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.GetFatherData]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool DisposePay(SqlConnection connection, SqlTransaction sqlTransaction, int idMembershipDetail,string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.DisposePay]", connection, sqlTransaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembershipDetail", idMembershipDetail);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool QuoteRefuse(SqlConnection connection, SqlTransaction sqlTransaction, int idMembershipDetail)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.QuoteRefuse]", connection, sqlTransaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idMembershipDetail", idMembershipDetail);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public string PersonGetData(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PERSON.GetData]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public string GetListPayments(SqlConnection sqlConnection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAY.DETAIL.GetList.By.UserName]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public string GetListPayDefault(SqlConnection sqlConnection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[USP.MEMBERSHIP.DefaultPay]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public bool putPayment(SqlConnection sqlConnection, string data, Int32 data2, string exchange, int data4)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[USP.MEMBERSHIP.PutRegister2]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data.ToString());
            sqlCommand.Parameters.AddWithValue("@data2", data2);
            sqlCommand.Parameters.AddWithValue("@data3", exchange);
            sqlCommand.Parameters.AddWithValue("@data4", data4);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }


        public bool UpdateComissionStatus(SqlConnection sqlConnection, int data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.COMISSION.Verif]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }

        public bool putPaymentAlterego(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[USP.MEMBERSHIP.PutRegister2.Alterego]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data.ToString());
            int obj = sqlCommand.ExecuteNonQuery();
            if (obj >= 1) answer = true;
            return answer;
        }
        /*MERGE*/
        public string GetAmountTotal(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.TYPE_MEMBERSHIP.GetAmountTotal]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public string GetPointsGeneral(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.POINTS.Current]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public string GetDataQuote(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.PAYDETAIL.GetQuote]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public bool PutRegisterkIT(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[MEMBERSHIP.PAYDETAIL.PutRegisterkIT]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string getPayDetailByPerson(SqlConnection sqlConnection, string data)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAY.DETAIL.GetList.By.UserName]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", data);
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }
        public bool InitialExoneration(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[EXONERATION]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }
        public bool UploadReceipt(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.UploadReceipt]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);

            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool UploadReceiptUpgradeCerooInitial(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.UploadReceipt.UpgradeCerooInitial]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);

            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool PayComissions(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.PayComissions]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }


        public bool UploadReceiptCalendar(SqlConnection sqlConnection, string data)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PAYDETAIL.UploadReceiptCalendar]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            int filas = sqlCommand.ExecuteNonQuery();
            if (filas > 0)
            {
                answer = true;
            }
            return answer;
        }
        public bool Amortization(SqlConnection sqlConnection, int TypePay, string IdMembershipDetail, int nQuotes, decimal value2, int Rate, string photo)
        {
            bool answer = false;
            int answer2;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.ReformulateAmort]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TypePay ", TypePay);
            sqlCommand.Parameters.AddWithValue("@IdMembership", IdMembershipDetail);
            sqlCommand.Parameters.AddWithValue("@nQuotes", nQuotes);
            sqlCommand.Parameters.AddWithValue("@NewAmort", value2);
            sqlCommand.Parameters.AddWithValue("@Rate", Rate);
            sqlCommand.Parameters.AddWithValue("@photo", photo);
            /* int filas = sqlCommand.ExecuteNonQuery();
             if (filas > 0)
             {
                 answer = true;
             }*/
            answer2 = (int)sqlCommand.ExecuteScalar();
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = "[usp.CulqiMembership]";
            sqlCommand.Parameters.AddWithValue("@data", answer2);
            answer2 = sqlCommand.ExecuteNonQuery();
            //return answer;
            if (answer2 > 0)
            {
                answer = true;
            }

            return answer;
        }

        public string PayQuoteMembership(SqlConnection sqlConnection, string data, string data2, string nameTick)
        {
            string answer = "";
            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 0;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PayQuote]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@data", data);
            sqlCommand.Parameters.AddWithValue("@data2", Int32.Parse(data2));
            sqlCommand.Parameters.AddWithValue("@nameTick", nameTick);
            answer = (string)sqlCommand.ExecuteScalar();
            //sqlCommand.Parameters.Clear();
            //sqlCommand.CommandText = "CORE";
            //int i = sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = "[test_date2]";
            //int i2 = sqlCommand.ExecuteNonQuery();
            /* sqlCommand.CommandText = "[levelUp]";
             int i3 = sqlCommand.ExecuteNonQuery();*/

            return answer;     /*MERGEwil*/
        }

        public bool PutDateUpgrate(SqlConnection sqlConnection, int ansNmembershi, string date)
        {
            bool answer = false;
            int answer2;
            SqlCommand sqlCommand = new SqlCommand("[usp.MEMBERSHIP.PutDateUpgrate]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", ansNmembershi);
            sqlCommand.Parameters.AddWithValue("@date", date);
            answer2 = sqlCommand.ExecuteNonQuery();
            if (answer2 > 0)
            {
                answer = true;
            }
            return answer;
        }
    }
}


