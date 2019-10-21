using BussinesRules.User;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;

namespace MULTI_NIVEL.Views
{
    public partial class Sponsored : System.Web.UI.Page
    {
        int globalLevel = 0;
        int rama1 = 0;
        string af = "";
        int ramita = 0;
        int abuelo = 0;
        string ra = "";
        int w200 = 0;
        string Rango = "";
        decimal ptsSocios;
        decimal TotPts = 0;
        int mayor = 0;
        decimal PtsRF = 0;
        int ramaFuerteCod = 0;
        string[] obj = HttpContext.Current.User.Identity.Name.Split('¬');
        List<Partner> milista = new List<Partner>();
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        public List<Partner> CalcRange(string id)
        {
            List<Partner> partners = new List<Partner>();

            //try
            //{
            String parametro = id;
            BrUser brUser = new BrUser();
            string data = brUser.GetSponsor(obj[1]);
            MyConstants myConstants = new MyConstants();
            MyFunctions myFunctions = new MyFunctions();

            var arrayD = data.Split('¬');
            //List<NewData> list = new List<NewData>();
            //list = data.Split('¬');
            List<Partner1> partners1 = new List<Partner1>();
            var row1 = arrayD[0].Split('|');
            var padre1 = obj[2];
            //partners1.Add(new Partner1 { Id = int.Parse(padre1) });

            for (int i = 0; i < arrayD.Length; i++)
            {

                var row = arrayD[i].Split('|');
                var padre = row[0];
                //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);

                if (padre1 == padre)
                {
                    int nivel = 1;
                    rama1 = rama1 + 1; // 1° rama
                                       //DateTime now = DateTime.Now;
                    var startDate = row[10];

                    //var Quince = startDate.AddDays(+30);
                    //var activoHasta = startDate.AddDays(+30).ToShortDateString();
                    partners1.Add(new Partner1
                    {
                        id = int.Parse(row[1]),
                        name = row[2],
                        Documento = row[3],
                        Rango = row[4],
                        Estado = row[5],
                        Nivel = nivel.ToString(),
                        Rama = rama1.ToString(),
                        PatrocinadorP = row[8],
                        Upline = row[9],
                        ProximaCuota = myFunctions.DateFormatClient(row[10]),
                        //Puntos = ptos.ToString(),
                        Puntos = row[11],
                        ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser),
                        TipoCa = row[13],
                        NAsociate = row[14],
                        FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser),
                        CalPuntos = row[16],
                        TotalAff = row[17],
                        TotalQuote = row[18],
                        TotalAmort = row[19],
                        NivelP = row[20]
                    });

                }
            }

