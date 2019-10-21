using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class _DatePayInitial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string answer = "<option value=''>--Seleccionar--</option>";
            MyConstants mc = new MyConstants();
            MyFunctions mf = new MyFunctions();
            var listNUmberDate = DaysToChoose(DateTime.Now.ToString(mc.DateFormatBd));

            int monthC = DateTime.Now.Month;
            string monthCurrent = mf.GetMonth((monthC).ToString());
            string monthNext = mf.GetMonth((monthC + 1).ToString());
            string monthNextDos = mf.GetMonth((monthC + 2).ToString());
            //el dia de pago de cuotas
            string stringMonth = monthCurrent;
            int interr = 0;
            for (int i = 0; i < listNUmberDate.Length; i++)
            {
                if (listNUmberDate[i] == 0)
                {
                    stringMonth = monthNext;
                    interr++;

                    //if (interr > 1)
                    //{
                    //    stringMonth = monthNextDos;
                    //}
                }
                if (listNUmberDate[i] != 0)
                {
                    answer += $"<option value='{listNUmberDate[i].ToString()}_{stringMonth}' data-category='{stringMonth}'>{listNUmberDate[i].ToString()}</option>";
                    
                    //ListItem item = new ListItem(listNUmberDate[i].ToString(), listNUmberDate[i].ToString() + "_" + stringMonth);
                    //item.Attributes["data-category"] = stringMonth;
                    //ddlDateCuotas.Items.Add(item);
                    
                }
            }
            
            Response.Write(answer);
        }

        public int[] DaysToChoose(string date)
        {
            string anio = date.Split('-')[0];
            string month = date.Split('-')[1];
            int day = int.Parse(date.Split('-')[2]);

            string newDatem = DateTime.Parse(anio + "-" + month + "-01").AddMonths(1).ToString("yyyy-MM-dd");
            string newDatemc = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
            string newDate = DateTime.Parse(newDatem).AddDays(-1).ToString("yyyy-MM-dd");

            int endDay = int.Parse(newDate.Split('-')[2]);
            int[] arrayDay = new int[32];
            int contador = -1;

            int contadorMas = day;
            //contador++;
            //arrayDay[contador] = 0;

            int interructor = 0;
            int untilDay = int.Parse(newDatemc.Split('-')[2]);
            for (int i = 0; i < 16; i++)
            {
                try
                {
                    if (interructor == 0)
                    {
                        contador++;
                        contadorMas = contadorMas + 1;
                        var fecha = DateTime.Parse(anio + "-" + month + "-" + (contadorMas).ToString());

                        arrayDay[contador] = contadorMas;
                    }
                    interructor = 0;
                }
                catch (Exception ex)
                {
                    interructor = 1;
                    string error = ex.Message;
                    i -= 1;
                    contadorMas = 0;
                    contador++;
                    arrayDay[contador] = contadorMas;
                }

            }

            //Array.Sort(arrayDay);

            return arrayDay;
        }

    }
}