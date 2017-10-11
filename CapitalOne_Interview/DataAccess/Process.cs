using System;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using CapitalOne_Interview.Common;
using CapitalOne_Interview.BusinessObject;
using CapitalOne_Interview.Interface;

namespace CapitalOne_Interview.DataAccess
{
    /// <summary>
    /// Process class 
    /// </summary>
    public class Process : IProcess
    {
        public string CalculateTransactions(TransactionCollection transactions)
        {
            string returnValue = string.Empty;
            if (transactions != null && transactions.Transactions != null && transactions.Transactions.Count > 0)
            {
                StringBuilder messageBuilder = new StringBuilder();
                if (transactions != null)
                {
                    //· --ignore-donuts: The user is so enthusiastic about donuts that they don't want donut spending to come out of their 
                    // budget. Disregard all donut-related transactions from the spending. You can just use the merchant field to determine 
                    // what's a donut - donut transactions will be named “Krispy Kreme Donuts” or “DUNKIN #336784”.
                    List<string> merchantFilter = new List<string> { "Krispy Kreme Donuts", "Dunkin #336784" };


                    var resultTransaction = from oTran in transactions.Transactions.Except
                                                 (
                                                                 //This inner query will get all the credit card payment transactions and the outer query will 
                                                                 // ignore these transaction records
                                                                 //· --ignore-cc-payments: Paying off a credit card shows up as a credit transaction and a debit transaction, 
                                                                 // but it's not really "spending" or "income". 
                                                                 // Make your aggregate numbers disregard credit card payments. For the users we give you, 
                                                                 // credit card payments will consist of two transactions with opposite amounts (e.g. 5000000 centocents and -5000000 centocents) 
                                                                 // within 24 hours of each other. For verification, you should also output a list of the credit card payments you detected - 
                                                                 //this can be in whatever format you like.
                                                                 from cParent in transactions.Transactions
                                                                 join cChild in transactions.Transactions
                                                                        on cParent.TransactionTime.ToString(Constants.MonthYearFormat) equals cChild.TransactionTime.ToString(Constants.MonthYearFormat)

                                                                 where
                                                                       cParent.TransactionId != cChild.TransactionId &&
                                                                       cParent.Amount == -1 * cChild.Amount &&
                                                                       cParent.TransactionTime.Subtract(cChild.TransactionTime).Hours < 24
                                                             //&& cParent.TransactionTime.ToString(Constants.MonthYearFormat) == "2014-11"
                                                             select cParent

                                                )
                                            where
                                                 !merchantFilter.Contains(oTran.Merchant)   // Filters donuts purchases, Credit Card and CC Payment 
                                                                                            //&& oTran.TransactionTime.ToString(Constants.MonthYearFormat) == "2014-11"
                                            group oTran by oTran.TransactionTime.ToString(Constants.MonthYearFormat) into trans
                                            select
                                                new
                                                {
                                                    AverageSpent = trans.Where(w => w.Merchant.Trim() != Constants.PayrollMerchant).GroupBy(g => 2).Select(s => new { Average = s.Average(sm => sm.Amount), Total = s.Count() }).First(),
                                                    AverageIncome = trans.Where(w => w.Merchant.Trim() == Constants.PayrollMerchant).GroupBy(g => 2).Select(s => new { Average = s.Average(sm => sm.Amount), Total = s.Count() }).First(),
                                                    MonthYear = trans.Key,
                                                    Income = trans.Where(w => w.Merchant.Trim() == Constants.PayrollMerchant).GroupBy(g => new { Merchant = g.Merchant }).Select(s => new { Sum = s.Sum(t => t.Amount), Total = s.Count() }),
                                                    Spent = trans.Where(w => w.Merchant.Trim() != "Zenpayroll").GroupBy(g => new { Merchant = g.Merchant }).Select(s => new { Sum = s.Sum(t => t.Amount), Total = s.Count() })
                                                };

                    // For U.S Culture, -ve currency value is marked open and close braces and hence formatting to -ve currency value
                    // hence changing teh CurrencyNegativePattern = 1 in order to show the currency value in -ve value as per the requirement


                    string print = "Actual result emitting Month Year, Spending and Income";
                    messageBuilder.AppendLine(print);
                    messageBuilder.AppendLine(new string('-', print.Length * 2) + "\n");

                    CultureInfo culture = this.GetCultureInfoForNegativePattern();
                    messageBuilder.Append("{");
                    foreach (var r in resultTransaction)
                    {
                        messageBuilder.AppendLine(string.Format(culture, @"""{0}"":{{""spent"":""{1:C}"",""Income"":""{2:C}""}},", r.MonthYear, r.Spent.Select(s => s.Sum).Sum(), r.Income.Select(s => s.Sum).Sum()));
                    }

                    messageBuilder.AppendLine(string.Format(culture, @"""{0}"":{{""spent"":""{1:C}"",""Income"":""{2:C}""}}}}",
                                                        "average",
                                                        resultTransaction.Select(s => s.AverageSpent.Average).First(),
                                                        resultTransaction.Select(s => s.AverageIncome.Average).First()
                                                 )
                                   );

                }
                returnValue = messageBuilder.ToString();
            }
            return returnValue;
        }

        public string GetCreditCardTransactions(TransactionCollection transactions)
        {
            string returnValue = string.Empty;
            if (transactions != null && transactions.Transactions!= null && transactions.Transactions.Count > 0)
            {
                StringBuilder messageBuilder = new StringBuilder();
                var ccPayments = from cParent in transactions.Transactions
                                 join cChild in transactions.Transactions
                                        on cParent.TransactionTime.ToString(Constants.MonthYearFormat) equals cChild.TransactionTime.ToString(Constants.MonthYearFormat)

                                 where
                                       cParent.TransactionId != cChild.TransactionId &&
                                       cParent.Amount == -1 * cChild.Amount &&
                                       cParent.TransactionTime.Subtract(cChild.TransactionTime).Hours < 24
                                 //&& cParent.TransactionTime.ToString(Constants.MonthYearFormat) == "2014-11"
                                 select cParent;

                string print = "Credit Card Payments";
                messageBuilder.AppendLine();
                messageBuilder.AppendLine(print);
                messageBuilder.AppendLine(new string('-', print.Length * 2) + "\n");
                CultureInfo culture = this.GetCultureInfoForNegativePattern();

                messageBuilder.Append("{");
                foreach (var ccPayment in ccPayments)
                {
                    messageBuilder.AppendLine(string.Format(culture, @"""{0}"":{{""Merchant"":""{1}"",""Amount"":""{2:C}""}}", ccPayment.TransactionTime.ToString(Constants.MonthYearFormat), ccPayment.Merchant, ccPayment.Amount));
                }
                messageBuilder.Append("}");
                returnValue = messageBuilder.ToString();
            }
            return returnValue;
        }

        private CultureInfo GetCultureInfoForNegativePattern()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.CurrencyNegativePattern = 1;
            return culture;
        }
    }
}