using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardProcessor.BusinessObject
{
    /// <summary>
    /// Credit Card Holders class which holds card holders details and max and current limits
    /// </summary>
    public class CreditCardHolderDetail
    {
        /// <summary>
        /// Credit Card Number
        /// </summary>
        public string CreditCardNumber;

        /// <summary>
        /// Credit card holders name
        /// </summary>
        public string CardHolderName;


        /// <summary>
        /// Customer Credit Card Max Money Limit
        /// </summary>
        public long MaxMoneyLimit;


        /// <summary>
        /// Customer Credit Card Current Money Limit
        /// </summary>
        public long CurrentMoney;

    }
}
