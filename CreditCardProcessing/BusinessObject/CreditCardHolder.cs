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
        /// Credit Card Holder
        /// </summary>
        private SortedDictionary<string, CreditCardHolderDetail> cardCardHolders;


        public CreditCardHolder()
        {
            cardCardHolders = new SortedDictionary<string, CreditCardHolderDetail>();
        }



        public SortedDictionary<string, CreditCardHolderDetail> CardCardHolders
        { 
            get => cardCardHolders; 
            set => cardCardHolders = value; 
        }

      

    }
}
