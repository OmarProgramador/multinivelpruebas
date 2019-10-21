using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Validation
    {
        public bool ValidateDni(string identificationDocument)
        {
            if (identificationDocument.Length != 8)
            {
                return false;
            }
            for (int i = 0; i < identificationDocument.Length; i++)
            {
                string carater = identificationDocument.Substring(i, 1);
                if (carater.Any(x => !char.IsNumber(x)))
                {
                    return false;
                }               
            }
            return true;
        }

        public bool IsDocument(string identificationDocument)
        {           
            for (int i = 0; i < identificationDocument.Length; i++)
            {
                string carater = identificationDocument.Substring(i, 1);
                if (carater.Any(x => !char.IsNumber(x)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsNumber(string character)
        {
            if (character.Any(x => !char.IsNumber(x)))
            {
                return false;
            }
            return true;
        }

        public bool IsString(string characters)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                string character = characters.Substring(i, 1);
                if (character.Any(x => char.IsNumber(x)))
                {
                    return false;
                }               
            }
            return true;
        }

        public bool IsEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                mailAddress = null;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsPhone(string phone)
        {
            if (phone.Length > 10)
            {
                return false;
            }
            for (int i = 0; i < phone.Length; i++)
            {
                string carater = phone.Substring(i, 1);
                if (carater.Any(x => !char.IsNumber(x)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsEntero(string number)
        {
            try
            {
                int.Parse(number);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsDecimal(string number)
        {
            try
            {
                decimal.Parse(number);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
