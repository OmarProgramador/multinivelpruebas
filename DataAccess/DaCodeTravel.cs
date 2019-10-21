using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaCodeTravel
    {
        public bool Put(SqlConnection sqlConnection, int idPerson, int idAccount, string firstName, string lastName, string email, string phone, string expirationDate)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.TRAVEL.Put]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPerson", idPerson);
            sqlCommand.Parameters.AddWithValue("@idAccount", idAccount);
            sqlCommand.Parameters.AddWithValue("@firstName", firstName);
            sqlCommand.Parameters.AddWithValue("@lastName", lastName);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@phone", phone);
            sqlCommand.Parameters.AddWithValue("@expirationDate", expirationDate);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string GetNotConfirmed(SqlConnection connection)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.TRAVEL.GetNotConfirmed]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;          
            answer = (string)sqlCommand.ExecuteScalar();
            return answer;
        }

        public bool EditBenef(SqlConnection connection, string name, string lastName, string email, string telef, int id, string codeCountry)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.NEW.TRAVELER.EditBenef]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@lastName", lastName);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@telef", telef);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@codeCountry", codeCountry);
            //sqlCommand.Parameters.AddWithValue("@userTravel", userTravel);
            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool DisposeBenef(SqlConnection connection, int id)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.NEW.TRAVELER.Dispose]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", id);
            
            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public string Get(SqlConnection connection, string userName)
        {
            string answer = "";
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.TRAVEL.GetByUserName]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            answer = (string)sqlCommand.ExecuteScalar();

            return answer;
        }

        public bool VerifMaximo(SqlConnection connection, string userName)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.TRAVEL.VerifMaximo]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            //sqlCommand.Parameters.AddWithValue("@userTravel", userTravel);
            
            int affectedRow = int.Parse(sqlCommand.ExecuteScalar().ToString());
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool Acceptance(SqlConnection connection, int idCodeTravel, string userTravel, string passTravel, string code)
        {
            bool answer = false;
            SqlCommand sqlCommand = new SqlCommand("[usp.CODE.TRAVEL.Acceptance]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idCodeTravel", idCodeTravel);
            //sqlCommand.Parameters.AddWithValue("@userTravel", userTravel);
            sqlCommand.Parameters.AddWithValue("@passTravel", passTravel);       
            sqlCommand.Parameters.AddWithValue("@code", code);

            int affectedRow = sqlCommand.ExecuteNonQuery();
            if (affectedRow > 0)
            {
                answer = true;
            }
            return answer;
        }
    }
}
