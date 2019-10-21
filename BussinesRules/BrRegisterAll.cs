
namespace BussinesRules
{
    using DataAccess.User;
    using System;
    using System.Data.SqlClient;

    public class BrRegisterAll : brConnection
    {
        public bool RegisterAll(string datalogin, string datalogin2, string dataBdd, string userCurrent)
        {
            bool answer = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    string[] oIdMembreship_amount = odaUser.RegisterUser(connection, datalogin, datalogin).Split('¬');


                    string[] parameterPerson = dataBdd.Split('$');
                    string[] arraydata = parameterPerson[0].Split('|');
                    string[] arrayTypeaccount = parameterPerson[2].Split('|');
                    string[] arrayaccount = parameterPerson[3].Split('|');

                    string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + userCurrent + '|' + oIdMembreship_amount[0];

                    var newUserName = odaUser.GenerateAccount(connection, parameterAccount);

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
