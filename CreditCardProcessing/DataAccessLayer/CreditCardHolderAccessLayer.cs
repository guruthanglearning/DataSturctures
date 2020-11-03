using System;
using System.Collections.Generic;
using System.Linq;

using CreditCardProcessor.BusinessObject;

namespace CreditCardProcessor.DataAccessLayer
{

    /// <summary>
    /// Credit Card Holder Data Access Layer
    /// </summary>
    public class CreditCardHolderAccessLayer 
    {

        /// <summary>
        /// Instantiate the object and assigns default values of it members
        /// </summary>
        public CreditCardHolderAccessLayer()
        {
            CreditCardHolders = new List<CreditCardHolder>();

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
        public List<CreditCardHolder> CreditCardHolders 
        { 
            get; 
        } = null;



        /// <summary>
        /// Insert Card Holder 
        /// </summary>
        /// <param name="creditCardNumber">Credit Card Number</param>
        /// <param name="creditCardHolderName">Card Holder Name</param>
        /// <returns></returns>
        public CreditCardHolder InsertCreditCardHolder(string creditCardNumber, string creditCardHolderName)
        {
            CreditCardHolder result = null;

            if (!string.IsNullOrWhiteSpace(creditCardNumber) && !string.IsNullOrWhiteSpace(creditCardHolderName))
            {
                result = new CreditCardHolder() { CreditCardNumber = creditCardNumber, CardHolderName = creditCardHolderName, IsCreditCardNumberValid = this.IsCardValidWithLuhn10(creditCardNumber) };
                CreditCardHolders.Add(result);
            }

            return result;
        }

    }
}
