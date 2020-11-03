using System;
using System.Collections.Generic;
using System.Text;

using CreditCardProcessor.BusinessObject;

namespace DataAccessLayer
{
    public class CreditCardHolderLimitAccessLayer
    {
        private SortedDictionary<string, CreditCardHolderLimit> dictCreditCardHoldersLimits = null;

        public CreditCardHolderLimitAccessLayer()
        {
            dictCreditCardHoldersLimits = new SortedDictionary<string, CreditCardHolderLimit>();
        }

        /// <summary>
        /// Gets List of Credit Card Holders Limits
        /// </summary>
        public List<CreditCardHolderLimit> CreditCardHolders
        {
            get
            {
                var result = new List<CreditCardHolderLimit>();
                foreach(var hl in dictCreditCardHoldersLimits.Values)
                {
                    result.Add(hl);
                }

                return result;

            }
        }


        /// <summary>
        /// Insert CardHolder Max Limit
        /// </summary>
        /// <param name="cardHolderName">Card Holder Name</param>
        /// <param name="maxMoneyLimit">Max Money Limit of the card holder</param>
        /// <param name="isCreditCardError">Determines card number belongs to the card holder is valid or not</param>
        /// <returns>Returns Credit CardHolder Limit</returns>
        public CreditCardHolderLimit AddMoneyToCardHolderCard(string creditCardHolderName, int maxMoneyLimit)
        {
            CreditCardHolderLimit result = null;
            if (maxMoneyLimit > 0)
            {
                result = new CreditCardHolderLimit() { CreditCardHolderName = creditCardHolderName, MaxMoneyLimit = maxMoneyLimit };
                dictCreditCardHoldersLimits[creditCardHolderName] = result;
            }
            return result;
        }

        /// <summary>
        /// Charges Credit card for the card holder
        /// </summary>
        /// <param name="creditCardHolderName">Card Holder Name</param>
        /// <param name="money">Money to add to the Card Holders card</param>
        /// <returns>Returns Credit CardHolder Limit</returns>
        public CreditCardHolderLimit ChargeCardHolder(string creditCardHolderName, int money)
        {
            CreditCardHolderLimit result = null;
            if (money > 0)
            {
                dictCreditCardHoldersLimits.TryGetValue(creditCardHolderName, out result);
                if (result != null)
                {
                    if ((result.CurrentMoney + money) <= result.MaxMoneyLimit)
                        result.CurrentMoney += money;
                }
            }

            return result;
        }


        /// <summary>
        /// Charges Credit card for the card holder
        /// </summary>
        /// <param name="creditCardHolderName">Card Holder Name</param>
        /// <param name="money">Money to add to the Card Holders card</param>
        /// <returns>Returns Credit CardHolder Limit</returns>
        public CreditCardHolderLimit Credit_A_CardHolder(string creditCardHolderName, int money)
        {
            CreditCardHolderLimit result = null;
            if (money > 0)
            {
                dictCreditCardHoldersLimits.TryGetValue(creditCardHolderName, out result);
                if (result != null)
                {
                    result.CurrentMoney -= money;
                }
            }
            return result;
        }     
    }
}
