
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using BussinesRules.TypeMembership;
    using BussinesRules.User;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Web;
    using System.Web.Security;

    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string def = "profile.png";
            string extension = ".png";
            string name = "";
            string nombreu = "";
            int AccountNews = 0;
            try
            {
                if (!IsPostBack)
                {

                    var arraLogin = HttpContext.Current.User.Identity.Name.Split('¬');

                    var refer = arraLogin[arraLogin.Length - 1];
                    if (refer == "referido")
                    {
                        Response.Redirect("SignOutC.aspx");
                    }

                    BrUser brUser = new BrUser();
                    MyConstants myConstants = new MyConstants();
                    var Arraytexto = brUser.GetNews();


                    if (Arraytexto != "")
                    {
                        var rows = Arraytexto.Split('¬');
                        for (var i = 0; i < rows.Length; i++)
                        {
                            var row = rows[i].Split('|');
                            var ids = row[1];
                        }
                    }

                    int ServerNews = brUser.GetNewsCount();
                    if (arraLogin.Length > 1)
                    {
                        AccountNews = brUser.GetCountAccountNews(arraLogin[2]);

                        if (AccountNews == 0 && ServerNews > 0)
                        {
                            var Read = 0;
                            var IdAccount = arraLogin[2];
                            var NotifCount = ServerNews;
                            var regNewsCount = Read + "|" + IdAccount + "|" + NotifCount;

                            brUser.RegNewsCount(regNewsCount);
                            quantity2.Text = ServerNews.ToString();
                            //globo2.Style.Add("display", "block");
                        }
                        else
                        {
                            if (ServerNews > AccountNews)
                            {
                                var newCurrent = ServerNews - AccountNews;
                                AccountNews = AccountNews + newCurrent;
                                quantity2.Text = AccountNews.ToString();
                                //globo2.Style.Add("display", "block");
                                var update = arraLogin[2] + "¬" + AccountNews;
                                brUser.UpdateAccountNewsCount(update);
                            }
                            else
                            {
                                quantity2.Text = AccountNews.ToString();
                                //globo2.Style.Add("display", "block");
                            }
                        }
                    }
                    //ejecutamos la validation del estado
                    BrInformacion brInformacion = new BrInformacion();
                    bool activeUp = brInformacion.ActiveUp();

                    if (arraLogin[0] == "ERROR" || string.IsNullOrEmpty(arraLogin[0]))
                    {
                        Session.Contents.RemoveAll();
                        FormsAuthentication.SignOut();
                        HttpContext.Current.Response.Redirect("Index.aspx", true);
                    }

                    string range = "";
                    string userName = "";
                    string depthLevels = "";
                    string nameRange = "";
                    string userNameBann = arraLogin[0];
                    //Label1.Text = DateTime.Now.ToString("G");
                    if (string.IsNullOrEmpty(arraLogin[0]))
                    {
                        Response.Redirect("Login.aspx", true);
                    }
                    if (arraLogin.Length == 1)
                    {
                        Response.Redirect("Register.aspx", true);
                    }
                    Session.Clear();
                    Session["tienda"] = "0";
                    Session["StatusExonerar"] = 0;
                    Session["link"] = "";

                    userName = arraLogin[1];

                    //BrAccount brAccount = new BrAccount();
                    //bool IsupdateRange = brAccount.UpdateRange(userName);

                    DateTime now = DateTime.Now;
                    var startDate = new DateTime(now.Year, now.Month, 1);
                    var test = startDate;
                    var Today = DateTime.Now.ToString("dd/MM/yyyy");
                    var Quince = startDate.AddDays(+14);
                    var Quincetest = Quince.ToString("dd/MM/yyyy");
                    var Dieci = startDate.AddDays(+15).ToShortDateString();
                    var endDate = startDate.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy");

                    string[] arrayLines = brInformacion.GetPointsLines(userName).Split('¬');

                    double[] linesInt = new double[arrayLines.Length];
                    List<double> mnNivel = new List<double>();
                    int[] countInt = new int[arrayLines.Length];
                    for (int i = 0; i < arrayLines.Length; i++)
                    {
                        var row = arrayLines[i].Split('|');
                        linesInt[i] = double.Parse(row[0] + row[1]);
                        mnNivel.Add(double.Parse(row[0]));
                        countInt[i] = int.Parse(row[1]);
                    }
                    //Array.Sort(linesInt);
                    //Array.Reverse(linesInt);
                    string formartNumber = "###,###,###,##0.00";
                    double total1 = 0, total2 = 0, total3 = 0, total4 = 0;
                    int rama1 = 1, rama2 = 2, rama3 = 3, rama4 = 4;

                    int indice = 0;
                    if (arrayLines.Length >= 1)
                    {
                        //lblRankVolume.Text = arrayIndex[0];
                        FirtsLine.Text = linesInt[0].ToString(formartNumber);
                        total1 = linesInt[0];
                        indice = int.Parse(total1.ToString().Substring(total1.ToString().Length - 1, 1));
                        rama1 = indice;
                        //FirtsLineChildren.Text = countInt[indice].ToString();
                    }
                    if (arrayLines.Length >= 2)
                    {
                        SecondLine.Text = linesInt[1].ToString(formartNumber);
                        total2 = linesInt[1];
                        indice = int.Parse(total2.ToString().Substring(total2.ToString().Length - 1, 1));
                        rama2 = indice;
                        //SecondLineChildren.Text = countInt[indice].ToString();
                    }
                    if (arrayLines.Length >= 3)
                    {
                        ThirdLine.Text = linesInt[2].ToString(formartNumber);
                        total3 = linesInt[2];
                        indice = int.Parse(total3.ToString().Substring(total3.ToString().Length - 1, 1));
                        rama3 = indice;
                        //ThirdLineChildren.Text = countInt[indice].ToString();
                    }
                    if (arrayLines.Length >= 4)
                    {

                        total4 = linesInt[3];
                        indice = int.Parse(total4.ToString().Substring(total4.ToString().Length - 1, 1));
                        rama4 = indice;
                        //FourthLineChildren.Text = countInt[indice].ToString();
                    }
                    double VoluRango = total1 + total2 + total3 + total4;
                    lblRankVolume.Text = VoluRango.ToString(formartNumber);
                    RamaTo1.Text = rama1.ToString();
                    RamaTo2.Text = rama2.ToString();
                    RamaTo3.Text = rama3.ToString();

                    //proximo rango
                    //var nextRangea = brInformacion.GetNextRange(userName).Split('|');
                    //NextRange.Text = nextRangea[0];
                    //NextRangePoints.Text = nextRangea[1];
                    //la ultima version publicada el dia 26-12-2018
                    var statusLeter = string.Empty;
                    string dataValues = brUser.GetAccountStatus(userName);
                    if (dataValues.Split('|').Length > 1)
                    {
                        StatusAcount.Text = dataValues.Split('|')[0];
                        statusLeter = dataValues.Split('|')[0];

                        if (dataValues.Split('|')[1] != "--")
                        {
                            NextDate.Text = DateTime.Parse(dataValues.Split('|')[1]).ToString(myConstants.DateFormatUser);
                        }
                        else
                        {
                            NextDate.Text = dataValues.Split('|')[1];
                        }

                        string pointQuotePay = brUser.GetPointsQuotePay(userName);
                        Points.Text = pointQuotePay;
                        //lblRankVolume.Text = dataValues.Split('|')[2];
                        if (!string.IsNullOrEmpty(dataValues.Split('|')[3]))
                        {
                            ActivoHasta.Text = DateTime.Parse(dataValues.Split('|')[3]).ToString(myConstants.DateFormatUser);
                        }
                        else
                        {
                            ActivoHasta.Text = dataValues.Split('|')[3];
                        }
                    }
                    string[] arrayrange = brUser.GetRange(userName).Split('|');
                    range = "SOC";
                    depthLevels = "0";
                    if (arrayrange.Length > 1)
                    {
                        range = arrayrange[0];
                        namerange.Text = arrayrange[2].ToString();
                        lblUserban.Text = userNameBann;

                        depthLevels = arrayrange[1];
                        lblDepthLevels.Text = depthLevels;
                        var lastDateRange = DateTime.Parse(arrayrange[3]).AddDays(5);

                        if (lastDateRange < DateTime.Now)
                        {
                            modalCara.Style.Add("display", "none");

                        }
                        if (statusLeter == "Stand bye" || statusLeter == "Promotor")
                        {
                            modalCara.Style.Add("display", "none");
                        }
                    }



                    if (now > Quince)  //para saber si funciona ... solo cambiar > por <
                    {
                        lblCicloFacIni.Text = Convert.ToDateTime(Dieci).ToString("dd/MM/yyyy");
                        lblCicloFacTo.Text = endDate;
                        lblCicloCalIni.Text = Convert.ToDateTime(Dieci).ToString("dd/MM/yyyy");
                        lblCicloCalTo.Text = endDate;
                    }
                    else
                    {
                        lblCicloFacIni.Text = Convert.ToDateTime(test).ToString("dd/MM/yyyy");
                        lblCicloFacTo.Text = Quincetest;
                        lblCicloCalIni.Text = Convert.ToDateTime(test).ToString("dd/MM/yyyy");
                        lblCicloCalTo.Text = Quincetest;
                    }

                    //puntaje de rango y puntaje del proximo rango
                    var rangess = brInformacion.GetCurrentAndNextRange(range).Split('$');
                    var ranges = rangess[0].Split('¬');
                    var firtran = ranges[0].Split('|');
                    var seconran = ranges[1].Split('|');
                    double firtsLinePd = double.Parse(firtran[0]) * double.Parse(rangess[1]);
                    double secondLinePd = double.Parse(firtran[1]) * double.Parse(rangess[1]);
                    double thirdLinePd = double.Parse(firtran[2]) * double.Parse(rangess[1]);
                    double fourthLinePd = double.Parse(firtran[3]) * double.Parse(rangess[1]);
                    double totalRangeCurren = firtsLinePd + secondLinePd + thirdLinePd;
                    TotalRangeCurrent.Text = totalRangeCurren.ToString(formartNumber);
                    if (firtsLinePd != 0)
                    {
                        TituloRActual.Text = "Rango Actual";
                    }
                    else
                    {
                        DivRange1.CssClass = "display-none";
                        DivRange2.CssClass = "display-none";
                        DivRange3.CssClass = "display-none";

                    }

                    FirtsLineP.Text = firtsLinePd.ToString(formartNumber);
                    SecondLineP.Text = secondLinePd.ToString(formartNumber);
                    ThirdLineP.Text = thirdLinePd.ToString(formartNumber);


                    double firtsLineP2d = double.Parse(seconran[0]) * double.Parse(rangess[1]);
                    double secondLineP2d = double.Parse(seconran[1]) * double.Parse(rangess[1]);
                    double thirdLineP2d = double.Parse(seconran[2]) * double.Parse(rangess[1]);
                    double fourthLineP2d = double.Parse(seconran[3]) * double.Parse(rangess[1]);
                    double sumProxRang = firtsLineP2d + secondLineP2d + thirdLineP2d;


                    FirtsLineP2Icon.CssClass = "range-bag";
                    SecondLineP2Icon.CssClass = "range-bag";
                    ThirdLineP2Icon.CssClass = "range-bag";


                    var maxminiun = brInformacion.GetMaximiumMinium(range).Split('|');

                    var maxi = Math.Round(double.Parse(maxminiun[0]));
                    var mini = Math.Round(double.Parse(maxminiun[1]));
                    var pointmm = double.Parse(maxminiun[2]);

                    maxi = maxi * pointmm;
                    mini = mini * pointmm;


                    ValueIdeal.Text = firtsLineP2d.ToString("0.00");
                    ValueIdeal2.Text = secondLineP2d.ToString("0.00");
                    ValueIdeal3.Text = thirdLineP2d.ToString("0.00");

                    if (total1 < mini)
                    {

                        firtsLineP2d = total1;
                    }
                    if (total2 < mini)
                    {

                        secondLineP2d = total2;
                    }
                    if (total3 < mini)
                    {

                        thirdLineP2d = total3;
                    }




                    if (total1 > mini)
                    {
                        FirtsLineP2Icon.CssClass = "range-ambar";
                        firtsLineP2d = mini;
                    }
                    if (total2 > mini)
                    {
                        SecondLineP2Icon.CssClass = "range-ambar";
                        secondLineP2d = mini;
                    }
                    if (total3 > mini)
                    {
                        ThirdLineP2Icon.CssClass = "range-ambar";
                        thirdLineP2d = mini;
                    }



                    if (total1 >= maxi)
                    {
                        FirtsLineP2Icon.CssClass = "range-good";
                        firtsLineP2d = maxi;
                    }
                    if (total2 >= maxi)
                    {
                        SecondLineP2Icon.CssClass = "range-good";
                        secondLineP2d = maxi;
                    }
                    if (total3 >= maxi)
                    {
                        ThirdLineP2Icon.CssClass = "range-good";
                        thirdLineP2d = maxi;
                    }
                    if (total4 > fourthLineP2d)
                    {

                    }

                    FirtsLineP2.Text = firtsLineP2d.ToString(formartNumber);
                    SecondLineP2.Text = secondLineP2d.ToString(formartNumber);
                    ThirdLineP2.Text = thirdLineP2d.ToString(formartNumber);

                    SumProxRange.Text = sumProxRang.ToString(formartNumber);


                    double rpuntaj1 = 0, rpuntaj2 = 0, rpuntaj3 = 0, rpuntaj4 = 0, rpuntajto = 0;

                    rpuntaj1 = total1;
                    rpuntaj2 = total2;
                    rpuntaj3 = total3;
                    rpuntaj4 = total4;
                    if (firtsLineP2d < total1)
                    {
                        rpuntaj1 = firtsLineP2d;
                    }
                    if (secondLineP2d < total2)
                    {
                        rpuntaj2 = secondLineP2d;
                    }
                    if (thirdLineP2d < total3)
                    {
                        rpuntaj3 = thirdLineP2d;
                    }
                    if (fourthLineP2d < total4)
                    {
                        rpuntaj4 = fourthLineP2d;
                    }
                    rpuntajto = rpuntaj1 + rpuntaj2 + rpuntaj3 + rpuntaj4;

                    Rpuntaje1.Text = rpuntaj1.ToString(formartNumber);
                    Rpuntaje2.Text = rpuntaj2.ToString(formartNumber);
                    Rpuntaje3.Text = rpuntaj3.ToString(formartNumber);

                    Rpuntajtotal.Text = rpuntajto.ToString(formartNumber);

                    double ptsFalta = sumProxRang - rpuntajto;
                    double persFalta = ptsFalta / double.Parse(rangess[1]);
                    PtsFaltan.Text = ptsFalta.ToString(formartNumber);
                    PersFaltan.Text = persFalta.ToString("0");
                    //hasta ahora 4 
                    //nombree completo ¬ usuario ¬ id person¬ status payments
                    //login con usuario y contraseña            
                    Session["Referido"] = arraLogin[1];
                    lblUser.Text = "Hola " + arraLogin[0];
                    lblUserName.Text = arraLogin[0];
                    lblNumPartner.Text = "N° Asociado: " + arraLogin[4];

                    imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";


                    string nsocios = brUser.GetCountsAsociate();
                    lblnsocios.Text = nsocios;
                    string lineActive = brUser.GetLineActives(userName);
                    lblActivas.Text = lineActive.ToString();

                    //int idMember = int.Parse(brUser.GetMembershipType(arraLogin[1]));
                    ////int idMember = 1;
                    //brUser = null;    
                    //int isadmin = int.Parse(arraLogin[2]);
                    //if (isadmin == 1)
                    //{
                    //    brUser.NotifRegPendients();
                    //}

                    string[] arrayLinesResid = brInformacion.GetPointsLinesResid(userName).Split('¬');
                    double[] linesIntResid = new double[arrayLinesResid.Length];


                    var rangeResidualCurrent = brInformacion.GetRangeResidualCurrent(userName);


                    var resPointres = brInformacion.GetPointsRange(rangeResidualCurrent).Split('|');

                    var resPointres1 = decimal.Parse(resPointres[0]);
                    var resPointres2 = decimal.Parse(resPointres[1]);
                    var resPointres3 = decimal.Parse(resPointres[2]);

                    var resPointresTotal = resPointres1 + resPointres2 + resPointres3;



                    TotalResidualc.Text = resPointresTotal.ToString();

                    Residualpa1.Text = resPointres1.ToString();
                    Residualpa2.Text = resPointres2.ToString();
                    Residualpa3.Text = resPointres3.ToString();


                    //proximo rango ideal
                    var resPointresprox = brInformacion.GetPointsRangeProximo(rangeResidualCurrent).Split('|');

                    var resPointres1prox = decimal.Parse(resPointresprox[0]);
                    var resPointres2prox = decimal.Parse(resPointresprox[1]);
                    var resPointres3prox = decimal.Parse(resPointresprox[2]);

                    var resPointresTotalprox = resPointres1prox + resPointres2prox + resPointres3prox;

                    TotalResidualActual.Text = resPointresTotalprox.ToString();

                    ResidualIdeal1.Text = resPointres1prox.ToString();
                    ResidualIdeal2.Text = resPointres2prox.ToString();
                    ResidualIdeal3.Text = resPointres3prox.ToString();
                    


                    var maxminiunResid = brInformacion.GetMaximiumMinium(rangeResidualCurrent).Split('|');

                    var maxir = Math.Round(double.Parse(maxminiunResid[0]));
                    var minir = Math.Round(double.Parse(maxminiunResid[1]));
                    var pointmmr = double.Parse(maxminiunResid[2]);

                    maxir = maxir * pointmm;
                    minir = minir * pointmm;


                    var firtsRes = arrayLinesResid[0].Split('|')[0];

                    var secondRes = "0";
                    var thereRes = "0";
                    var fourthRes = "0";

                    if (arrayLinesResid.Length > 1)
                    {
                        secondRes = arrayLinesResid[1].Split('|')[0];
                        if (arrayLinesResid.Length > 2)
                        {
                            thereRes = arrayLinesResid[2].Split('|')[0];
                            if (arrayLinesResid.Length > 3)
                            {
                                fourthRes = arrayLinesResid[3].Split('|')[0];
                            }
                        }
                    }



                    var residTotal = decimal.Parse(firtsRes) + decimal.Parse(secondRes) + decimal.Parse(thereRes) + decimal.Parse(fourthRes);

                    TitleResidualPts.Text = residTotal.ToString("0.00");
                    ResidRama1.Text = firtsRes;
                    ResidRama2.Text = secondRes;
                    ResidRama3.Text = thereRes;


                    FirtsLineR2Icon.CssClass = "range-bag";
                    SecondLineR2Icon.CssClass = "range-bag";
                    ThirdLineR2Icon.CssClass = "range-bag";



                    if (double.Parse(firtsRes) >= minir)
                    {
                        FirtsLineR2Icon.CssClass = "range-ambar";
                        firtsLineP2d = minir;
                    }
                    if (double.Parse(secondRes) >= minir)
                    {
                        SecondLineR2Icon.CssClass = "range-ambar";
                        secondLineP2d = minir;
                    }
                    if (double.Parse(thereRes) >= minir)
                    {
                        ThirdLineR2Icon.CssClass = "range-ambar";
                        thirdLineP2d = mini;
                    }



                    if (double.Parse(firtsRes) >= maxir)
                    {
                        FirtsLineR2Icon.CssClass = "range-good";
                        firtsRes = maxir.ToString();
                    }
                    if (double.Parse(secondRes) >= maxir)
                    {
                        SecondLineR2Icon.CssClass = "range-good";
                        secondRes = maxir.ToString();
                    }
                    if (double.Parse(thereRes) >= maxir)
                    {
                        ThirdLineR2Icon.CssClass = "range-good";
                        thereRes = maxir.ToString();
                    }

                    FirtsLineR2.Text = decimal.Parse(firtsRes).ToString(formartNumber);
                    SecondLineR2.Text = decimal.Parse(secondRes).ToString(formartNumber);
                    ThirdLineR2.Text = decimal.Parse(thereRes).ToString(formartNumber);


                    //ACTUALZIACION DE FECHA PARA MOSTRAR BANNER
                    BrTypeMembership brTypeMembership = new BrTypeMembership();
                    MyConstants mc = new MyConstants();
                    //DateTime ya = DateTime.Now;
                    //var startDate2 = new DateTime(ya.Year, ya.Month, 1);
                    //var veamos = ya.AddHours(+24);
                    var userbanner = arraLogin[2];
                    var FechaActualizacion = brTypeMembership.GetUpdateBanner(userbanner);
                    //var conhoras =brTypeMembership.UpdateNextDay(userbanner);falta sp
                    if (FechaActualizacion == "0")
                    {
                        FechaActualizacion = "2000-12-10";
                    }
                    var vchoras = DateTime.Now.ToString(mc.DateFormatBd); /*DateTime.Parse("2019-05-23")*/
                    if (DateTime.Parse(vchoras) == DateTime.Parse(FechaActualizacion))
                    {
                        //banni.Style.Add("display", "block");
                        modalCara.Style.Add("display", "block");

                    }

                    // Imagen de PErfil
                    var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                    DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                    nombreu = arraLogin[1];
                    foreach (var fi2 in di1.GetFiles())
                    {
                        var archivo = fi2.Name.Split('.');
                        name = archivo[archivo.Length - 2];
                        extension = archivo[archivo.Length - 1];
                        if (name == nombreu) { def = nombreu + "." + extension; }
                    }

                    if (def != "")
                    {
                        imgProfile.ImageUrl = "~/Resources/imguser/" + def;
                        imgProfile.Style.Add("width", "40px");
                        imgProfile.Style.Add("height", "40px");
                        imgProfile.Style.Add("margin", "0 auto");

                        imgProfileFl.ImageUrl = "~/Resources/imguser/" + def;
                        imgProfileFl.Style.Add("width", "80px");
                        imgProfileFl.Style.Add("height", "80px");
                        imgProfileFl.Style.Add("margin", "180 0 auto 154px");
                    }
                    //range = "ORO";
                    var rutaBanner = HttpContext.Current.Server.MapPath("~/Views/ImgHistoryRange/" + userName + range + ".png");

                    if (!File.Exists(rutaBanner))
                    {
                        var infoPerson = brUser.GetPersonalInformation(User.Identity.Name.Split('¬')[1]).Split('|');
                        MyFunctions mf = new MyFunctions();
                        if (range != "SOC")
                        {
                            CreateImageFromString(mf.ToCapitalize(infoPerson[1]), mf.ToCapitalize(infoPerson[2]), def, range, userName);
                        }
                        else
                        {
                            CreateImageFromStringSoc(mf.ToCapitalize(infoPerson[1]), mf.ToCapitalize(infoPerson[2]), def, range, userName);
                        }
                    }

                    if (range == "DIM")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "DIM.png";
                        PtoAzul2.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                        lblUserban.Text = userNameBann;


                    }
                    if (range == "TDI")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "TDI.png";
                        PtoAzul11.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                    }
                    if (range == "DDI")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "DDI.png";
                        PtoAzul10.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                    }
                    if (range == "DAZ")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "DAZ.png";
                        PtoAzul9.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                    }
                    if (range == "DNE")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "DNE.png";
                        PtoAzul8.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                    }
                    if (range == "DIA")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "DIA.png";
                        PtoAzul7.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                    }
                    if (range == "ESM")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "ESM.png";
                        PtoAzul6.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();
                    }
                    if (range == "RUB")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "RUB.png";
                        PtoAzul5.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();


                    }
                    if (range == "ZAF")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "ZAF.png";
                        PtoAzul4.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();


                    }
                    if (range == "ORO")
                    {
                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "ORO.png";
                        PtoAzul3.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                    }
                    if (range == "PLT")
                    {

                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "PLT.png";

                        PtoAzul2.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                    }
                    if (range == "SOC")
                    {

                        BannerHistoryRange.ImageUrl = "~/Resources/ImgHistoryRange/" + userName + "SOC.png";
                        PtoAzul1.Style.Add("background-color", "#0f8cfb");
                        namerange.Text = arrayrange[2].ToString();

                    }


                    // SendEmailAmountRestante("170.84", "113.91", "284.75", "3345", "Cuota nro: 1");

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void NewsView_Click(object sender, EventArgs e)
        {
            globo2.Style.Add("display", "none");
            Response.Redirect("News.aspx");
        }


        #region MyRegion
        public void SendEmailAmountRestante(string amountRestn, string amountWalllet, string amountTotal, string idMembershipDetail, string description)
        {
            string currencyCode = "PEN";

            if (Session["TypeCurrency"] != null)
            {
                currencyCode = Session["TypeCurrency"].ToString();
            }


            MyConstants mc = new MyConstants();
            MyFunctions mf = new MyFunctions();
            var bankAccount = mc.BankAccount;

            //1|Omar Fernando|Urteaga Cabrera|14/01/1983|M|omarurteaga@gmail.com|938627011||Peru|Lima|Lima|addres|DNI|41958311|1|admin987|Solter(a)
            BrUser brPerson = new BrUser();
            var arrayperson = brPerson.GetPersonalInformation(User.Identity.Name.Split('¬')[1]).Split('|');

            var correo = arrayperson[5];
            var nombre = arrayperson[1] + " " + arrayperson[2];
            var dni = arrayperson[13];
            var username = arrayperson[1].Substring(0, 1).ToUpper() + arrayperson[2].Substring(0, 1).ToUpper() + dni;
            string fullname = arrayperson[1].Trim().ToLower() + " " + arrayperson[2].Trim().ToLower();
            fullname = mf.ToCapitalize(fullname);
            string[] sepName = arrayperson[1].Split(' ');
            var fName = mf.ToCapitalize(sepName[0]);

            var bienvenido = "Estimado";
            if (arrayperson[4] == "F")
            {
                bienvenido = "Estimada";
            }
            var cuerpo = "<html><head><title></title></head><body style='color:black'>";
            cuerpo += "<div style='width: 100%'>";
            cuerpo += "<div style='display:flex;'>";
            cuerpo += "<div style='width:50%;'>";
            cuerpo += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            cuerpo += "</div>";
            cuerpo += "<div style='width:50%;'>";
            cuerpo += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            cuerpo += "</div>";
            cuerpo += "</div>";
            cuerpo += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            cuerpo += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>" + bienvenido + " " + fName + "</h1>";
            cuerpo += "<h2 style='text-align: center;'>Aqui te detallamos el pago de tu Cuota. Estamos a la espera de que nos brindes tu comprobante de pago</h2>";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Detalle de Pago</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Wallet : S/ " + amountWalllet + "</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Deposito : S/ " + amountRestn + "</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>========================================</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Total : S/ " + amountTotal + "</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Cuando lo tengas listo, solo tienes que subirlo a nuestra pagina y enseguida lo estaremos validando</p></center> ";
            cuerpo += "";
            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
            cuerpo += "<a style='text-decoration: none;' href='https://inresorts.club/Views/Login.aspx?usuario=" + dni + "&fullname=" + fullname + "&cod=" + idMembershipDetail + "&description=" + description + "'>";
            cuerpo += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
            cuerpo += "</a></div></center>";

            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '></p>";
            cuerpo += "<center>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente atravez de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</center>";
            cuerpo += "</div></center>";


            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Cuenta Bancaria </p>";
            cuerpo += $"<center>BCP: N° {bankAccount} - Valle Encantado S.A.C</center>";
            cuerpo += "</div></center>";

            cuerpo += "<center><div style='width: 50%;display: flex;border-radius: 10px;margin: 11px;'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%;'>Monto a depositar</p>";

            cuerpo += "<center style=' margin: 12px;'> S/." + amountRestn + " (" + currencyCode + ")</center>";
            cuerpo += "</div></center>";

            //cuerpo += "<center><img src='http://www.inresorts.club/Views/img/recibo.png' align='left' style='width: 100%'></center></div>";
            cuerpo += "<div style='margin-left: 9%;'>";
            cuerpo += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            cuerpo += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            cuerpo += "</div>";

            cuerpo += "</body>";
            cuerpo += "</html>";

            Email email = new Email();
            email.SubmitEmail(correo, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

            string correoOamr = "omarurteaga@gmail.com";
            //string correoOamr = "samirpazo08@gmail.com";

            email.SubmitEmail(correoOamr, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);
            Session.Contents.RemoveAll();
        }
        #endregion

        public void CreateImageFromString(string name, string lastName, string photoPerfil, string rango, string userName)
        {

            //create new image
            Bitmap bitmap = new Bitmap(1, 1);
            //Properties string to draw
            Font font = new Font("sans-serif", 30, FontStyle.Bold, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            //properties new image
            //int width = (int)graphics.MeasureString(text, font).Width;
            //int height = (int)graphics.MeasureString(text, font).Height;
            int width = 685;
            int height = 820;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            //add text to image
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            //graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.TextRenderingHint = TextRenderingHint.AntiAlias;


            /*begin*/
            string rutaper = HttpContext.Current.Server.MapPath("~/Resources/imguser/" + photoPerfil);
            Image perfil = Image.FromFile(rutaper);


            //graphics.DrawEllipse(Pens.Red, new Rectangle(tempPoint, tempSize));
            //graphics.DrawImage(perfil, 120, 250,);
            //graphics.DrawImage(perfil,new PointF(120,250));
            graphics.DrawImage(perfil, 210, 248, 270, 280);
            /*end*/

            /*begin*/
            string rutafond = HttpContext.Current.Server.MapPath("~/Views/img/fondo" + rango + ".png");
            Image fondo = Image.FromFile(rutafond);
            graphics.DrawImage(fondo, 0, 0);
            /*end*/
            /*begin*/
            Color colorLeter = ColorTranslator.FromHtml("#114489");
            float widthName = graphics.MeasureString(name, font).Width;
            float widthlastName = graphics.MeasureString(lastName, font).Width;
            //120
            graphics.DrawString(name, font, new SolidBrush(colorLeter), ejex(width - 70, widthName), 670);
            graphics.DrawString(lastName, font, new SolidBrush(colorLeter), ejex(width - 70, widthlastName), 710);
            /*end*/

            //execute pending graphics
            graphics.Flush();
            //release resources used by graphics
            graphics.Dispose();
            //save the image 
            string rutaImg = HttpContext.Current.Server.MapPath("~/Resources/ImgHistoryRange/" + userName + rango + ".png");
            bitmap.Save(rutaImg, System.Drawing.Imaging.ImageFormat.Png);

            //do something with image

        }

        public void CreateImageFromStringSoc(string name, string lastName, string photoPerfil, string rango, string userName)
        {

            //create new image
            Bitmap bitmap = new Bitmap(1, 1);
            //Properties string to draw
            Font font = new Font("sans-serif", 30, FontStyle.Bold, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            //properties new image
            //int width = (int)graphics.MeasureString(text, font).Width;
            //int height = (int)graphics.MeasureString(text, font).Height;
            int width = 515;
            int height = 625;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            //add text to image
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            //graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.TextRenderingHint = TextRenderingHint.AntiAlias;


            /*begin*/
            string rutaper = HttpContext.Current.Server.MapPath("~/Resources/imguser/" + photoPerfil);
            Image perfil = Image.FromFile(rutaper);


            //graphics.DrawEllipse(Pens.Red, new Rectangle(tempPoint, tempSize));
            //graphics.DrawImage(perfil, 120, 250,);
            //graphics.DrawImage(perfil,new PointF(120,250));
            graphics.DrawImage(perfil, 170, 159, 187, 185);
            /*end*/

            /*begin*/
            string rutafond = HttpContext.Current.Server.MapPath("~/Views/img/fondo" + rango + ".png");
            Image fondo = Image.FromFile(rutafond);
            graphics.DrawImage(fondo, 0, 0);
            /*end*/
            /*begin*/
            Color colorLeter = ColorTranslator.FromHtml("#114489");
            float widthName = graphics.MeasureString(name, font).Width;
            float widthlastName = graphics.MeasureString(lastName, font).Width;
            graphics.DrawString(name, font, new SolidBrush(colorLeter), ejex(width, widthName), 520);
            graphics.DrawString(lastName, font, new SolidBrush(colorLeter), ejex(width, widthlastName), 560);
            /*end*/

            //execute pending graphics
            graphics.Flush();
            //release resources used by graphics
            graphics.Dispose();
            //save the image 
            string rutaImg = HttpContext.Current.Server.MapPath("~/Resources/ImgHistoryRange/" + userName + rango + ".png");
            bitmap.Save(rutaImg, System.Drawing.Imaging.ImageFormat.Png);

            //do something with image

        }

        private float ejex(int total, float ancho)
        {
            float _total = float.Parse(total.ToString());


            return ((total / 2) - (ancho / 2));
        }

    }
}