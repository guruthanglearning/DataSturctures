using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;

namespace CapitalOne_Interview
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();            
            //client.BaseAddress = new Uri("https://2016.api.levelmoney.com/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Transaction transaction = null;
            //HttpResponseMessage response = client.GetAsync("https://2016.api.levelmoney.com/api/v2/core/get-all-transactions/?uid=1110590645&token=2B5075227E074DECE543EB29AA60A9D4&api-toke=AppTokenForInterview").Result;
            //string transactionJson = System.IO.File.ReadAllText(Path.Combine(Application.StartupPath, "TransactionData.json"));
            //DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Transaction>));

            //MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(transactionJson));

            //List<Transaction> cTransactions = (List<Transaction>)js.ReadObject(stream);
            //Transaction[] transactions = JsonConvert.DeserializeObject<Transaction[]>(transactionJson);

            TransactionCollection transactions = null;

            //Loading json data to transaction collection 
            using (StreamReader stream = new StreamReader(Path.Combine(Application.StartupPath, "TransactionData.json")))
            {
                transactions = (TransactionCollection)JsonConvert.DeserializeObject(stream.ReadToEnd(), typeof(TransactionCollection));
            }
            StringBuilder builder = new StringBuilder();
            if (transactions != null)
            {
                List<string> merchantFilter = new List<string> { "Krispy Kreme Donuts", "Dunkin #336784" };
                // Group the transaction based on year and month then calculating the spending and income based on the payroll                  
                //Right Query validate carefully before delete

                //var resultTransaction = from tran in transactions.Transactions
                //                        where
                //                             !merchantFilter.Contains(tran.Merchant) && // Filters donuts purchases, Credit Card and CC Payment
                //                             tran.TransactionTime.ToString("yyyy-MM") == "2014-10"
                //                        group tran by tran.TransactionTime.ToString("yyyy-MM") into trans
                //                        select
                //                            new
                //                            {
                //                                MonthYear = trans.Key,
                //                                Income = trans.Where(w => w.Merchant.Trim() == "Zenpayroll").GroupBy(g=> new { Merchant = g.Merchant }).Select(s=> new { Sum = s.Sum(t => t.Amount), Total=s.Count()}),                                                
                //                                Spent = trans.Where(w => w.Merchant.Trim()!="Zenpayroll").GroupBy(g => new { Merchant = g.Merchant }).Select(s => new { Sum = s.Sum(t => t.Amount), Total = s.Count() })
                //                            };

                var resultTransaction = from tran in transactions.Transactions
                                        where
                                             !merchantFilter.Contains(tran.Merchant) && // Filters donuts purchases, Credit Card and CC Payment
                                             tran.TransactionTime.ToString("yyyy-MM") == "2014-11"
                                        group tran by tran.TransactionTime.ToString("yyyy-MM") into trans
                                        select
                                            new
                                            {
                                                AverageSpent = trans.Where(w => w.Merchant.Trim() != "Zenpayroll").GroupBy(g => 2).Select(s => new { Average = s.Average(sm => sm.Amount), Total = s.Count() }).First(),
                                                AverageIncome = trans.Where(w => w.Merchant.Trim() == "Zenpayroll").GroupBy(g => 2).Select(s => new { Average = s.Average(sm => sm.Amount), Total = s.Count() }).First(),
                                                MonthYear = trans.Key,
                                                Income = trans.Where(w => w.Merchant.Trim() == "Zenpayroll").GroupBy(g => new { Merchant = g.Merchant }).Select(s => new { Sum = s.Sum(t => t.Amount), Total = s.Count() }),
                                                Spent = trans.Where(w => w.Merchant.Trim() != "Zenpayroll").GroupBy(g => new { Merchant = g.Merchant }).Select(s => new { Sum = s.Sum(t => t.Amount), Total = s.Count() })
                                            };

                // For U.S Culture, -ve currency value is marked open and close braces and hence formatting to -ve currency value
                // hence changing teh CurrencyNegativePattern = 1 in order to show the currency value in -ve value as per the requirement
                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.NumberFormat.CurrencyNegativePattern = 1;

                string print = "Actual result emitting Month Year, Spending and Income - Eliminating Donuts, Credit Card Payments";
                builder.Append(print + "\n");
                builder.Append(new string('-', print.Length * 2) + "\n");


                foreach (var r in resultTransaction)
                {
                    builder.Append("");
                    builder.Append(string.Format(culture, "MonthYear={0} Spent = {1:C} Income = {2:C} \n", r.MonthYear, r.Spent.Select(s => s.Sum).Sum(), r.Income.Select(s => s.Sum).Sum()));
                    //builder.Append($"MonthYear={r.MonthYear} Spent = {r.Spent:C} Income = {r.Income:C} \n");
                }


                builder.Append(string.Format(culture, "Average Spent = {0:C}  SpentCount = {1} Income = {2:C} IncomeCount = {3} \n",
                                                    resultTransaction.Select(s => s.AverageSpent.Average).First(),
                                                    resultTransaction.Select(s => s.AverageSpent.Total).First(),
                                                    resultTransaction.Select(s => s.AverageIncome.Average).First(),
                                                    resultTransaction.Select(s => s.AverageIncome.Total).First()
                                             )
                               );

                builder.Append("\n\n");

                //builder.Append(string.Format(culture, "Average Spent = {0:C}  SpentCount = {1} Income = {2:C} IncomeCount = {3} \n", 
                //                                    resultTransaction.Select(s=> s.Spent.Select(ss=>ss.Sum).Sum()).Sum()/ resultTransaction.Select(s => s.Spent.Select(ss => ss.Total).Sum()).Sum(),
                //                                    resultTransaction.Select(s => s.Spent.Select(ss=>ss.Total).Sum()).Sum(),
                //                                    resultTransaction.Select(s => s.Income.Select(ss => ss.Sum).Sum()).Sum() / resultTransaction.Select(s => s.Income.Select(ss => ss.Total).Sum()).Sum(),
                //                                    resultTransaction.Select(s => s.Income.Select(ss => ss.Total).Sum()).Sum()
                //                             )
                //               );
                //builder.Append("\n\n");

                print = "Spending Aggregation for given month";
                builder.Append(print + "\n");
                builder.Append(new string('-', print.Length * 2) + "\n");

                //Gets spending aggregiates for the given month
                merchantFilter.Add("Zenpayroll");
                var result1_00 = from tran in transactions.Transactions
                                 where
                                      !merchantFilter.Contains(tran.Merchant) && // Filters donuts purchases, Credit Card and CC Payment
                                      tran.TransactionTime.ToString("yyyy-MM") == "2014-11"
                                 group tran by tran.TransactionTime.ToString("yyyy-MM")
                             into trans
                                 select
                                     new
                                     {
                                         MonthYear = trans.Key,
                                         Merchant = "Spent",
                                         Amount = trans.Select(s => s.Amount).Sum()
                                     };

                foreach (var t in result1_00)
                {
                    builder.Append(string.Format("MonthYear={0}|Merchant={1}|Amountcome={2}\n", t.MonthYear, t.Merchant, t.Amount));
                }


                builder.Append("\n\n");
                print = "All transaction for given month";
                builder.Append(print + "\n");
                builder.Append(new string('-', print.Length * 2) + "\n");

                //Gets all the transaction from JSON file
                var result1_0 = from t in transactions.Transactions
                                where
                                    t.TransactionTime.ToString("yyyy-MM") == "2014-11"
                                orderby t.TransactionTime
                                select new { MonthYear = t.TransactionTime, Merchant = t.Merchant, Amount = t.Amount };

                foreach (var t in result1_0)
                {
                    builder.Append(string.Format("MonthYear={0}|Merchant={1}|Amountcome={2}\n", t.MonthYear, t.Merchant, t.Amount));
                }

                builder.Append("Total Sum" + result1_0.Where(w => !merchantFilter.Contains(w.Merchant)).Select(s => s.Amount).Sum());

                builder.Append("\n\n");
                print = "Credit Card Transaction for given month";
                builder.Append(print + "\n");
                builder.Append(new string('-', print.Length * 2) + "\n");

                //Prints CC and Credit Card Payments for an given Month
                var result1_1 = from t in transactions.Transactions
                                where
                                    (t.Merchant == "CC Payment" || t.Merchant == "Credit Card Payment") &&
                                    t.TransactionTime.ToString("yyyy-MM") == "2014-11"
                                orderby t.TransactionTime
                                select new { MonthYear = t.TransactionTime, Merchant = t.Merchant, Amount = t.Amount };

                foreach (var t in result1_1)
                {
                    builder.Append(string.Format("MonthYear={0}|Merchant={1}|Amountcome={2}\n", t.MonthYear, t.Merchant, t.Amount));
                }

                builder.Append("\n\n");

                print = "Credit Card payment based on the Acceptance Criteria";
                builder.Append(print + "\n");
                builder.Append(new string('-', print.Length * 2) + "\n");
                //Prints CC and Credit Card Payment based on the acceptance Criteria given
                var result1 =
                                              from oTran in transactions.Transactions.Except
                                              (
                                                              from cParent in transactions.Transactions
                                                              join cChild in transactions.Transactions
                                                                     on cParent.TransactionTime.ToString("yyyy-MM") equals cChild.TransactionTime.ToString("yyyy-MM")

                                                              where
                                                                    cParent.TransactionTime.ToString("yyyy-MM") == "2014-11" &&
                                                                    cParent.TransactionId != cChild.TransactionId &&
                                                                    cParent.Amount == -1 * cChild.Amount &&
                                                                    cParent.TransactionTime.Subtract(cChild.TransactionTime).Hours < 24
                                                              select cParent
                                             )
                                              where
                                                   oTran.TransactionTime.ToString("yyyy-MM") == "2014-11"
                                              select oTran;


                foreach (var t in result1)
                {
                    builder.Append(string.Format("MonthYear={0}|Merchant={1}|Amountcome={2}\n", t.TransactionTime, t.Merchant, t.Amount));
                }
                builder.Append("\n\n");

                //foreach (var r in result1)
                //{
                //    builder.Append(string.Format("MonthYear={0}|Merchant={1}|Amountcome={2}\n", r.MonthYear, r.Merchant, r.Amount));
                //}
                richTextBox1.Text = builder.ToString();
            }

        }


        class TransactionCollection
        {
            [JsonProperty(PropertyName = "error")]
            public string Error { get; set; }

            [JsonProperty(PropertyName = "transactions")]
            public List<Transaction> Transactions { get; set; }
        }

        class Transaction
        {
            [JsonProperty(PropertyName = "amount")]
            public long Amount { get; set; }

            [JsonProperty(PropertyName = "is-pending")]
            public bool IsPending { get; set; }

            [JsonProperty(PropertyName = "aggregation-time")]
            public string AggregationTime { get; set; }

            [JsonProperty(PropertyName = "account-id")]
            public string AccountId { get; set; }

            [JsonProperty(PropertyName = "clear-date")]
            public long ClearDate { get; set; }

            [JsonProperty(PropertyName = "transaction-id")]
            public string TransactionId { get; set; }

            [JsonProperty(PropertyName = "raw-merchant")]
            public string RawMerchant { get; set; }

            [JsonProperty(PropertyName = "categorization")]
            public string Categorization { get; set; }

            [JsonProperty(PropertyName = "merchant")]
            public string Merchant { get; set; }

            [JsonProperty(PropertyName = "transaction-time")]
            public DateTime TransactionTime { get; set; }
        }
    }
}
