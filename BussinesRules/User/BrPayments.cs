
namespace BussinesRules.User
{
    using DataAccess;
    using DataAccess.User;
    using Entities;
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class BrPayments : brConnection
    {
        beFeesPayDetail obeFees;
        StringBuilder sb;
        beParameters obeParameters;
        /*QuotePayment***********************************************************************/
        public double CalculateMonthlyRate(double annualRate)//interes
        {
            double answer = 0d;
            double tasaAnualPorcentual = 0d;
            tasaAnualPorcentual = annualRate / 100;
            answer = ((Math.Pow(1.0 + tasaAnualPorcentual, 1.0 / 12.0)) - 1);
            return answer;
        }

        public bool QuoteRefuse(int idMembershipDetail, string userName)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlTransaction sqlTransaction;
                    sqlTransaction = connection.BeginTransaction();
                    DaPayments odaPayments = new DaPayments();

                    try
                    {
                        answer = odaPayments.QuoteRefuse(connection, sqlTransaction, idMembershipDetail);

                        if (answer)
                        {
                            answer = odaPayments.DisposePay(connection, sqlTransaction, idMembershipDetail, userName);
                        }

                        if (answer)
                        {
                            sqlTransaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            sqlTransaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            string error = $"{ex.Message}|{ex2.Message}";
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetListPayments(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.GetListPayments(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public double CalculeMonthlyQuote(double amountFinanced, int quotes, double rateMonth)//cuota ()
        {
            double answer = 0d;
            double d = amountFinanced * (rateMonth);
            double dv = 1.0 - (Math.Pow(1.0 + (rateMonth), -quotes));
            if (d == 0)
            {
                answer = 0.001;
            }
            else
            {
                answer = d / dv;
            }

            return answer;
        }
        public double CalculateFinancingPercentage(double initialFee, double capitalBalance)
        {
            double r = 0;
            r = 100 - ((initialFee * 100) / capitalBalance);
            return r;
        }

        public bool GetCalculatePaymentSchedule(string data, string username, Int32 data2, string exchange, int data4) //"knava|empty^6000|3.3|empty|empty|24|10/16/2018|50|10|1|empty^10/16/2018|50 vs  |CLB^3000|3.2|VE034|VE035|24|2018-10-10|1000|10|1|obs^2018-10-11|1000~nombres|apellidos|1|73680066|963258741$2018-10-12"
        {
            sb = new StringBuilder();
            obeFees = new beFeesPayDetail();

            obeParameters = new beParameters();

            MyConstants mc = new MyConstants();

            // odaContract = new daContract();
            double countInterest = 0.0d;
            double countQuote = 0.0d;
            string answer = "";
            var listParametersPre = data.Split('$');
            var dateQuotesStart = listParametersPre[1];
            var listParameters = listParametersPre[0].Split('~');
            var dataPerson = listParameters[1].Split('|');
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {

                    data = listParameters[0];  //"knava|empty^6000|3.3|empty|empty|24|16-10-2018|50|10|1|empty^16-10-2018|50"
                    string[] list = data.Split(obeParameters.sombrerito);
                    var flag = 0;
                    //"11|CLB^
                    string SendData = list[0].ToString();
                    //2500 |3.26|VE004|VE005|24|2018-07-25|1000|10|2|pruebita^
                    string[] lCalculationData = list[1].Split(obeParameters.palote);
                    obeFees.AmountUSD = Math.Round(Convert.ToDouble(lCalculationData[0]), 2);
                    obeFees.ExchangeRate = Math.Round(Convert.ToDouble(lCalculationData[1]), 5);
                    // obeFees.IdEmployeeLiner = "EMPTY";
                    //   obeFees.IdEmployeeCloser = "EMPTY";
                    obeFees.NumberQuoteOfPay = Convert.ToInt32(lCalculationData[4]);
                    obeFees.DateQuoteStart = Convert.ToDateTime(dateQuotesStart);
                    obeFees.InitialFeeAmount = Math.Round(Convert.ToDouble(lCalculationData[6]), 2);
                    //cuotasDeLaPrimeraCuota
                    obeFees.AnualEffectiveRate = Convert.ToInt32(lCalculationData[7]);
                    obeFees.NumberOfInitialOfPay = Convert.ToInt32(lCalculationData[8]);
                    obeFees.Obs = lCalculationData[9];
                    //2018-07-25|2018-07-26"
                    string[] lInitialDate = list[2].Split(obeParameters.palote);

                    obeFees.CapitalBalance = obeFees.AmountUSD * obeFees.ExchangeRate;

                    obeFees.AmountPEN = obeFees.AmountUSD * obeFees.ExchangeRate;
                    obeFees.Amortization = obeFees.InitialFeeAmount / obeFees.NumberOfInitialOfPay;
                    obeFees.MonthlyRate = CalculateMonthlyRate(obeFees.AnualEffectiveRate);
                    obeFees.FinancingPercentage = Math.Round(100 - ((obeFees.InitialFeeAmount * 100) / obeFees.CapitalBalance), 2);

                    obeFees.FinancedAmount = obeFees.AmountPEN - obeFees.InitialFeeAmount;

                    sb.Append(obeFees.AmountPEN);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.FinancedAmount);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.TotalAmountOfInterest); //detalle
                    sb.Append(obeParameters.palote);
                    sb.Append(DateTime.Now.ToString(mc.DateFormatBd));
                    sb.Append(obeParameters.codito);
                    sb.Append(obeFees.FinancingPercentage); //cortar
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.NumberQuoteOfPay);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.AnualEffectiveRate);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.periodicity);
                    sb.Append(obeParameters.sombrerito);
                    for (int f = 0; f < obeFees.NumberOfInitialOfPay; f++) //modificacionParaMontosEditables
                    {
                        sb.Append("Inicial nro: " + Convert.ToString(f + 1));
                        sb.Append(obeParameters.palote);
                        if (f == 0) sb.Append(Convert.ToDateTime(lInitialDate[f]).ToString(mc.DateFormatBd));
                        if (f == 1) sb.Append(Convert.ToDateTime(lInitialDate[f + 1]).ToString(mc.DateFormatBd));
                        if (f == 2) sb.Append(Convert.ToDateTime(lInitialDate[f + 2]).ToString(mc.DateFormatBd));
                        if (f == 3) sb.Append(Convert.ToDateTime(lInitialDate[f + 3]).ToString(mc.DateFormatBd));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.CapitalBalance, 2)));
                        sb.Append(obeParameters.palote);
                        if (f == 0) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 1]).ToString())));//primeraCuota
                        if (f == 1) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 2]).ToString())));//primeraCuota
                        if (f == 2) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 3]).ToString())));//primeraCuota
                        if (f == 3) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 4]).ToString())));//primeraCuota
                        sb.Append(obeParameters.palote);
                        //  countQuote += Math.Round(obeFees.Quote + obeFees.Amortization);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.interestingInitial, 2)));
                        sb.Append(obeParameters.palote);
                        // sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Amortization,2)));
                        if (f == 0) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 1]).ToString())));//primeraCuota
                        if (f == 1) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 2]).ToString())));//primeraCuota
                        if (f == 2) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 3]).ToString())));//primeraCuota
                        if (f == 3) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 4]).ToString())));//primeraCuota
                        sb.Append(obeParameters.codito);
                        if (f == 0) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 1]);
                        if (f == 1) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 2]);
                        if (f == 2) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 3]);
                        if (f == 3) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 4]);
                        flag++;
                    }
                    if (obeFees.MonthlyRate != 0) obeFees.Quote = CalculeMonthlyQuote(obeFees.CapitalBalance, obeFees.NumberQuoteOfPay, obeFees.MonthlyRate); //cortar
                    else obeFees.Quote = obeFees.CapitalBalance / obeFees.NumberQuoteOfPay;
                    for (int f = 0; f < obeFees.NumberQuoteOfPay; f++)
                    {
                        obeFees.Interests = obeFees.CapitalBalance * obeFees.MonthlyRate; //cortar
                        obeFees.Amortization = obeFees.Quote - obeFees.Interests; //cortar
                        sb.Append("Cuota nro: " + Convert.ToString(f + 1));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeFees.DateQuoteStart.Date.AddMonths(f).ToString(mc.DateFormatBd)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.CapitalBalance, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Amortization, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Interests, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Quote, 2)));
                        sb.Append(obeParameters.codito);
                        obeFees.CapitalBalance = Math.Round(obeFees.CapitalBalance - obeFees.Amortization, 2);
                        countQuote += obeFees.Quote;
                        if (f == obeFees.NumberQuoteOfPay) countQuote += obeFees.Quote; //totalCuotas=totalApagar
                        if (f == 0) countInterest += Math.Round(obeFees.Interests, 2);
                        obeFees.Interests = Math.Round(obeFees.CapitalBalance * obeFees.MonthlyRate, 2);
                        if (f == 0) countInterest += Math.Round(obeFees.Interests, 2);
                        if (f != 0) countInterest += Math.Round(obeFees.Interests, 2);

                        if (f >= obeFees.NumberQuoteOfPay - 1)
                        {
                            sb.Append(obeParameters.gruna);
                            sb.Append(Math.Round(countInterest, 2));//totalDeInteres
                            sb.Append(obeParameters.gruna);
                            sb.Append(Math.Round(countQuote, 2));//totalDeInteres
                        }
                    }
                    sb = sb.Remove(sb.Length - 1, 1);  //{knava|1|lastmname|8888|999|999¬19800|19750|0|10/16/2018¬99.75|24|10|Mensual^Inicial nro: 1|10/16/2018|S/. 19800|S/. 50|S/. 0|S/. 50¬Cuota nro: 1|10/16/2018|S/. 19750|S/. 749.95|S/. 157.49|S/. 907.44¬Cuota nro: 2|11/16/2018|S/. 19000.05|S/. 755.93|S/. 151.51|S/. 907.44¬Cuota nro: 3|12/16/2018|S/. 18244.12|S/. 761.96|S/. 145.48|S/. 907.44¬Cuota nro: 4|1/16/2019|S/. 17482.16|S/. 768.03|S/. 139.41|S/. 907.44¬Cuota nro: 5|2/16/2019|S/. 16714.13|S/. 774.16|S/. 133.28|S/. 907.44¬Cuota nro: 6|3/16/2019|S/. 15939.97|S/. 780.33|S/. 127.11|S/. 907.44¬Cuota nro: 7|4/16/2019|S/. 15159.64|S/. 786.55|S/. 120.89|S/. 907.44¬Cuota nro: 8|5/16/2019|S/. 14373.09|S/. 792.83|S/. 114.61|S/. 907.44¬Cuota nro: 9|6/16/2019|S/. 13580.26|S/. 799.15|S/. 108.29|S/. 907.44¬Cuota nro: 10|7/16/2019|S/. 12781.11|S/. 805.52|S/. 101.92|S/. 907.44¬Cuota nro: 11|8/16/2019|S/. 11975.59|S/. 811.94|S/. 95.5|S/. 907.44¬Cuota nro: 12|9/16/2019|S/. 11163.65|S/. 818.42|S/. 89.02|S/. 907.44¬Cuota nro: 13|10/16/2019|S/. 10345.23|S/. 824.94|S/. 82.49|S/. 907.44¬Cuota nro: 14|11/16/2019|S/. 9520.29|S/. 831.52|S/. 75.92|S/. 907.44¬Cuota nro: 15|12/16/2019|S/. 8688.77|S/. 838.15|S/. 69.29|S/. 907.44¬Cuota nro: 16|1/16/2020|S/. 7850.62|S/. 844.84|S/. 62.6|S/. 907.44¬Cuota nro: 17|2/16/2020|S/. 7005.78|S/. 851.57|S/. 55.87|S/. 907.44¬Cuota nro: 18|3/16/2020|S/. 6154.21|S/. 858.36|S/. 49.07|S/. 907.44¬Cuota nro: 19|4/16/2020|S/. 5295.85|S/. 865.21|S/. 42.23|S/. 907.44¬Cuota nro: 20|5/16/2020|S/. 4430.64|S/. 872.11|S/. 35.33|S/. 907.44¬Cuota nro: 21|6/16/2020|S/. 3558.53|S/. 879.06|S/. 28.38|S/. 907.44¬Cuota nro: 22|7/16/2020|S/. 2679.47|S/. 886.07|S/. 21.37|S/. 907.44¬Cuota nro: 23|8/16/2020|S/. 1793.4|S/. 893.14|S/. 14.3|S/. 907.44¬Cuota nro: 24|9/16/2020|S/. 900.26|S/. 900.26|S/. 7.18|S/. 907.44¬~2028.54~21778.52}
                    var auxStr = sb.ToString();
                    var auxStr2 = auxStr.Split('^');
                    var auxStr3 = auxStr2[1];
                    var auxStr4 = auxStr3.Split('~');
                    var auxStr5 = auxStr4[0];
                    auxStr5 = auxStr5.Remove(auxStr5.Length - 1);
                    auxStr5 = auxStr5 + '$' + username;
                    cn.Open();
                    DaPayments daPayments = new DaPayments();

                    return daPayments.putPayment(cn, auxStr5, data2, exchange, data4);
                }
                catch (Exception ex)
                {
                    DaTesteo daTesteo = new DaTesteo();
                    var ans = daTesteo.Put(cn, ex.Message + "¬samir");
                    return false;
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public bool PutDateUpgrate(int ansNmembershi, string date)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.PutDateUpgrate(connection, ansNmembershi, date);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetCalculatePaymentScheduleString(string data, string username, string quoteInitials, string flag2, bool notInteres) //"knava|empty^6000|3.3|empty|empty|24|10/16/2018|50|10|1|empty^10/16/2018|50 vs  |CLB^3000|3.2|VE034|VE035|24|2018-10-10|1000|10|1|obs^2018-10-11|1000~nombres|apellidos|1|73680066|963258741$2018-10-12"
        {
            sb = new StringBuilder();
            obeFees = new beFeesPayDetail();
            //data="168 | LHT ^ 4210 | 3.25 | empty | empty | 48 | 2018 - 12 - 02 | 1397.5 | 10 | 1 | empty ^ 2018 - 11 - 02 | 682.52018 - 11 - 02 | 682.5"
            if (flag2 == "1")
            {
                data = "168|LHT  ^2110|3.25|empty|empty|24|2018-11-02|715|10|1|empty^2018-11-02|715|2018-12-02|800|2018-01-02|1000~fgjhfgbfb|fgbfb|178745896|78745896$2018-11-01";
            }
            //data = "168|LHT  ^2110|3.25|empty|empty|24|2018-11-02|715|10|1|empty^2018-11-02|715|2018-12-02|800|2018-01-02|1000~fgjhfgbfb|fgbfb|178745896|78745896$2018-11-01";
            obeParameters = new beParameters();
            // odaContract = new daContract();
            double countInterest = 0.0d;
            double countQuote = 0.0d;
            string answer = "";
            var listParametersPre = data.Split('$');
            var dateQuotesStart = listParametersPre[1];
            var listParameters = listParametersPre[0].Split('~');
            var dataPerson = listParameters[1].Split('|');
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    data = listParameters[0];  //"knava|empty^6000|3.3|empty|empty|24|16-10-2018|50|10|1|empty^16-10-2018|50"
                    string[] list = data.Split(obeParameters.sombrerito);
                    var flag = 0;
                    //"11|CLB^
                    string SendData = list[0].ToString();
                    //2500 |3.26|VE004|VE005|24|2018-07-25|1000|10|2|pruebita^
                    string[] lCalculationData = list[1].Split(obeParameters.palote);
                    obeFees.AmountUSD = Math.Round(Convert.ToDouble(lCalculationData[0]), 2);
                    obeFees.ExchangeRate = Math.Round(Convert.ToDouble(lCalculationData[1]), 5);
                    // obeFees.IdEmployeeLiner = "EMPTY";
                    //   obeFees.IdEmployeeCloser = "EMPTY";
                    obeFees.NumberQuoteOfPay = Convert.ToInt32(lCalculationData[4]);

                    obeFees.DateQuoteStart = Convert.ToDateTime(dateQuotesStart);
                    obeFees.InitialFeeAmount = Math.Round(Convert.ToDouble(lCalculationData[6]), 2);
                    //cuotasDeLaPrimeraCuota
                    obeFees.AnualEffectiveRate = Convert.ToInt32(lCalculationData[7]);
                    //obeFees.NumberOfInitialOfPay = Convert.ToInt32(lCalculationData[8]);
                    obeFees.NumberOfInitialOfPay = Convert.ToInt32(quoteInitials);
                    // obeFees.NumberOfInitialOfPay = Convert.ToInt32(lCalculationData[8]);
                    obeFees.Obs = lCalculationData[9];
                    //2018-07-25|2018-07-26"
                    string[] lInitialDate = list[2].Split(obeParameters.palote);
                    obeFees.CapitalBalance = obeFees.AmountUSD * obeFees.ExchangeRate;
                    obeFees.AmountPEN = obeFees.AmountUSD * obeFees.ExchangeRate;
                    obeFees.Amortization = obeFees.InitialFeeAmount / obeFees.NumberOfInitialOfPay;
                    obeFees.MonthlyRate = CalculateMonthlyRate(obeFees.AnualEffectiveRate);
                    obeFees.FinancingPercentage = Math.Round(100 - ((obeFees.InitialFeeAmount * 100) / obeFees.CapitalBalance), 2);
                    obeFees.FinancedAmount = obeFees.AmountPEN - obeFees.InitialFeeAmount;
                    sb.Append(obeFees.AmountPEN);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.FinancedAmount);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.TotalAmountOfInterest); //detalle
                    sb.Append(obeParameters.palote);
                    sb.Append(DateTime.Now.ToShortDateString());
                    sb.Append(obeParameters.codito);
                    sb.Append(obeFees.FinancingPercentage); //cortar
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.NumberQuoteOfPay);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.AnualEffectiveRate);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.periodicity);
                    sb.Append(obeParameters.sombrerito);
                    for (int f = 0; f < obeFees.NumberOfInitialOfPay; f++) //modificacionParaMontosEditables
                    {
                        sb.Append("Inicial nro: " + Convert.ToString(f + 1));
                        sb.Append(obeParameters.palote);
                        if (f == 0) sb.Append(Convert.ToDateTime(lInitialDate[f]).ToShortDateString());
                        if (f == 1) sb.Append(Convert.ToDateTime(lInitialDate[f + 1]).ToShortDateString());
                        if (f == 2) sb.Append(Convert.ToDateTime(lInitialDate[f + 2]).ToShortDateString());
                        if (f == 3) sb.Append(Convert.ToDateTime(lInitialDate[f + 3]).ToShortDateString());
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.CapitalBalance, 2)));
                        sb.Append(obeParameters.palote);
                        if (f == 0) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 1]).ToString())));//primeraCuota
                        if (f == 1) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 2]).ToString())));//primeraCuota
                        if (f == 2) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 3]).ToString())));//primeraCuota
                        if (f == 3) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 4]).ToString())));//primeraCuota
                        sb.Append(obeParameters.palote);
                        //  countQuote += Math.Round(obeFees.Quote + obeFees.Amortization);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.interestingInitial, 2)));
                        sb.Append(obeParameters.palote);
                        // sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Amortization,2)));
                        if (f == 0) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 1]).ToString())));//primeraCuota
                        if (f == 1) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 2]).ToString())));//primeraCuota
                        if (f == 2) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 3]).ToString())));//primeraCuota
                        if (f == 3) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 4]).ToString())));//primeraCuota
                        sb.Append(obeParameters.codito);
                        if (f == 0) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 1]);
                        if (f == 1) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 2]);
                        if (f == 2) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 3]);
                        if (f == 3) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 4]);
                        flag++;
                    }
                    if (obeFees.MonthlyRate != 0) obeFees.Quote = CalculeMonthlyQuote(obeFees.CapitalBalance, obeFees.NumberQuoteOfPay, obeFees.MonthlyRate); //cortar
                    else obeFees.Quote = obeFees.CapitalBalance / obeFees.NumberQuoteOfPay;
                    if (notInteres)
                    {
                        obeFees.Quote = obeFees.CapitalBalance / obeFees.NumberQuoteOfPay;
                    }

                    for (int f = 0; f < obeFees.NumberQuoteOfPay; f++)
                    {
                        obeFees.Interests = obeFees.CapitalBalance * obeFees.MonthlyRate; //cortar
                        if (notInteres)
                        {
                            obeFees.Interests = 0; //cortar
                        }

                        obeFees.Amortization = obeFees.Quote - obeFees.Interests; //cortar
                        sb.Append("Cuota nro: " + Convert.ToString(f + 1));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeFees.DateQuoteStart.Date.AddMonths(f).ToShortDateString()));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.CapitalBalance, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Amortization, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Interests, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Quote, 2)));
                        sb.Append(obeParameters.codito);
                        obeFees.CapitalBalance = Math.Round(obeFees.CapitalBalance - obeFees.Amortization, 2);
                        countQuote += obeFees.Quote;
                        if (f == obeFees.NumberQuoteOfPay) countQuote += obeFees.Quote; //totalCuotas=totalApagar
                        if (f == 0) countInterest += Math.Round(obeFees.Interests, 2);
                        obeFees.Interests = Math.Round(obeFees.CapitalBalance * obeFees.MonthlyRate, 2);
                        if (f == 0) countInterest += Math.Round(obeFees.Interests, 2);
                        if (f != 0) countInterest += Math.Round(obeFees.Interests, 2);

                        if (f >= obeFees.NumberQuoteOfPay - 1)
                        {
                            sb.Append(obeParameters.gruna);
                            sb.Append(Math.Round(countInterest, 2));//totalDeInteres
                            sb.Append(obeParameters.gruna);
                            sb.Append(Math.Round(countQuote, 2));//totalDeInteres
                        }
                    }
                    sb = sb.Remove(sb.Length - 1, 1);  //{knava|1|lastmname|8888|999|999¬19800|19750|0|10/16/2018¬99.75|24|10|Mensual^Inicial nro: 1|10/16/2018|S/. 19800|S/. 50|S/. 0|S/. 50¬Cuota nro: 1|10/16/2018|S/. 19750|S/. 749.95|S/. 157.49|S/. 907.44¬Cuota nro: 2|11/16/2018|S/. 19000.05|S/. 755.93|S/. 151.51|S/. 907.44¬Cuota nro: 3|12/16/2018|S/. 18244.12|S/. 761.96|S/. 145.48|S/. 907.44¬Cuota nro: 4|1/16/2019|S/. 17482.16|S/. 768.03|S/. 139.41|S/. 907.44¬Cuota nro: 5|2/16/2019|S/. 16714.13|S/. 774.16|S/. 133.28|S/. 907.44¬Cuota nro: 6|3/16/2019|S/. 15939.97|S/. 780.33|S/. 127.11|S/. 907.44¬Cuota nro: 7|4/16/2019|S/. 15159.64|S/. 786.55|S/. 120.89|S/. 907.44¬Cuota nro: 8|5/16/2019|S/. 14373.09|S/. 792.83|S/. 114.61|S/. 907.44¬Cuota nro: 9|6/16/2019|S/. 13580.26|S/. 799.15|S/. 108.29|S/. 907.44¬Cuota nro: 10|7/16/2019|S/. 12781.11|S/. 805.52|S/. 101.92|S/. 907.44¬Cuota nro: 11|8/16/2019|S/. 11975.59|S/. 811.94|S/. 95.5|S/. 907.44¬Cuota nro: 12|9/16/2019|S/. 11163.65|S/. 818.42|S/. 89.02|S/. 907.44¬Cuota nro: 13|10/16/2019|S/. 10345.23|S/. 824.94|S/. 82.49|S/. 907.44¬Cuota nro: 14|11/16/2019|S/. 9520.29|S/. 831.52|S/. 75.92|S/. 907.44¬Cuota nro: 15|12/16/2019|S/. 8688.77|S/. 838.15|S/. 69.29|S/. 907.44¬Cuota nro: 16|1/16/2020|S/. 7850.62|S/. 844.84|S/. 62.6|S/. 907.44¬Cuota nro: 17|2/16/2020|S/. 7005.78|S/. 851.57|S/. 55.87|S/. 907.44¬Cuota nro: 18|3/16/2020|S/. 6154.21|S/. 858.36|S/. 49.07|S/. 907.44¬Cuota nro: 19|4/16/2020|S/. 5295.85|S/. 865.21|S/. 42.23|S/. 907.44¬Cuota nro: 20|5/16/2020|S/. 4430.64|S/. 872.11|S/. 35.33|S/. 907.44¬Cuota nro: 21|6/16/2020|S/. 3558.53|S/. 879.06|S/. 28.38|S/. 907.44¬Cuota nro: 22|7/16/2020|S/. 2679.47|S/. 886.07|S/. 21.37|S/. 907.44¬Cuota nro: 23|8/16/2020|S/. 1793.4|S/. 893.14|S/. 14.3|S/. 907.44¬Cuota nro: 24|9/16/2020|S/. 900.26|S/. 900.26|S/. 7.18|S/. 907.44¬~2028.54~21778.52}
                    var auxStr = sb.ToString();
                    var auxStr2 = auxStr.Split('^');
                    var auxStr3 = auxStr2[1];
                    var auxStr4 = auxStr3.Split('~');
                    var auxStr5 = auxStr4[0];
                    auxStr5 = auxStr5.Remove(auxStr5.Length - 1);
                    auxStr5 = auxStr5 + '$' + username;
                    cn.Open();
                    DaPayments daPayments = new DaPayments();

                    //return daPayments.putPayment(cn, auxStr5);
                    return sb.ToString();
                }
                catch (Exception e)
                {
                    //RecordLog(e.Message, e.StackTrace);
                    return "false";
                }
                finally
                {
                    cn.Close();
                }
            }
        }





        public string GetAmountTotal(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.GetAmountTotal(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetComissionUsers()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.GetComissionUsers(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string PersonGetData(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.PersonGetData(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetListPayDefault()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.GetListPayDefault(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getFatherData(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.getFatherData(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getPayDetailByPerson(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.getPayDetailByPerson(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        /************************************************************************************/
        public string getMysPayments(string name)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.getCommissions(connection, name);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public string GetDataQuote(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.GetDataQuote(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool InitialExoneration(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.InitialExoneration(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool UpdateComissionStatus(int data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.UpdateComissionStatus(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public bool PayComissions(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.PayComissions(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public bool UploadReceipt(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.UploadReceipt(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool UploadReceiptUpgradeCerooInitial(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.UploadReceiptUpgradeCerooInitial(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetPointsGeneral(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.GetPointsGeneral(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool UploadReceiptCalendar(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    answer = odaPayments.UploadReceiptCalendar(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool Amortization(int TypePay, string IdMembershipDetail, int nQuotes, decimal value2, int Rate, string photo)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayment = new DaPayments();
                    answer = odaPayment.Amortization(connection, TypePay, IdMembershipDetail, nQuotes, value2, Rate, photo);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public string PayQuoteMembership(string data, string data2, string nameTick)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaPayments odaPayments = new DaPayments();
                    // string value = data2;
                    answer = odaPayments.PayQuoteMembership(connection, data, data2, nameTick);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public bool GetCalculatePaymentScheduleUpgrate(string data, string username, Int32 data2, string exchange, int data4) //"knava|empty^6000|3.3|empty|empty|24|10/16/2018|50|10|1|empty^10/16/2018|50 vs  |CLB^3000|3.2|VE034|VE035|24|2018-10-10|1000|10|1|obs^2018-10-11|1000~nombres|apellidos|1|73680066|963258741$2018-10-12"
        {
            sb = new StringBuilder();
            obeFees = new beFeesPayDetail();

            obeParameters = new beParameters();
            MyConstants mc = new MyConstants();
            // odaContract = new daContract();
            double countInterest = 0.0d;
            double countQuote = 0.0d;
            string answer = "";
            var listParametersPre = data.Split('$');
            var dateQuotesStart = listParametersPre[1];
            var listParameters = listParametersPre[0].Split('~');
            var dataPerson = listParameters[1].Split('|');
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {

                    data = listParameters[0];  //"knava|empty^6000|3.3|empty|empty|24|16-10-2018|50|10|1|empty^16-10-2018|50"
                    string[] list = data.Split(obeParameters.sombrerito);
                    var flag = 0;
                    //"11|CLB^
                    string SendData = list[0].ToString();
                    //2500 |3.26|VE004|VE005|24|2018-07-25|1000|10|2|pruebita^
                    string[] lCalculationData = list[1].Split(obeParameters.palote);
                    obeFees.AmountUSD = Math.Round(Convert.ToDouble(lCalculationData[0]), 2);
                    obeFees.ExchangeRate = Math.Round(Convert.ToDouble(lCalculationData[1]), 5);
                    // obeFees.IdEmployeeLiner = "EMPTY";
                    //   obeFees.IdEmployeeCloser = "EMPTY";
                    obeFees.NumberQuoteOfPay = Convert.ToInt32(lCalculationData[4]);
                    obeFees.DateQuoteStart = Convert.ToDateTime(dateQuotesStart);
                    obeFees.InitialFeeAmount = Math.Round(Convert.ToDouble(lCalculationData[6]), 2);
                    //cuotasDeLaPrimeraCuota
                    obeFees.AnualEffectiveRate = Convert.ToInt32(lCalculationData[7]);
                    obeFees.NumberOfInitialOfPay = Convert.ToInt32(lCalculationData[8]);
                    obeFees.Obs = lCalculationData[9];
                    //2018-07-25|2018-07-26"
                    string[] lInitialDate = list[2].Split(obeParameters.palote);
                    obeFees.CapitalBalance = obeFees.AmountUSD * obeFees.ExchangeRate;
                    obeFees.AmountPEN = obeFees.AmountUSD * obeFees.ExchangeRate;
                    obeFees.Amortization = obeFees.InitialFeeAmount / obeFees.NumberOfInitialOfPay;
                    obeFees.MonthlyRate = CalculateMonthlyRate(obeFees.AnualEffectiveRate);
                    obeFees.FinancingPercentage = Math.Round(100 - ((obeFees.InitialFeeAmount * 100) / obeFees.CapitalBalance), 2);
                    obeFees.FinancedAmount = obeFees.AmountPEN - obeFees.InitialFeeAmount;
                    sb.Append(obeFees.AmountPEN);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.FinancedAmount);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.TotalAmountOfInterest); //detalle
                    sb.Append(obeParameters.palote);
                    sb.Append(DateTime.Now.ToShortDateString());
                    sb.Append(obeParameters.codito);
                    sb.Append(obeFees.FinancingPercentage); //cortar
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.NumberQuoteOfPay);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.AnualEffectiveRate);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.periodicity);
                    sb.Append(obeParameters.sombrerito);
                    for (int f = 0; f < obeFees.NumberOfInitialOfPay; f++) //modificacionParaMontosEditables
                    {
                        if (f == 0)
                        {
                            sb.Append("Inicial nro: " + Convert.ToString(f + 1));
                        }
                        if (f == 1)
                        {
                            sb.Append("Upgrade");
                        }
                        if (f > 1)
                        {
                            sb.Append("Inicial nro: " + Convert.ToString(f));
                        }

                        sb.Append(obeParameters.palote);
                        if (f == 0) sb.Append(Convert.ToDateTime(lInitialDate[f]).ToShortDateString());
                        if (f == 1) sb.Append(Convert.ToDateTime(lInitialDate[f + 1]).ToShortDateString());
                        if (f == 2) sb.Append(Convert.ToDateTime(lInitialDate[f + 2]).ToShortDateString());
                        if (f == 3) sb.Append(Convert.ToDateTime(lInitialDate[f + 3]).ToShortDateString());
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.CapitalBalance, 2)));
                        sb.Append(obeParameters.palote);
                        if (f == 0) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 1]).ToString())));//primeraCuota
                        if (f == 1) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 2]).ToString())));//primeraCuota
                        if (f == 2) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 3]).ToString())));//primeraCuota
                        if (f == 3) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 4]).ToString())));//primeraCuota
                        sb.Append(obeParameters.palote);
                        //  countQuote += Math.Round(obeFees.Quote + obeFees.Amortization);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.interestingInitial, 2)));
                        sb.Append(obeParameters.palote);
                        // sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Amortization,2)));
                        if (f == 0) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 1]).ToString())));//primeraCuota
                        if (f == 1) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 2]).ToString())));//primeraCuota
                        if (f == 2) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 3]).ToString())));//primeraCuota
                        if (f == 3) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 4]).ToString())));//primeraCuota
                        sb.Append(obeParameters.codito);
                        if (f == 0) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 1]);
                        //if (f == 1) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 2]);
                        if (f == 2) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 3]);
                        if (f == 3) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 4]);
                        flag++;
                    }
                    if (obeFees.MonthlyRate != 0) obeFees.Quote = CalculeMonthlyQuote(obeFees.CapitalBalance, obeFees.NumberQuoteOfPay, obeFees.MonthlyRate); //cortar
                    else obeFees.Quote = obeFees.CapitalBalance / obeFees.NumberQuoteOfPay;
                    for (int f = 0; f < obeFees.NumberQuoteOfPay; f++)
                    {
                        obeFees.Interests = obeFees.CapitalBalance * obeFees.MonthlyRate; //cortar
                        obeFees.Amortization = obeFees.Quote - obeFees.Interests; //cortar
                        sb.Append("Cuota nro: " + Convert.ToString(f + 1));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeFees.DateQuoteStart.Date.AddMonths(f).ToShortDateString()));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.CapitalBalance, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Amortization, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Interests, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Quote, 2)));
                        sb.Append(obeParameters.codito);
                        obeFees.CapitalBalance = Math.Round(obeFees.CapitalBalance - obeFees.Amortization, 2);
                        countQuote += obeFees.Quote;
                        if (f == obeFees.NumberQuoteOfPay) countQuote += obeFees.Quote; //totalCuotas=totalApagar
                        if (f == 0) countInterest += Math.Round(obeFees.Interests, 2);
                        obeFees.Interests = Math.Round(obeFees.CapitalBalance * obeFees.MonthlyRate, 2);
                        if (f == 0) countInterest += Math.Round(obeFees.Interests, 2);
                        if (f != 0) countInterest += Math.Round(obeFees.Interests, 2);

                        if (f >= obeFees.NumberQuoteOfPay - 1)
                        {
                            sb.Append(obeParameters.gruna);
                            sb.Append(Math.Round(countInterest, 2));//totalDeInteres
                            sb.Append(obeParameters.gruna);
                            sb.Append(Math.Round(countQuote, 2));//totalDeInteres
                        }
                    }
                    sb = sb.Remove(sb.Length - 1, 1);  //{knava|1|lastmname|8888|999|999¬19800|19750|0|10/16/2018¬99.75|24|10|Mensual^Inicial nro: 1|10/16/2018|S/. 19800|S/. 50|S/. 0|S/. 50¬Cuota nro: 1|10/16/2018|S/. 19750|S/. 749.95|S/. 157.49|S/. 907.44¬Cuota nro: 2|11/16/2018|S/. 19000.05|S/. 755.93|S/. 151.51|S/. 907.44¬Cuota nro: 3|12/16/2018|S/. 18244.12|S/. 761.96|S/. 145.48|S/. 907.44¬Cuota nro: 4|1/16/2019|S/. 17482.16|S/. 768.03|S/. 139.41|S/. 907.44¬Cuota nro: 5|2/16/2019|S/. 16714.13|S/. 774.16|S/. 133.28|S/. 907.44¬Cuota nro: 6|3/16/2019|S/. 15939.97|S/. 780.33|S/. 127.11|S/. 907.44¬Cuota nro: 7|4/16/2019|S/. 15159.64|S/. 786.55|S/. 120.89|S/. 907.44¬Cuota nro: 8|5/16/2019|S/. 14373.09|S/. 792.83|S/. 114.61|S/. 907.44¬Cuota nro: 9|6/16/2019|S/. 13580.26|S/. 799.15|S/. 108.29|S/. 907.44¬Cuota nro: 10|7/16/2019|S/. 12781.11|S/. 805.52|S/. 101.92|S/. 907.44¬Cuota nro: 11|8/16/2019|S/. 11975.59|S/. 811.94|S/. 95.5|S/. 907.44¬Cuota nro: 12|9/16/2019|S/. 11163.65|S/. 818.42|S/. 89.02|S/. 907.44¬Cuota nro: 13|10/16/2019|S/. 10345.23|S/. 824.94|S/. 82.49|S/. 907.44¬Cuota nro: 14|11/16/2019|S/. 9520.29|S/. 831.52|S/. 75.92|S/. 907.44¬Cuota nro: 15|12/16/2019|S/. 8688.77|S/. 838.15|S/. 69.29|S/. 907.44¬Cuota nro: 16|1/16/2020|S/. 7850.62|S/. 844.84|S/. 62.6|S/. 907.44¬Cuota nro: 17|2/16/2020|S/. 7005.78|S/. 851.57|S/. 55.87|S/. 907.44¬Cuota nro: 18|3/16/2020|S/. 6154.21|S/. 858.36|S/. 49.07|S/. 907.44¬Cuota nro: 19|4/16/2020|S/. 5295.85|S/. 865.21|S/. 42.23|S/. 907.44¬Cuota nro: 20|5/16/2020|S/. 4430.64|S/. 872.11|S/. 35.33|S/. 907.44¬Cuota nro: 21|6/16/2020|S/. 3558.53|S/. 879.06|S/. 28.38|S/. 907.44¬Cuota nro: 22|7/16/2020|S/. 2679.47|S/. 886.07|S/. 21.37|S/. 907.44¬Cuota nro: 23|8/16/2020|S/. 1793.4|S/. 893.14|S/. 14.3|S/. 907.44¬Cuota nro: 24|9/16/2020|S/. 900.26|S/. 900.26|S/. 7.18|S/. 907.44¬~2028.54~21778.52}
                    var auxStr = sb.ToString();
                    var auxStr2 = auxStr.Split('^');
                    var auxStr3 = auxStr2[1];
                    var auxStr4 = auxStr3.Split('~');
                    var auxStr5 = auxStr4[0];
                    auxStr5 = auxStr5.Remove(auxStr5.Length - 1);
                    auxStr5 = auxStr5 + '$' + username;
                    cn.Open();
                    DaPayments daPayments = new DaPayments();

                    auxStr5 = auxStr5.Replace("Inicial nro: 1", "Inicial nro: 0");
                    auxStr5 = auxStr5.Replace("Inicial nro: 2", "Inicial nro: 1");
                    auxStr5 = auxStr5.Replace("Inicial nro: 3", "Inicial nro: 2");
                    auxStr5 = auxStr5.Replace("Inicial nro: 4", "Inicial nro: 3");

                    return daPayments.putPayment(cn, auxStr5, data2, exchange, data4);
                }
                catch (Exception e)
                {
                    //RecordLog(e.Message, e.StackTrace);
                    return false;
                }
                finally
                {
                    cn.Close();
                }
            }
        }



        public string GetCalculatePaymentScheduleStringUpgrade(string data, string username, string quoteInitials, string flag2, bool notInteres, bool upgrade) //"knava|empty^6000|3.3|empty|empty|24|10/16/2018|50|10|1|empty^10/16/2018|50 vs  |CLB^3000|3.2|VE034|VE035|24|2018-10-10|1000|10|1|obs^2018-10-11|1000~nombres|apellidos|1|73680066|963258741$2018-10-12"
        {
            sb = new StringBuilder();
            obeFees = new beFeesPayDetail();
            //data="168 | LHT ^ 4210 | 3.25 | empty | empty | 48 | 2018 - 12 - 02 | 1397.5 | 10 | 1 | empty ^ 2018 - 11 - 02 | 682.52018 - 11 - 02 | 682.5"
            if (flag2 == "1")
            {
                data = "168|LHT  ^2110|3.25|empty|empty|24|2018-11-02|715|10|1|empty^2018-11-02|715|2018-12-02|800|2018-01-02|1000~fgjhfgbfb|fgbfb|178745896|78745896$2018-11-01";
            }
            //data = "168|LHT  ^2110|3.25|empty|empty|24|2018-11-02|715|10|1|empty^2018-11-02|715|2018-12-02|800|2018-01-02|1000~fgjhfgbfb|fgbfb|178745896|78745896$2018-11-01";
            obeParameters = new beParameters();
            // odaContract = new daContract();
            double countInterest = 0.0d;
            double countQuote = 0.0d;
            string answer = "";
            var listParametersPre = data.Split('$');
            var dateQuotesStart = listParametersPre[1];
            var listParameters = listParametersPre[0].Split('~');
            var dataPerson = listParameters[1].Split('|');
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    data = listParameters[0];  //"knava|empty^6000|3.3|empty|empty|24|16-10-2018|50|10|1|empty^16-10-2018|50"
                    string[] list = data.Split(obeParameters.sombrerito);
                    var flag = 0;
                    //"11|CLB^
                    string SendData = list[0].ToString();
                    //2500 |3.26|VE004|VE005|24|2018-07-25|1000|10|2|pruebita^
                    string[] lCalculationData = list[1].Split(obeParameters.palote);
                    obeFees.AmountUSD = Math.Round(Convert.ToDouble(lCalculationData[0]), 2);
                    obeFees.ExchangeRate = Math.Round(Convert.ToDouble(lCalculationData[1]), 5);
                    // obeFees.IdEmployeeLiner = "EMPTY";
                    //   obeFees.IdEmployeeCloser = "EMPTY";
                    obeFees.NumberQuoteOfPay = Convert.ToInt32(lCalculationData[4]);

                    obeFees.DateQuoteStart = Convert.ToDateTime(dateQuotesStart);
                    obeFees.InitialFeeAmount = Math.Round(Convert.ToDouble(lCalculationData[6]), 2);
                    //cuotasDeLaPrimeraCuota
                    obeFees.AnualEffectiveRate = Convert.ToInt32(lCalculationData[7]);
                    //obeFees.NumberOfInitialOfPay = Convert.ToInt32(lCalculationData[8]);
                    obeFees.NumberOfInitialOfPay = Convert.ToInt32(quoteInitials);
                    // obeFees.NumberOfInitialOfPay = Convert.ToInt32(lCalculationData[8]);
                    obeFees.Obs = lCalculationData[9];
                    //2018-07-25|2018-07-26"
                    string[] lInitialDate = list[2].Split(obeParameters.palote);
                    obeFees.CapitalBalance = obeFees.AmountUSD * obeFees.ExchangeRate;
                    obeFees.AmountPEN = obeFees.AmountUSD * obeFees.ExchangeRate;
                    obeFees.Amortization = obeFees.InitialFeeAmount / obeFees.NumberOfInitialOfPay;
                    obeFees.MonthlyRate = CalculateMonthlyRate(obeFees.AnualEffectiveRate);
                    obeFees.FinancingPercentage = Math.Round(100 - ((obeFees.InitialFeeAmount * 100) / obeFees.CapitalBalance), 2);
                    obeFees.FinancedAmount = obeFees.AmountPEN - obeFees.InitialFeeAmount;
                    sb.Append(obeFees.AmountPEN);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.FinancedAmount);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.TotalAmountOfInterest); //detalle
                    sb.Append(obeParameters.palote);
                    sb.Append(DateTime.Now.ToShortDateString());
                    sb.Append(obeParameters.codito);
                    sb.Append(obeFees.FinancingPercentage); //cortar
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.NumberQuoteOfPay);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.AnualEffectiveRate);
                    sb.Append(obeParameters.palote);
                    sb.Append(obeFees.periodicity);
                    sb.Append(obeParameters.sombrerito);
                    for (int f = 0; f < obeFees.NumberOfInitialOfPay; f++) //modificacionParaMontosEditables
                    {
                        if (f == 0)
                        {
                            sb.Append("Inicial nro: " + Convert.ToString(f + 1));
                        }
                        if (f == 1)
                        {
                            sb.Append("Upgrade");
                        }
                        if (f > 1)
                        {
                            sb.Append("Inicial nro: " + Convert.ToString(f));
                        }

                        sb.Append(obeParameters.palote);
                        if (f == 0) sb.Append(Convert.ToDateTime(lInitialDate[f]).ToShortDateString());
                        if (f == 1) sb.Append(Convert.ToDateTime(lInitialDate[f + 1]).ToShortDateString());
                        if (f == 2) sb.Append(Convert.ToDateTime(lInitialDate[f + 2]).ToShortDateString());
                        if (f == 3) sb.Append(Convert.ToDateTime(lInitialDate[f + 3]).ToShortDateString());
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.CapitalBalance, 2)));
                        sb.Append(obeParameters.palote);
                        if (f == 0) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 1]).ToString())));//primeraCuota
                        if (f == 1) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 2]).ToString())));//primeraCuota
                        if (f == 2) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 3]).ToString())));//primeraCuota
                        if (f == 3) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 4]).ToString())));//primeraCuota
                        sb.Append(obeParameters.palote);
                        //  countQuote += Math.Round(obeFees.Quote + obeFees.Amortization);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.interestingInitial, 2)));
                        sb.Append(obeParameters.palote);
                        // sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Amortization,2)));
                        if (f == 0) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 1]).ToString())));//primeraCuota
                        if (f == 1) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 2]).ToString())));//primeraCuota
                        if (f == 2) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 3]).ToString())));//primeraCuota
                        if (f == 3) sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + (Convert.ToString(lInitialDate[f + 4]).ToString())));//primeraCuota
                        sb.Append(obeParameters.codito);
                        if (f == 0) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 1]);
                        //if (f == 1) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 2]);
                        if (f == 2) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 3]);
                        if (f == 3) obeFees.CapitalBalance = obeFees.CapitalBalance - Convert.ToDouble(lInitialDate[f + 4]);
                        flag++;
                    }
                    if (obeFees.MonthlyRate != 0) obeFees.Quote = CalculeMonthlyQuote(obeFees.CapitalBalance, obeFees.NumberQuoteOfPay, obeFees.MonthlyRate); //cortar
                    else obeFees.Quote = obeFees.CapitalBalance / obeFees.NumberQuoteOfPay;
                    if (notInteres)
                    {
                        obeFees.Quote = obeFees.CapitalBalance / obeFees.NumberQuoteOfPay;
                    }

                    for (int f = 0; f < obeFees.NumberQuoteOfPay; f++)
                    {
                        obeFees.Interests = obeFees.CapitalBalance * obeFees.MonthlyRate; //cortar
                        if (notInteres)
                        {
                            obeFees.Interests = 0; //cortar
                        }

                        obeFees.Amortization = obeFees.Quote - obeFees.Interests; //cortar
                        sb.Append("Cuota nro: " + Convert.ToString(f + 1));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeFees.DateQuoteStart.Date.AddMonths(f).ToShortDateString()));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.CapitalBalance, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Amortization, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Interests, 2)));
                        sb.Append(obeParameters.palote);
                        sb.Append(Convert.ToString(obeParameters.symbolCurrencyDefault + Math.Round(obeFees.Quote, 2)));
                        sb.Append(obeParameters.codito);
                        obeFees.CapitalBalance = Math.Round(obeFees.CapitalBalance - obeFees.Amortization, 2);
                        countQuote += obeFees.Quote;
                        if (f == obeFees.NumberQuoteOfPay) countQuote += obeFees.Quote; //totalCuotas=totalApagar
                        if (f == 0) countInterest += Math.Round(obeFees.Interests, 2);
                        obeFees.Interests = Math.Round(obeFees.CapitalBalance * obeFees.MonthlyRate, 2);
                        if (f == 0) countInterest += Math.Round(obeFees.Interests, 2);
                        if (f != 0) countInterest += Math.Round(obeFees.Interests, 2);

                        if (f >= obeFees.NumberQuoteOfPay - 1)
                        {
                            sb.Append(obeParameters.gruna);
                            sb.Append(Math.Round(countInterest, 2));//totalDeInteres
                            sb.Append(obeParameters.gruna);
                            sb.Append(Math.Round(countQuote, 2));//totalDeInteres
                        }
                    }
                    sb = sb.Remove(sb.Length - 1, 1);  //{knava|1|lastmname|8888|999|999¬19800|19750|0|10/16/2018¬99.75|24|10|Mensual^Inicial nro: 1|10/16/2018|S/. 19800|S/. 50|S/. 0|S/. 50¬Cuota nro: 1|10/16/2018|S/. 19750|S/. 749.95|S/. 157.49|S/. 907.44¬Cuota nro: 2|11/16/2018|S/. 19000.05|S/. 755.93|S/. 151.51|S/. 907.44¬Cuota nro: 3|12/16/2018|S/. 18244.12|S/. 761.96|S/. 145.48|S/. 907.44¬Cuota nro: 4|1/16/2019|S/. 17482.16|S/. 768.03|S/. 139.41|S/. 907.44¬Cuota nro: 5|2/16/2019|S/. 16714.13|S/. 774.16|S/. 133.28|S/. 907.44¬Cuota nro: 6|3/16/2019|S/. 15939.97|S/. 780.33|S/. 127.11|S/. 907.44¬Cuota nro: 7|4/16/2019|S/. 15159.64|S/. 786.55|S/. 120.89|S/. 907.44¬Cuota nro: 8|5/16/2019|S/. 14373.09|S/. 792.83|S/. 114.61|S/. 907.44¬Cuota nro: 9|6/16/2019|S/. 13580.26|S/. 799.15|S/. 108.29|S/. 907.44¬Cuota nro: 10|7/16/2019|S/. 12781.11|S/. 805.52|S/. 101.92|S/. 907.44¬Cuota nro: 11|8/16/2019|S/. 11975.59|S/. 811.94|S/. 95.5|S/. 907.44¬Cuota nro: 12|9/16/2019|S/. 11163.65|S/. 818.42|S/. 89.02|S/. 907.44¬Cuota nro: 13|10/16/2019|S/. 10345.23|S/. 824.94|S/. 82.49|S/. 907.44¬Cuota nro: 14|11/16/2019|S/. 9520.29|S/. 831.52|S/. 75.92|S/. 907.44¬Cuota nro: 15|12/16/2019|S/. 8688.77|S/. 838.15|S/. 69.29|S/. 907.44¬Cuota nro: 16|1/16/2020|S/. 7850.62|S/. 844.84|S/. 62.6|S/. 907.44¬Cuota nro: 17|2/16/2020|S/. 7005.78|S/. 851.57|S/. 55.87|S/. 907.44¬Cuota nro: 18|3/16/2020|S/. 6154.21|S/. 858.36|S/. 49.07|S/. 907.44¬Cuota nro: 19|4/16/2020|S/. 5295.85|S/. 865.21|S/. 42.23|S/. 907.44¬Cuota nro: 20|5/16/2020|S/. 4430.64|S/. 872.11|S/. 35.33|S/. 907.44¬Cuota nro: 21|6/16/2020|S/. 3558.53|S/. 879.06|S/. 28.38|S/. 907.44¬Cuota nro: 22|7/16/2020|S/. 2679.47|S/. 886.07|S/. 21.37|S/. 907.44¬Cuota nro: 23|8/16/2020|S/. 1793.4|S/. 893.14|S/. 14.3|S/. 907.44¬Cuota nro: 24|9/16/2020|S/. 900.26|S/. 900.26|S/. 7.18|S/. 907.44¬~2028.54~21778.52}
                    var auxStr = sb.ToString();
                    var auxStr2 = auxStr.Split('^');
                    var auxStr3 = auxStr2[1];
                    var auxStr4 = auxStr3.Split('~');
                    var auxStr5 = auxStr4[0];
                    auxStr5 = auxStr5.Remove(auxStr5.Length - 1);
                    auxStr5 = auxStr5 + '$' + username;
                    cn.Open();
                    DaPayments daPayments = new DaPayments();

                    //return daPayments.putPayment(cn, auxStr5);
                    return sb.ToString();
                }
                catch (Exception e)
                {
                    //RecordLog(e.Message, e.StackTrace);
                    return "false";
                }
                finally
                {
                    cn.Close();
                }
            }
        }


    }
}