            List<Partner2> partners2 = new List<Partner2>();
            for (int i = 0; i < partners1.Count; i++)
            {
                var rama2 = i + 1;
                string padre2 = partners1[i].id.ToString();
                var q = i;
                //var test = partners1[0].children;
                for (int j = 0; j < arrayD.Length; j++)
                {
                    var row = arrayD[j].Split('|');
                    var padre = row[0];
                    abuelo = i;
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 2;
                        w200 = int.Parse(partners1[i].Rama);

                        Partner2 partner2 = new Partner2();
                        partner2.id = int.Parse(row[1]);
                        partner2.name = row[2];
                        partner2.Documento = row[3];
                        partner2.Rango = row[4];
                        partner2.Estado = row[5];
                        partner2.Nivel = nivel.ToString();
                        partner2.Rama = w200.ToString();
                        partner2.PatrocinadorP = row[8];
                        partner2.Upline = row[9];
                        partner2.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner2.Puntos = row[11];
                        //partner2.Puntos = ptos.ToString();
                        partner2.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner2.TipoCa = row[13];
                        partner2.NAsociate = row[14];
                        partner2.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner2.CalPuntos = row[16];
                        partner2.TotalAff = row[17];
                        partner2.TotalQuote = row[18];
                        partner2.TotalAmort = row[19];
                        partner2.NivelP = row[20];
                        partners2.Add(partner2);
                        partner2 = null;
                    }
                }
                //partners1[i].children = partners2;
                //partners2 = null;
            }
            /*aqui comienzan los hijos*/

            //List<Partner2> part2 = partners1.children;

            List<Partner2> part2 = partners2;
            List<Partner3> partners3 = new List<Partner3>();
            for (int j = 0; j < part2.Count; j++)
            {
                string padre2 = part2[j].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];//padre de priscila
                                       //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 3;
                        var w300 = part2[j].Rama.ToString();

                        Partner3 partner3 = new Partner3();
                        partner3.id = int.Parse(row[1]);
                        partner3.name = row[2];
                        partner3.Documento = row[3];
                        partner3.Rango = row[4];
                        partner3.Estado = row[5];
                        partner3.Nivel = nivel.ToString();
                        partner3.Rama = w300.ToString();
                        partner3.PatrocinadorP = row[8];
                        partner3.Upline = row[9];
                        partner3.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner3.Puntos = row[11];
                        //partner3.Puntos = ptos.ToString();
                        partner3.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner3.TipoCa = row[13];
                        partner3.NAsociate = row[14];
                        partner3.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner3.CalPuntos = row[16];
                        partner3.TotalAff = row[17];
                        partner3.TotalQuote = row[18];
                        partner3.TotalAmort = row[19];
                        partner3.NivelP = row[20];
                        partners3.Add(partner3);
                        partner3 = null;
                    }
                }

                //part2[j].children = partners3;
                //partners3 = null;
            }



            List<Partner3> part3 = partners3;
            List<Partner4> partners4 = new List<Partner4>();
            for (int l = 0; l < part3.Count; l++)
            {
                string padre2 = part3[l].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 4;
                        var w400 = part3[l].Rama.ToString();

                        Partner4 partner4 = new Partner4();
                        partner4.id = int.Parse(row[1]);
                        partner4.name = row[2];
                        partner4.Documento = row[3];
                        partner4.Rango = row[4];
                        partner4.Estado = row[5];
                        partner4.Nivel = nivel.ToString();
                        partner4.Rama = w400.ToString();
                        partner4.PatrocinadorP = row[8];
                        partner4.Upline = row[9];
                        partner4.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner4.Puntos = row[11];
                        // partner4.Puntos = ptos.ToString();
                        partner4.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner4.TipoCa = row[13];
                        partner4.NAsociate = row[14];
                        partner4.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner4.CalPuntos = row[16];
                        partner4.TotalAff = row[17];
                        partner4.TotalQuote = row[18];
                        partner4.TotalAmort = row[19];
                        partner4.NivelP = row[20];
                        partners4.Add(partner4);
                        partner4 = null;
                    }
                }

                //part3[l].children = partners4;
                //partners4 = null;
            }

            List<Partner4> part4 = partners4;
            List<Partner5> partners5 = new List<Partner5>();
            for (int m = 0; m < part4.Count; m++)
            {
                string padre2 = part4[m].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 5;
                        var w500 = part4[m].Rama.ToString();
                        var ActiveUntil = myFunctions.DateFormatClient(row[10]);
                        Partner5 partner5 = new Partner5();
                        partner5.id = int.Parse(row[1]);
                        partner5.name = row[2];
                        partner5.Documento = row[3];
                        partner5.Rango = row[4];
                        partner5.Estado = row[5];
                        partner5.Nivel = nivel.ToString();
                        partner5.Rama = w500.ToString();
                        partner5.PatrocinadorP = row[8];
                        partner5.Upline = row[9];
                        partner5.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner5.Puntos = row[11];
                        //partner5.Puntos = ptos.ToString();
                        partner5.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner5.TipoCa = row[13];
                        partner5.NAsociate = row[14];
                        partner5.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner5.CalPuntos = row[16];
                        partner5.TotalAff = row[17];
                        partner5.TotalQuote = row[18];
                        partner5.TotalAmort = row[19];
                        partner5.NivelP = row[20];

                        partners5.Add(partner5);
                        partner5 = null;
                    }
                }

                //part4[m].children = partners5;
                //partners5 = null;
            }

            List<Partner5> part5 = partners5;
            List<Partner6> partners6 = new List<Partner6>();
            for (int n = 0; n < part5.Count; n++)
            {
                string padre2 = part5[n].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 6;
                        var w600 = part5[n].Rama.ToString();

                        Partner6 partner6 = new Partner6();
                        partner6.id = int.Parse(row[1]);
                        partner6.name = row[2];
                        partner6.Documento = row[3];
                        partner6.Rango = row[4];
                        partner6.Estado = row[5];
                        partner6.Nivel = nivel.ToString();
                        partner6.Rama = w600.ToString();
                        partner6.PatrocinadorP = row[8];
                        partner6.Upline = row[9];
                        partner6.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner6.Puntos = row[11];
                        //partner6.Puntos = ptos.ToString();
                        partner6.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner6.TipoCa = row[13];
                        partner6.NAsociate = row[14];
                        partner6.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner6.CalPuntos = row[16];
                        partner6.TotalAff = row[17];
                        partner6.TotalQuote = row[18];
                        partner6.TotalAmort = row[19];
                        partner6.NivelP = row[20];
                        partners6.Add(partner6);
                        partner6 = null;
                    }
                }

                //part5[n].children = partners6;
                //partners6 = null;
            }

            List<Partner6> part6 = partners6;
            List<Partner7> partners7 = new List<Partner7>();
            for (int o = 0; o < part6.Count; o++)
            {
                string padre2 = part6[o].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 7;
                        var w700 = part6[o].Rama.ToString();

                        Partner7 partner7 = new Partner7();
                        partner7.id = int.Parse(row[1]);
                        partner7.name = row[2];
                        partner7.Documento = row[3];
                        partner7.Rango = row[4];
                        partner7.Estado = row[5];
                        partner7.Nivel = nivel.ToString();
                        partner7.Rama = w700.ToString();
                        partner7.PatrocinadorP = row[8];
                        partner7.Upline = row[9];
                        partner7.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner7.Puntos = row[11];
                        //partner7.Puntos = ptos.ToString();
                        partner7.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner7.TipoCa = row[13];
                        partner7.NAsociate = row[14];
                        partner7.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner7.CalPuntos = row[16];
                        partner7.TotalAff = row[17];
                        partner7.TotalQuote = row[18];
                        partner7.TotalAmort = row[19];
                        partner7.NivelP = row[20];
                        partners7.Add(partner7);
                        partner7 = null;
                    }
                }

                //part6[o].children = partners7;
                //partners7 = null;
            }


            List<Partner7> part7 = partners7;
            List<Partner8> partners8 = new List<Partner8>();
            for (int p = 0; p < part7.Count; p++)
            {
                string padre2 = part7[p].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 8;
                        var w800 = part7[p].Rama.ToString();

                        Partner8 partner8 = new Partner8();
                        partner8.id = int.Parse(row[1]);
                        partner8.name = row[2];
                        partner8.Documento = row[3];
                        partner8.Rango = row[4];
                        partner8.Estado = row[5];
                        partner8.Nivel = nivel.ToString();
                        partner8.Rama = w800.ToString();
                        partner8.PatrocinadorP = row[8];
                        partner8.Upline = row[9];
                        partner8.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner8.Puntos = row[11];
                        // partner8.Puntos = ptos.ToString();
                        partner8.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner8.TipoCa = row[13];
                        partner8.NAsociate = row[14];
                        partner8.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner8.CalPuntos = row[16];
                        partner8.TotalAff = row[17];
                        partner8.TotalQuote = row[18];
                        partner8.TotalAmort = row[19];
                        partner8.NivelP = row[20];
                        partners8.Add(partner8);
                        partner8 = null;
                    }
                }

                //part7[p].children = partners8;
                //partners8 = null;
            }


            List<Partner8> part8 = partners8;
            List<Partner9> partners9 = new List<Partner9>();
            for (int q = 0; q < part8.Count; q++)
            {
                string padre2 = part8[q].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 9;
                        var w900 = part8[q].Rama.ToString();

                        Partner9 partner9 = new Partner9();
                        partner9.id = int.Parse(row[1]);
                        partner9.name = row[2];
                        partner9.Documento = row[3];
                        partner9.Rango = row[4];
                        partner9.Estado = row[5];
                        partner9.Nivel = nivel.ToString();
                        partner9.Rama = w900.ToString();
                        partner9.PatrocinadorP = row[8];
                        partner9.Upline = row[9];
                        partner9.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner9.Puntos = row[11];
                        //partner9.Puntos = ptos.ToString();
                        partner9.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner9.TipoCa = row[13];
                        partner9.NAsociate = row[14];
                        partner9.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner9.CalPuntos = row[16];
                        partner9.TotalAff = row[17];
                        partner9.TotalQuote = row[18];
                        partner9.TotalAmort = row[19];
                        partner9.NivelP = row[20];
                        partners9.Add(partner9);
                        partner9 = null;
                    }
                }

                //part8[q].children = partners9;
                //partners9 = null;
            }


            List<Partner9> part9 = partners9;
            List<Partner10> partners10 = new List<Partner10>();
            for (int r = 0; r < part9.Count; r++)
            {
                string padre2 = part9[r].id.ToString();
                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 10;
                        var w1000 = part9[r].Rama.ToString();

                        Partner10 partner10 = new Partner10();
                        partner10.id = int.Parse(row[1]);
                        partner10.name = row[2];
                        partner10.Documento = row[3];
                        partner10.Rango = row[4];
                        partner10.Estado = row[5];
                        partner10.Nivel = nivel.ToString();
                        partner10.Rama = w1000.ToString();
                        partner10.PatrocinadorP = row[8];
                        partner10.Upline = row[9];
                        partner10.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner10.Puntos = row[11];
                        //partner10.Puntos = ptos.ToString();
                        partner10.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner10.TipoCa = row[13];
                        partner10.NAsociate = row[14];
                        partner10.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner10.CalPuntos = row[16];
                        partner10.TotalAff = row[17];
                        partner10.TotalQuote = row[18];
                        partner10.TotalAmort = row[19];
                        partner10.NivelP = row[20];
                        partners10.Add(partner10);
                        partner10 = null;
                    }
                }

                //part9[r].children = partners10;
                //partners10 = null;
            }

            List<Partner10> part10 = partners10;
            List<Partner11> partners11 = new List<Partner11>();
            for (int s = 0; s < part10.Count; s++)
            {
                string padre2 = part10[s].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 11;
                        var w1100 = part10[s].Rama.ToString();

                        Partner11 partner11 = new Partner11();
                        partner11.id = int.Parse(row[1]);
                        partner11.name = row[2];
                        partner11.Documento = row[3];
                        partner11.Rango = row[4];
                        partner11.Estado = row[5];
                        partner11.Nivel = nivel.ToString();
                        partner11.Rama = w1100.ToString();
                        partner11.PatrocinadorP = row[8];
                        partner11.Upline = row[9];
                        partner11.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner11.Puntos = row[11];
                        //partner11.Puntos = ptos.ToString();
                        partner11.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner11.TipoCa = row[13];
                        partner11.NAsociate = row[14];
                        partner11.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner11.CalPuntos = row[16];
                        partner11.TotalAff = row[17];
                        partner11.TotalQuote = row[18];
                        partner11.TotalAmort = row[19];
                        partner11.NivelP = row[20];
                        partners11.Add(partner11);
                        partner11 = null;
                    }
                }

                //part10[s].children = partners11;
                //partners11 = null;
            }

            List<Partner11> part11 = partners11;
            List<Partner12> partners12 = new List<Partner12>();
            for (int t = 0; t < part11.Count; t++)
            {
                string padre2 = part11[t].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 12;
                        var w1200 = part11[t].Rama.ToString();

                        Partner12 partner12 = new Partner12();
                        partner12.id = int.Parse(row[1]);
                        partner12.name = row[2];
                        partner12.Documento = row[3];
                        partner12.Rango = row[4];
                        partner12.Estado = row[5];
                        partner12.Nivel = nivel.ToString();
                        partner12.Rama = w1200.ToString();
                        partner12.PatrocinadorP = row[8];
                        partner12.Upline = row[9];
                        partner12.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner12.Puntos = row[11];
                        //partner12.Puntos = ptos.ToString();
                        partner12.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner12.TipoCa = row[13];
                        partner12.NAsociate = row[14];
                        partner12.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner12.CalPuntos = row[16];
                        partner12.TotalAff = row[17];
                        partner12.TotalQuote = row[18];
                        partner12.TotalAmort = row[19];
                        partner12.NivelP = row[20];
                        partners12.Add(partner12);
                        partner12 = null;
                    }
                }

                //part11[t].children = partners12;
                //partners12 = null;
            }

            List<Partner12> part12 = partners12;
            List<Partner13> partners13 = new List<Partner13>();

            for (int u = 0; u < part12.Count; u++)
            {
                string padre2 = part12[u].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 13;
                        var w1300 = part12[u].Rama.ToString();

                        Partner13 partner13 = new Partner13();
                        partner13.id = int.Parse(row[1]);
                        partner13.name = row[2];
                        partner13.Documento = row[3];
                        partner13.Rango = row[4];
                        partner13.Estado = row[5];
                        partner13.Nivel = nivel.ToString();
                        partner13.Rama = w1300.ToString();
                        partner13.PatrocinadorP = row[8];
                        partner13.Upline = row[9];
                        partner13.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner13.Puntos = row[11];
                        //partner13.Puntos = ptos.ToString();
                        partner13.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner13.TipoCa = row[13];
                        partner13.NAsociate = row[14];
                        partner13.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner13.CalPuntos = row[16];
                        partner13.TotalAff = row[17];
                        partner13.TotalQuote = row[18];
                        partner13.TotalAmort = row[19];
                        partner13.NivelP = row[20];
                        partners13.Add(partner13);
                        partner13 = null;
                    }
                }

                //part12[u].children = partners13;
                //partners13 = null;
            }

            List<Partner13> part13 = partners13;
            List<Partner14> partners14 = new List<Partner14>();
            for (int w = 0; w < part13.Count; w++)
            {
                string padre2 = part13[w].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 14;
                        var w1400 = part12[w].Rama.ToString();

                        Partner14 partner14 = new Partner14();
                        partner14.id = int.Parse(row[1]);
                        partner14.name = row[2];
                        partner14.Documento = row[3];
                        partner14.Rango = row[4];
                        partner14.Estado = row[5];
                        partner14.Nivel = nivel.ToString();
                        partner14.Rama = w1400.ToString();
                        partner14.PatrocinadorP = row[8];
                        partner14.Upline = row[9];
                        partner14.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner14.Puntos = row[11];
                        //partner14.Puntos = ptos.ToString();
                        partner14.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner14.TipoCa = row[13];
                        partner14.NAsociate = row[14];
                        partner14.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner14.CalPuntos = row[16];
                        partner14.TotalAff = row[17];
                        partner14.TotalQuote = row[18];
                        partner14.TotalAmort = row[19];
                        partner14.NivelP = row[20];
                        partners14.Add(partner14);
                        partner14 = null;
                    }
                }

                //part13[w].children = partners14;
                //partners14 = null;
            }

            List<Partner14> part14 = partners14;
            List<Partner15> partners15 = new List<Partner15>();
            for (int y = 0; y < part14.Count; y++)
            {
                string padre2 = part14[y].id.ToString();

                for (int k = 0; k < arrayD.Length; k++)
                {
                    var row = arrayD[k].Split('|');
                    var padre = row[0];
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        int nivel = 15;
                        var w1500 = part14[y].Rama.ToString();

                        Partner15 partner15 = new Partner15();
                        partner15.id = int.Parse(row[1]);
                        partner15.name = row[2];
                        partner15.Documento = row[3];
                        partner15.Rango = row[4];
                        partner15.Estado = row[5];
                        partner15.Nivel = nivel.ToString();
                        partner15.Rama = w1500.ToString();
                        partner15.PatrocinadorP = row[8];
                        partner15.Upline = row[9];
                        partner15.ProximaCuota = myFunctions.DateFormatClient(row[10]);
                        partner15.Puntos = row[11];
                        //partner15.Puntos = ptos.ToString();
                        partner15.ActivoHasta = DateTime.Parse(row[12]).ToString(myConstants.DateFormatUser);
                        partner15.TipoCa = row[13];
                        partner15.NAsociate = row[14];
                        partner15.FAfiliacion = DateTime.Parse(row[15]).ToString(myConstants.DateFormatUser);
                        partner15.CalPuntos = row[16];
                        partner15.TotalAff = row[17];
                        partner15.TotalQuote = row[18];
                        partner15.TotalAmort = row[19];
                        partner15.NivelP = row[20];
                        partners15.Add(partner15);
                        partner15 = null;
                    }
                }

                //part14[y].children = partners15;
                //partners15 = null;
            }

            //string data = "[{'id':'10','name':'samir','children':[{'id':'33','name':'jorge','children':[{'id':'33','name':'william','children':[{'id':'33','name':'kevin','children':[{'id':'33','name':'omar','children':[{'id':'33','name':'dyan','children':[{'id':'33','name':'erick'}]}]}]}]}]}]},{'id':'10','name':'junior'}]";

            //data = JsonConvert.SerializeObject(partners2);



            //List<Partner2> part2 = partners1.children;

            var suma = 1;
            decimal listPtos = 0;
            var sumarf = 0;
            List<Partner1> part1 = partners1;
            int[] ramaPos = new int[part1.Count + 1];
            decimal[] puntosxR = new decimal[part1.Count + 1];
            for (int a = 0; a < part1.Count; a++)
            {
                for (int ri = 1; ri <= rama1; ri++)
                {

                    if (int.Parse(part1[a].Rama) == ri)
                    {
                        //listPtos = decimal.Parse(part1[a].Puntos);
                        listPtos = decimal.Parse(part1[a].CalPuntos);///////////////////////////aqui

                        //suma = suma + 1 ;
                        ramaPos[ri] = suma;
                        //sumarf = sumarf + listPtos;
                        puntosxR[ri] = listPtos;
                    }
                }
                milista.Add(part1[a]);
            }
            //List<Partner2> part2 = partners1.children;
            var suma2 = 0;
            int[] ramaPos2 = new int[part2.Count + 1];
            for (int j = 0; j < part2.Count; j++)
            {
                for (int ri = 1; ri <= rama1; ri++)
                {

                    if (int.Parse(part2[j].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part2[j].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;

                    }
                }
                milista.Add(part2[j]);
            }
            int[] ramaPos3 = new int[part3.Count + 1];
            for (int j = 0; j < part3.Count; j++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part3[j].Rama) == ri)
                    {

                        listPtos = decimal.Parse(part3[j].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;

                    }
                }
                milista.Add(part3[j]);
            }

            int[] ramaPos4 = new int[part4.Count + 1];
            for (int m = 0; m < part4.Count; m++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part4[m].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part4[m].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part4[m]);
            }
            int[] ramaPos5 = new int[part5.Count + 1];
            for (int n = 0; n < part5.Count; n++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part5[n].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part5[n].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part5[n]);

            }

            int[] ramaPos6 = new int[part6.Count + 1];
            for (int o = 0; o < part6.Count; o++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part6[o].Rama) == ri)
                    {

                        listPtos = decimal.Parse(part6[o].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part6[o]);

            }

            int[] ramaPos7 = new int[part7.Count + 1];
            for (int p = 0; p < part7.Count; p++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part7[p].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part7[p].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part7[p]);
            }

            int[] ramaPos8 = new int[part8.Count + 1];
            for (int q = 0; q < part8.Count; q++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part8[q].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part8[q].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part8[q]);

            }

            int[] ramaPos9 = new int[part9.Count + 1];
            for (int r = 0; r < part9.Count; r++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part9[r].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part9[r].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part9[r]);

            }
            int[] ramaPos10 = new int[part10.Count + 1];
            for (int s = 0; s < part10.Count; s++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part10[s].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part10[s].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part10[s]);

            }

            int[] ramaPos11 = new int[part11.Count + 1];
            for (int t = 0; t < part11.Count; t++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part11[t].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part11[t].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part11[t]);

            }

            int[] ramaPos12 = new int[part12.Count + 1];
            for (int u = 0; u < part12.Count; u++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part12[u].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part12[u].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part12[u]);

            }

            int[] ramaPos13 = new int[part13.Count + 1];
            for (int w = 0; w < part13.Count; w++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part13[w].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part13[w].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part13[w]);

            }

            int[] ramaPos14 = new int[part14.Count + 1];
            for (int y = 0; y < part14.Count; y++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part14[y].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part14[y].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part14[y]);
            }



            List<Partner15> part15 = partners15;
            int[] ramaPos15 = new int[part15.Count + 1];
            for (int z = 0; z < part15.Count; z++)
            {
                for (int ri = 0; ri <= rama1; ri++)
                {

                    if (int.Parse(part15[z].Rama) == ri)
                    {
                        listPtos = decimal.Parse(part15[z].CalPuntos);
                        ramaPos[ri] = ramaPos[ri] + 1;
                        puntosxR[ri] = puntosxR[ri] + listPtos;
                    }
                }
                milista.Add(part15[z]);
            }


            mayor = 0;
            PtsRF = 0;
            ramaFuerteCod = 0;
            for (int i = 1; i < ramaPos.Length; i++)
            {
                if (ramaPos[i] > mayor)
                {
                    mayor = ramaPos[i];
                    ramaFuerteCod = i;
                }
            }
            for (int i = 1; i < puntosxR.Length; i++)
            {
                if (puntosxR[i] > PtsRF)
                {
                    PtsRF = puntosxR[i];
                }
            }

            TotPts = 0;
            for (int i = 0; i < puntosxR.Length; i++)
            {
                TotPts = TotPts + puntosxR[i];
            }
            ptsSocios = TotPts - PtsRF;
            var RangoSocios = 4;////////     faltaa <<<<---------



            //pts                       //socios directos          //Min Socios           //Rango Socios
            if (ptsSocios >= 10000000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Diamante Imperial";
                Session["RangoNum"] = "15";
            }
            else if (ptsSocios >= 5000000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Triple Diamante";
                Session["RangoNum"] = "14";
            }
            else if (ptsSocios >= 2500000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Doble Diamante";
                Session["RangoNum"] = "13";
            }
            else if (ptsSocios >= 1000000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Diamante Azul";
                Session["RangoNum"] = "12";
            }
            else if (ptsSocios >= 500000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Diamante Dorado";
                Session["RangoNum"] = "11";
            }
            else if (ptsSocios >= 250000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Diamante Negro";
                Session["RangoNum"] = "10";
            }
            else if (ptsSocios >= 100000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Diamante";
                Session["RangoNum"] = "9";
            }
            else if (ptsSocios >= 50000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Platino";
                Session["RangoNum"] = "8";
            }
            else if (ptsSocios >= 25000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Esmeralda";
                Session["RangoNum"] = "7";
            }
            else if (ptsSocios >= 10000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 70 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Ruby";
                Session["RangoNum"] = "6";
            }
            else if (ptsSocios >= 5000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 30 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Zafiro";
                Session["RangoNum"] = "5";
            }
            else if (ptsSocios >= 2500 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 15 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Oro";
                Session["RangoNum"] = "4";
            }
            else if (ptsSocios >= 1000 && (ramaPos.Length) - 1 >= 4 && milista.Count >= 4 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Plata";
                Session["RangoNum"] = "3";
            }
            else if (ptsSocios >= 250 && (ramaPos.Length) - 1 >= 2 && milista.Count >= 2 && RangoSocios >= 4)
            {
                Session["RangoSoc"] = "Bronce";
                Session["RangoNum"] = "2";
            }
            else
            {
                Session["RangoSoc"] = "Asesor de Inversion";
                Session["RangoNum"] = "1";
            }

            //for (int i = 0; i < milista.Count; i++)
            //{
            //    milista[i].Rango = "Socio Inversor";
            //}

            //var newRange = Session["RangoNum"].ToString();

            //var RefreshRange = brUser.RegisterRange(obj[2], newRange);

            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("error.aspx?error=" + ex.Message, true);

            //}
            return milista;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (obj.Length == 1)
            {
                Response.Redirect("Register.aspx", true);
            }


            if (!IsPostBack)
            {
                this.lblUser.Text = "Hola " + obj[0];
                this.lblUserName.Text = obj[0];
                this.lblNumPartner.Text = "N° Asociado: " + obj[4];

                this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                lblDate.Text = DateTime.Now.ToLongDateString();
                CalcRange(obj[2]);

                //PuntosSocio.Text = ptsSocios.ToString();
                //PuntosRF.Text = TotPts.ToString();
                //ptosRF.Text = PtsRF.ToString();
                //RangoSoc.Text = Session["RangoSoc"].ToString();
                //ramaFuerte.Text = ramaFuerteCod.ToString();
                //totalAfiRamF.Text = mayor.ToString();
                ////List<Partner> milista = CalcRange(obj[2]);
                //totalAfi.Text = milista.Count.ToString();


                gvSponsor.DataSource = milista;
                gvSponsor.DataBind();

                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                nombreu = obj[1];
                foreach (var fi2 in di1.GetFiles())
                {
                    var archivo = fi2.Name.Split('.');
                    name = archivo[archivo.Length - 2];
                    extension = archivo[archivo.Length - 1];
                    if (name == nombreu) { def = nombreu + "." + extension; }
                }
                imgProfile.ImageUrl = "~/Resources/imguser/" + def;
                imgProfile.Style.Add("width", "40px");
                imgProfile.Style.Add("height", "40px");
                imgProfile.Style.Add("margin", "0 auto");
                imgProfileFl.ImageUrl = "~/Resources/imguser/" + def;
                imgProfileFl.Style.Add("width", "40px");
                imgProfileFl.Style.Add("height", "40px");
                imgProfileFl.Style.Add("margin", "0 auto");
            }



        }

        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }
    }
}