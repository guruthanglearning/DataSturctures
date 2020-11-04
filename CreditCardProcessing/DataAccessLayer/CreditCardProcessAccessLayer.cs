using System;
using System.Collections.Generic;
using System.Linq;

using CreditCardProcessor.BusinessObject;

namespace CreditCardProcessor.DataAccessLayer
{

    /// <summary>
    /// Credit Card ProcessData Access Layer
    /// </summary>
    public class CreditCardProcessAccessLayer 
    {

        private CreditCardHolder cardHolder;

        /// <summary>
        /// Instantiate the object and assigns default values of it members
        /// </summary>
        public CreditCardProcessAccessLayer()
        {
            cardHolder = new CreditCardHolder();            

        }


        /// <summary>
        /// vALIDA
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        private bool IsCardValidWithLuhn10(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            int sum = 0;
            bool isSecond = false;
            int curVal = 0;

            for(int i = cardNumber.Length-1; i>=0; i--)
            {

                curVal = cardNumber[i] - '0';

                if (isSecond)
                {
                    curVal *= 2;
                }

                if (curVal > 9)
                {
                    sum += (curVal / 10);
                    sum += (curVal % 10);
                }
                else
                {
                    sum += curVal;
                }
                isSecond = !isSecond;
            }

            return (sum % 10 == 0);
        }


        /// <summary>
        /// Gets List of Credit Card Holders
        /// </summary>
        public SortedDictionary<string, CreditCardHolderDetail> CardHolders 
        {
            get => cardHolder.CardCardHolders;
        } 


        /// <summary>
        /// Insert CardHolder Max Limit
        /// </summary>
        /// <param name="cardHolderName">Card Holder Name</param>
        /// <param name="maxMoneyLimit">Max Money Limit of the card holder</param>
        /// <param name="isCreditCardError">Determines card number belongs to the card holder is valid or not</param>
        /// <returns>Returns Credit CardHolder Limit</returns>
        public CreditCardHolderDetail AddMoneyToCardHolderCard(string creditCardHolderName,  string creditCardNumber, long maxMoneyLimit)
        {
            CreditCardHolderDetail result = null;
            if (!string.IsNullOrWhiteSpace(creditCardNumber) && !string.IsNullOrWhiteSpace(creditCardHolderName) && maxMoneyLimit > 0 )
            {
                if (this.IsCardValidWithLuhn10(creditCardNumber))
                    result = new CreditCardHolderDetail() { CreditCardNumber = creditCardNumber, CardHolderName = creditCardHolderName, MaxMoneyLimit = maxMoneyLimit};
                cardHolder.CardCardHolders[creditCardHolderName] = result;
            }
            return result;
        }

        /// <summary>
        /// Charges Credit card for the card holder
        /// </summary>
        /// <param name="creditCardHolderName">Card Holder Name</param>
        /// <param name="money">Money to add to the Card Holders card</param>
        /// <returns>Returns Credit CardHolder Limit</returns>
        public CreditCardHolderDetail ChargeCardHolder(string creditCardHolderName, long money)
        {
            CreditCardHolderDetail result = null;                        
            cardHolder.CardCardHolders.TryGetValue(creditCardHolderName, out result);
            if (result != null  && money > 0 && (result.CurrentMoney + money) <= result.MaxMoneyLimit)
                    result.CurrentMoney += money;                
            
            return result;
        }


        /// <summary>
        /// Charges Credit card for the card holder
        /// </summary>
        /// <param name="creditCardHolderName">Card Holder Name</param>
        /// <param name="money">Money to add to the Card Holders card</param>
        /// <returns>Returns Credit CardHolder Limit</returns>
        public CreditCardHolderDetail Credit_A_CardHolder(string creditCardHolderName, long money)
        {
            CreditCardHolderDetail result = null;
            if (money > 0)
            {
                cardHolder.CardCardHolders.TryGetValue(creditCardHolderName, out result);
                if (result != null)                
                    result.CurrentMoney -= money;
                
            }
            return result;
        }                   

    }
}
