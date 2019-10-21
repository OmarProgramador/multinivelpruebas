
namespace MULTI_NIVEL.Services
{
    using Entities;

    public class EmailPartner
    {
        public bool SendEmail(string[] emails, string data)
        {
            MyMessages mm = new MyMessages();

            bool answer = false;
            Email email = new Email();
            for (int i = 0; i < emails.Length; i++)
            {
                answer = email.SendEmail(emails[i], mm.SubjetEmailPartner(), mm.EmailPartner(), true);
            }
            return answer;
        }
    }
}