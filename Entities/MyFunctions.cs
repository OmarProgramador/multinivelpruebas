using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entities
{
    public class MyFunctions
    {
        public string DateFormatClient(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                string[] arrayDate = date.Split('-');
                return arrayDate[2] + "/" + arrayDate[1] + "/" + arrayDate[0];
            }
            return "--";
        }
        public string DateFormatBd(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                string[] arrayDate = date.Split('/');
                if (arrayDate.Length == 1)
                {
                    return arrayDate[0];
                }
                return arrayDate[2] + "-" + arrayDate[1] + "-" + arrayDate[0];
            }
            return "--";
        }

        public string GeneralStatus(string _text)
        {
            string answer = "";
            if (int.Parse(_text) == 1)
            {
                answer = "Activo";
            }
            if (int.Parse(_text) == 0)
            {
                answer = "No Activo";
            }
            return answer;
        }

        public string GetMonth(string _months)
        {
            int _month = int.Parse(_months);
            string month = "";
            if (_month == 1)
            {
                month = "Enero";
            }
            if (_month == 2)
            {
                month = "Febrero";
            }
            if (_month == 3)
            {
                month = "Marzo";
            }
            if (_month == 4)
            {
                month = "Abril";
            }
            if (_month == 5)
            {
                month = "Mayo";
            }
            if (_month == 6)
            {
                month = "Junio";
            }
            if (_month == 7)
            {
                month = "Julio";
            }
            if (_month == 8)
            {
                month = "Agosto";
            }
            if (_month == 9)
            {
                month = "Septiembre";
            }
            if (_month == 10)
            {
                month = "Octubre";
            }
            if (_month == 11)
            {
                month = "Noviembre";
            }
            if (_month == 12)
            {
                month = "Diciembre";
            }
            return month;
        }

        public string GetAmountCurrency(string _amountSoles,string curremcyCode,decimal typeChange)
        {
            decimal answer = 0;
            decimal amountSoles = decimal.Parse(_amountSoles);
            answer = amountSoles;

            if (curremcyCode == "USD")
            {
                answer = answer / typeChange;
            }
            return answer.ToString("0.00");
        }

        public string ConvertStatus(string _status)
        {
            string statusstr = "Inactivo";
            int status = int.Parse(_status);
            if (status == 0)
            {
                statusstr = "Inactivo";
            }
            if (status == 1)
            {
                statusstr = "Activo";
            }
            if (status == 2)
            {
                statusstr = "Deuda 1";
            }
            if (status == 3)
            {
                statusstr = "Deuda 2";
            }
            if (status == 4)
            {
                statusstr = "Deuda 3";
            }
            if (status == 5)
            {
                statusstr = "Comprimido";
            }
            if (status == 6)
            {
                statusstr = "Stand Bye";
            }
            if (status == 7)
            {
                statusstr = "Pendiente";
            }
            if (status == 8)
            {
                statusstr = "Deuda 7";
            }
            if (status > 8)
            {
                statusstr = "Deuda 8";
            }
            return statusstr;
        }

        public string ToCapitalize(string _text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(_text);
        }
    }
}
