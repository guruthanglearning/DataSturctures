using System;
using CapitalOne_Interview.BusinessObject;
namespace CapitalOne_Interview.Interface
{
    /// <summary>
    /// IProcess Interface
    /// </summary>
    interface IProcess
    {
        string CalculateTransactions(TransactionCollection transactionCollection);

        string GetCreditCardTransactions(TransactionCollection transactionCollection);
    }
}
