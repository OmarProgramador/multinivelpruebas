using BussinesRules.User;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class ResidualTreeC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            /*consulta a la base de datos*/
            var obj = HttpContext.Current.User.Identity.Name.Split('¬'); ;

            BrUser brUser = new BrUser();
            string data = brUser.getPartner(obj[1]);

            var arrayD = data.Split('¬');

            List<Partner1> partners1 = new List<Partner1>();

            var row1 = arrayD[0].Split('_');
            var padre1 = obj[2];

            var classCss = string.Empty;
            var classCssStatus = string.Empty;

            for (int i = 0; i < arrayD.Length; i++)
            {
                var row = arrayD[i].Split('_');
                var padre = row[0];
                //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                classCss = row[5] == obj[2] ? "affiliate" : "";
               

                if (padre1 == padre)
                {
                    partners1.Add(new Partner1 {
                        id = int.Parse(row[1]),
                        name = row[2],
                        title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3] });
                }
            }

            for (int i = 0; i < partners1.Count; i++)
            {
                string padre2 = partners1[i].id.ToString();
                List<Partner2> partners2 = new List<Partner2>();
                for (int j = 0; j < arrayD.Length; j++)
                {
                    var row = arrayD[j].Split('_');
                    var padre = row[0];
                    classCss = row[5] == obj[2] ? "affiliate" : "";

                   
                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                    if (padre2 == padre)
                    {
                        Partner2 partner2 = new Partner2();
                        partner2.id = int.Parse(row[1]);
                        partner2.name = row[2];
                        partner2.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                        partners2.Add(partner2);
                        partner2 = null;
                    }
                }
                partners1[i].children = partners2;
                partners2 = null;
            }


            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
                for (int j = 0; j < part2.Count; j++)
                {
                    string padre2 = part2[j].id.ToString();
                    List<Partner3> partners3 = new List<Partner3>();
                    for (int k = 0; k < arrayD.Length; k++)
                    {
                        var row = arrayD[k].Split('_');
                        var padre = row[0];
                        classCss = row[5] == obj[2] ? "affiliate" : "";
                        //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                        

                        if (padre2 == padre)
                        {
                            Partner3 partner3 = new Partner3();
                            partner3.id = int.Parse(row[1]);
                            partner3.name = row[2];
                            partner3.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                            partners3.Add(partner3);
                            partner3 = null;
                        }
                    }

                    part2[j].children = partners3;
                    partners3 = null;
                }
            }


            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
                for (int j = 0; j < part2.Count; j++)
                {
                    List<Partner3> part3 = part2[j].children;

                    for (int l = 0; l < part3.Count; l++)
                    {
                        string padre2 = part3[l].id.ToString();
                        List<Partner4> partners4 = new List<Partner4>();
                        for (int k = 0; k < arrayD.Length; k++)
                        {
                            var row = arrayD[k].Split('_');
                            var padre = row[0];
                            classCss = row[5] == obj[2] ? "affiliate" : "";
                            //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                           

                            if (padre2 == padre)
                            {
                                Partner4 partner4 = new Partner4();
                                partner4.id = int.Parse(row[1]);
                                partner4.name = row[2];
                                partner4.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                partners4.Add(partner4);
                                partner4 = null;
                            }
                        }

                        part3[l].children = partners4;
                        partners4 = null;
                    }
                }
            }



            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
                for (int j = 0; j < part2.Count; j++)
                {
                    List<Partner3> part3 = part2[j].children;

                    for (int l = 0; l < part3.Count; l++)
                    {
                        List<Partner4> part4 = part3[l].children;

                        for (int m = 0; m < part4.Count; m++)
                        {
                            string padre2 = part4[m].id.ToString();
                            List<Partner5> partners5 = new List<Partner5>();
                            for (int k = 0; k < arrayD.Length; k++)
                            {
                                var row = arrayD[k].Split('_');
                                var padre = row[0];
                                classCss = row[5] == obj[2] ? "affiliate" : "";
                                //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                

                                if (padre2 == padre)
                                {
                                    Partner5 partner5 = new Partner5();
                                    partner5.id = int.Parse(row[1]);
                                    partner5.name = row[2];
                                    partner5.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                    partners5.Add(partner5);
                                    partner5 = null;
                                }
                            }
                            part4[m].children = partners5;
                            partners5 = null;
                        }
                    }
                }
            }



            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                string padre2 = part5[n].id.ToString();
                                List<Partner6> partners6 = new List<Partner6>();
                                for (int k = 0; k < arrayD.Length; k++)
                                {
                                    var row = arrayD[k].Split('_');
                                    var padre = row[0];
                                    classCss = row[5] == obj[2] ? "affiliate" : "";
                                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                    

                                    if (padre2 == padre)
                                    {
                                        Partner6 partner6 = new Partner6();
                                        partner6.id = int.Parse(row[1]);
                                        partner6.name = row[2];
                                        partner6.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                        partners6.Add(partner6);
                                        partner6 = null;
                                    }
                                }
                                part5[n].children = partners6;
                                partners6 = null;
                            }
                        }
                    }
                }
            }


            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                    string padre2 = part6[o].id.ToString();
                                    List<Partner7> partners7 = new List<Partner7>();
                                    for (int k = 0; k < arrayD.Length; k++)
                                    {
                                        var row = arrayD[k].Split('_');
                                        var padre = row[0];
                                        classCss = row[5] == obj[2] ? "affiliate" : "";
                                        //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                       

                                        if (padre2 == padre)
                                        {
                                            Partner7 partner7 = new Partner7();
                                            partner7.id = int.Parse(row[1]);
                                            partner7.name = row[2];
                                            partner7.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                            partners7.Add(partner7);
                                            partner7 = null;
                                        }
                                    }
                                    part6[o].children = partners7;
                                    partners7 = null;
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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

                                        string padre2 = part7[p].id.ToString();
                                        List<Partner8> partners8 = new List<Partner8>();
                                        for (int k = 0; k < arrayD.Length; k++)
                                        {
                                            var row = arrayD[k].Split('_');
                                            var padre = row[0];
                                            classCss = row[5] == obj[2] ? "affiliate" : "";
                                            //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                           
                                            if (padre2 == padre)
                                            {
                                                Partner8 partner8 = new Partner8();
                                                partner8.id = int.Parse(row[1]);
                                                partner8.name = row[2];
                                                partner8.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                                partners8.Add(partner8);
                                                partner8 = null;
                                            }
                                        }
                                        part7[p].children = partners8;
                                        partners8 = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }



            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                            string padre2 = part8[q].id.ToString();
                                            List<Partner9> partners9 = new List<Partner9>();
                                            for (int k = 0; k < arrayD.Length; k++)
                                            {
                                                var row = arrayD[k].Split('_');
                                                var padre = row[0];
                                                classCss = row[5] == obj[2] ? "affiliate" : "";
                                                //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                               

                                                if (padre2 == padre)
                                                {
                                                    Partner9 partner9 = new Partner9();
                                                    partner9.id = int.Parse(row[1]);
                                                    partner9.name = row[2];
                                                    partner9.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                                    partners9.Add(partner9);
                                                    partner9 = null;
                                                }
                                            }
                                            part8[q].children = partners9;
                                            partners9 = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                                string padre2 = part9[r].id.ToString();
                                                List<Partner10> partners10 = new List<Partner10>();
                                                for (int k = 0; k < arrayD.Length; k++)
                                                {
                                                    var row = arrayD[k].Split('_');
                                                    var padre = row[0];
                                                    classCss = row[5] == obj[2] ? "affiliate" : "";
                                                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                                    

                                                    if (padre2 == padre)
                                                    {
                                                        Partner10 partner10 = new Partner10();
                                                        partner10.id = int.Parse(row[1]);
                                                        partner10.name = row[2];
                                                        partner10.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                                        partners10.Add(partner10);
                                                        partner10 = null;
                                                    }
                                                }
                                                part9[r].children = partners10;
                                                partners10 = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }



            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                                    string padre2 = part10[s].id.ToString();
                                                    List<Partner11> partners11 = new List<Partner11>();
                                                    for (int k = 0; k < arrayD.Length; k++)
                                                    {
                                                        var row = arrayD[k].Split('_');
                                                        var padre = row[0];
                                                        classCss = row[5] == obj[2] ? "affiliate" : "";
                                                        //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                                        if (padre2 == padre)
                                                        {
                                                            Partner11 partner11 = new Partner11();
                                                            partner11.id = int.Parse(row[1]);
                                                            partner11.name = row[2];
                                                            partner11.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                                            partners11.Add(partner11);
                                                            partner11 = null;
                                                        }
                                                    }
                                                    part10[s].children = partners11;
                                                    partners11 = null;
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


            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                                    List<Partner11> part11 = part10[s].children;
                                                    for (int t = 0; t < part11.Count; t++)
                                                    {
                                                        string padre2 = part11[t].id.ToString();
                                                        List<Partner12> partners12 = new List<Partner12>();
                                                        for (int k = 0; k < arrayD.Length; k++)
                                                        {
                                                            var row = arrayD[k].Split('_');
                                                            var padre = row[0];
                                                            classCss = row[5] == obj[2] ? "affiliate" : "";
                                                            //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                                            if (padre2 == padre)
                                                            {
                                                                Partner12 partner12 = new Partner12();
                                                                partner12.id = int.Parse(row[1]);
                                                                partner12.name = row[2];
                                                                partner12.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                                                partners12.Add(partner12);
                                                                partner12 = null;
                                                            }
                                                        }
                                                        part11[t].children = partners12;
                                                        partners12 = null;
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


            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                                    List<Partner11> part11 = part10[s].children;
                                                    for (int t = 0; t < part11.Count; t++)
                                                    {
                                                        List<Partner12> part12 = part11[t].children;
                                                        for (int u = 0; u < part12.Count; u++)
                                                        {
                                                            string padre2 = part12[u].id.ToString();
                                                            List<Partner13> partners13 = new List<Partner13>();
                                                            for (int k = 0; k < arrayD.Length; k++)
                                                            {
                                                                var row = arrayD[k].Split('_');
                                                                var padre = row[0];
                                                                classCss = row[5] == obj[2] ? "affiliate" : "";
                                                                //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                                                if (padre2 == padre)
                                                                {
                                                                    Partner13 partner13 = new Partner13();
                                                                    partner13.id = int.Parse(row[1]);
                                                                    partner13.name = row[2];
                                                                    partner13.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                                                    partners13.Add(partner13);
                                                                    partner13 = null;
                                                                }
                                                            }
                                                            part12[u].children = partners13;
                                                            partners13 = null;
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

            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                                    List<Partner11> part11 = part10[s].children;
                                                    for (int t = 0; t < part11.Count; t++)
                                                    {
                                                        List<Partner12> part12 = part11[t].children;
                                                        for (int u = 0; u < part12.Count; u++)
                                                        {
                                                            List<Partner13> part13 = part12[u].children;
                                                            for (int w = 0; w < part13.Count; w++)
                                                            {
                                                                string padre2 = part13[w].id.ToString();
                                                                List<Partner14> partners14 = new List<Partner14>();
                                                                for (int k = 0; k < arrayD.Length; k++)
                                                                {
                                                                    var row = arrayD[k].Split('_');
                                                                    var padre = row[0];
                                                                    classCss = row[5] == obj[2] ? "affiliate" : "";
                                                                    //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                                                    if (padre2 == padre)
                                                                    {
                                                                        Partner14 partner14 = new Partner14();
                                                                        partner14.id = int.Parse(row[1]);
                                                                        partner14.name = row[2];
                                                                        partner14.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
                                                                        partners14.Add(partner14);
                                                                        partner14 = null;
                                                                    }
                                                                }
                                                                part13[w].children = partners14;
                                                                partners14 = null;
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


            for (int i = 0; i < partners1.Count; i++)
            {
                List<Partner2> part2 = partners1[i].children;
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
                                                    List<Partner11> part11 = part10[s].children;
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
                                                                        classCss = row[5] == obj[2] ? "affiliate" : "";
                                                                        //IEnumerable<Partner> partner = partners.Where(x => x.Id == 3);
                                                                        if (padre2 == padre)
                                                                        {
                                                                            Partner15 partner15 = new Partner15();
                                                                            partner15.id = int.Parse(row[1]);
                                                                            partner15.name = row[2];
                                                                            partner15.title = $"<span class='{classCss} {cssClassStatus(row[4],row[6])}'> • </span> " + ConvertStatus(row[4]) + "<div></div> <br>" + row[3];
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
            string data2 = data;

            data = JsonConvert.SerializeObject(partners1);

            data = data.Replace("\"children\":[],", "");
            data = data.Replace("\"children\":null,", "");
            Response.Write(data);
            //Response.Write(data2);
            return;

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
                statusstr = "Promotor";
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

        public string cssClassStatus(string _status,string _payQuote)
        {
            string answer = "";
            if (_status == "1")
            {
                if (_payQuote == "1")
                {
                    answer = "statusgreen";
                }
                else
                {
                    answer = "statusambar";
                }
            }
            else if (_status == "6")
            {
                answer = "statusambar";
            }
            else if (_status == "7")
            {
                answer = "statusambar";
            }
            else
            {
                answer = "statusred";
            }

            return answer;
        }

        public enum ListStatus
        {
            Inactivo = 0,
            Activo = 1,
            Deuda_1 = 2,
            Deuda_2 = 3,
            Activo_Pendiente = 4,
            Deuda_0 = 5,
        }

    }
}