
namespace MULTI_NIVEL.Views
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using BussinesRules.User;
    using Entities;
    using Newtonsoft.Json;

    public partial class SponsoredData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String parametro = Request["id"];
                /*consulta a la base de datos*/
                var obj = HttpContext.Current.User.Identity.Name.Split('¬'); ;
                BrUser brUser = new BrUser();
                string data = brUser.GetSponsor(obj[1]);

                var arrayD = data.Split('¬');

                List<Partner1> partners1 = new List<Partner1>();
                List<Partner2> listpartner2 = new List<Partner2>();

                var row1 = arrayD[0].Split('_');
                var padre1 = obj[2];

                for (int li = 0; li < arrayD.Length; li++)
                {
                    var row = arrayD[li].Split('_');
                    var padre = row[0];

                    if (padre1 == padre)
                    {
                        Partner2 partner2 = new Partner2();
                        partner2.id = int.Parse(row[1]);
                        partner2.name = row[2];
                        partner2.Documento = row[3];
                        partner2.Rango = row[4];
                        partner2.Estado = row[5];
                        partner2.Nivel = row[6];
                        partner2.Rama = row[7];
                        partner2.PatrocinadorP = row[8];
                        partner2.Upline = row[9];
                        partner2.ProximaCuota = row[10];
                        partner2.Puntos = row[11];
                        partner2.ActivoHasta = row[12];
                        listpartner2.Add(partner2);
                        partner2 = null;
                    }
                }
                    partners1[0].children = listpartner2;
                    for (int i = 0; i < partners1.Count; i++)
                    {
                        List<Partner2> part2 = partners1[0].children;

                        for (int j = 0; j < part2.Count; j++)
                        {
                            List<Partner3> part3 = part2[j].children;
                            for (int l = 0; l < part3.Count; l++)
                            {
                                List<Partner4> part4 = part3[l].children;
                                for (int m = 0; m < part4.Count; m++)
                                {
                                    List<Partner5> part5 = part4[m].children;
                                    for (int n = 0; n < part5.Count; n++)
                                    {
                                        List<Partner6> part6 = part5[n].children;
                                        for (int o = 0; o < part6.Count; o++)
                                        {
                                            List<Partner7> part7 = part6[o].children;
                                            for (int p = 0; p < part7.Count; p++)
                                            {
                                                List<Partner8> part8 = part7[p].children;
                                                for (int q = 0; q < part8.Count; q++)
                                                {
                                                    List<Partner9> part9 = part8[q].children;
                                                    for (int r = 0; r < part9.Count; r++)
                                                    {
                                                        List<Partner10> part10 = part9[r].children;
                                                        for (int s = 0; s < part10.Count; s++)
                                                        {
                                                            List<Partner11> part11 = part10[r].children;
                                                            for (int t = 0; t < part11.Count; t++)
                                                            {
                                                                List<Partner12> part12 = part11[t].children;
                                                                for (int u = 0; u < part12.Count; u++)
                                                                {
                                                                    List<Partner13> part13 = part12[u].children;
                                                                    for (int w = 0; w < part13.Count; w++)
                                                                    {
                                                                        List<Partner14> part14 = part13[w].children;
                                                                        for (int y = 0; y < part14.Count; y++)
                                                                        {
                                                                            string padre2 = part14[y].id.ToString();
                                                                            List<Partner15> partners15 = new List<Partner15>();
                                                                            for (int k = 0; k < arrayD.Length; k++)
                                                                            {
                                                                                var row = arrayD[k].Split('_');
                                                                                var padre = row[0];
                                                                                //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                                                                if (padre2 == padre)
                                                                                {
                                                                                    Partner15 partner15 = new Partner15();
                                                                                    partner15.id = int.Parse(row[1]);
                                                                                    partner15.name = row[2];
                                                                                    partner15.Documento = row[3];
                                                                                    partner15.Rango = row[4];
                                                                                    partner15.Estado = row[5];
                                                                                    partner15.Nivel = row[6];
                                                                                    partner15.Rama = row[7];
                                                                                    partner15.PatrocinadorP = row[8];
                                                                                    partner15.Upline = row[9];
                                                                                    partner15.ProximaCuota = row[10];
                                                                                    partner15.Puntos = row[11];
                                                                                    partner15.ActivoHasta = row[12];
                                                                                    partners15.Add(partner15);
                                                                                    partner15 = null;
                                                                                }
                                                                            }
                                                                            part14[y].children = partners15;
                                                                            partners15 = null;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                
                //string data = "[{'id':'10','name':'samir','children':[{'id':'33','name':'jorge','children':[{'id':'33','name':'william','children':[{'id':'33','name':'kevin','children':[{'id':'33','name':'omar','children':[{'id':'33','name':'dyan','children':[{'id':'33','name':'erick'}]}]}]}]}]}]},{'id':'10','name':'junior'}]";
               
                //data = JsonConvert.SerializeObject(partners2);           
            }
            catch (Exception)
            {
                Response.Write("");
                return;
            }

        }
    }
}