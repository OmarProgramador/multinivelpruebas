
namespace BussinesRules
{
    using System;
    using System.Web;
    using System.Configuration;

    public class brConnection
    {
        private readonly string connectionString;        
        string ArchiveLog { get; set; }

        public brConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            ArchiveLog = ConfigurationManager.AppSettings["VEWS112"];
        }

        public void RecordLog(string ErrorMessage, string ErrorDetails)
        {
            /*beLog obeLog = new beLog();
            obeLog.idUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            obeLog.IpClient = HttpContext.Current.Request.UserHostAddress;
            obeLog.Application = ConfigurationManager.AppSettings["Application"];
            obeLog.dateTime = DateTime.Now;
            obeLog.ErrorMessage = ErrorMessage;
            obeLog.ErrorDetails = ErrorDetails;
            brSaveLog.SaveLog(obeLog, ArchiveLog);*/
        }
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
