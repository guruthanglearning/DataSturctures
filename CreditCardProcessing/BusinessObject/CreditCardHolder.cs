using System;
using System.Collections.Generic;

namespace CreditCardProcessor.BusinessObject
{
    /// <summary>
    /// Credit Card Holder 
    /// </summary>
    public class CreditCardHolder
    {
        /// <summary>
        /// Credit Card Number
        /// </summary>
        public string CreditCardNumber;

        /// <summary>
        /// Credit CardHolder Name
        /// </summary>
        public string CardHolderName;


        /// <summary>
        /// Determines validity of CreditCardNumber;
        /// </summary>
        public bool IsCreditCardNumberValid;

        /// <summary>
        /// Credit Card Holder
        /// </summary>
        public SortedDictionary<string, CreditCardHolderLimit> CardCardHolder;

    }
}
