using culqi.net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PayCulqi
    {
        public string newPayment(string newUserName,string email,double amount,string token,int numberQuotes,string currencyCode)
        {
            string monto = "0";
            string[] arrayMonto = amount.ToString("0.00").Split('.');
            monto = arrayMonto[0] + arrayMonto[1];

            Security security = new Security();
            ///PRODUCTION////////////////////////////////////////////////////////
            security.public_key = "pk_live_0VvfZdSKhqDXHPvn";
            security.secret_key = "sk_live_YMIEbWi5IffP0cW2";
            ////////////////////////////////////////////////////////////////////
            ///
            ///INTEGRATION////////////////////////////////////////////////////////
            //security.public_key = "pk_test_8lmFNlrqh9MZp7VG";
            //security.secret_key = "sk_test_KR4fQzfm8c1M0Pjl";
            ////////////////////////////////////////////////////////////////////

            Dictionary<string, object> metadata = new Dictionary<string, object>
            {
                {"account_userName", newUserName},
            };

            Dictionary<string, object> map = new Dictionary<string, object>
            {
                {"amount", monto},
                {"currency_code", currencyCode},
                {"email", email},
                {"metadata", metadata},
                {"source_id", token},
                { "installments", numberQuotes.ToString() }
            };

            string charge = new Charge(security).Create(map);
            JObject obj = JObject.Parse(charge);

            var culqiAnwser = JsonConvert.DeserializeObject<CulqiAnwser>(obj.ToString());

            if (culqiAnwser.Amount == 0)
            {
               return"false¬Ha Ocurrido un Error al Intentar Pagar En Linea(Monto es = 0)";
                
            }
            if (culqiAnwser.Outcome == null)
            {
               return "false¬Ha Ocurrido un Error al Intentar Pagar En Linea(Outcome = null)";
                
            }
            if (culqiAnwser.Outcome.Type != "venta_exitosa")
            {
                 return"false¬Ha Ocurrido un Error al Intentar Pagar En Linea(Pago no Fue Exitoso)";
               
            }//habilita a la cuenta a ingresar 

            string tranferId = culqiAnwser.Transfer_id == null ? "" : culqiAnwser.Transfer_id.ToString();
            return "true¬" + "La operación de realizó con éxito." + "¬" + tranferId;
        }
    }
}
