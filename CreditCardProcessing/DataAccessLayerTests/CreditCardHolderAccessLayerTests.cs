using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CreditCardProcessor.DataAccessLayer;

namespace CreditCardProcessor.DataAccessLayer.Tests
{
    [TestClass()]
    public class CreditCardHolderAccessLayerTests
    {
        [TestMethod()]
        public void InsertCreditCardHolder_Valid_CreditCard_Valid_Name_Test()
        {
            CreditCardHolderAccessLayer dal = new CreditCardHolderAccessLayer();
            string creditCardNumber = "4111111111111111";
            string cardHolderName = "test";

            var actual =  dal.InsertCreditCardHolder(creditCardNumber, cardHolderName);

            Assert.IsTrue(actual.CreditCardNumber == creditCardNumber && actual.CardHolderName == cardHolderName);

        }


        [TestMethod()]
        public void InsertCreditCardHolder_InValid_CreditCard_Valid_Name_Test()
        {
            CreditCardHolderAccessLayer dal = new CreditCardHolderAccessLayer();
            string creditCardNumber = "1234567890123456";
            string cardHolderName = "test";

            var actual = dal.InsertCreditCardHolder(creditCardNumber, cardHolderName);

            Assert.IsTrue(actual.CreditCardNumber == creditCardNumber && actual.CardHolderName == cardHolderName);

        }


        [TestMethod()]
        public void InsertCreditCardHolder_EmptySpace_CreditCard_EmptySpace_Name_Test()
        {
            CreditCardHolderAccessLayer dal = new CreditCardHolderAccessLayer();
            string creditCardNumber = " ";
            string cardHolderName = " ";

            var actual = dal.InsertCreditCardHolder(creditCardNumber, cardHolderName);

            Assert.IsTrue(actual == null);
        }

        [TestMethod()]
        public void InsertCreditCardHolder_EmptySpace_CreditCard_Valid_Name_Test()
        {
            CreditCardHolderAccessLayer dal = new CreditCardHolderAccessLayer();
            string creditCardNumber = " ";
            string cardHolderName = "test";

            var actual = dal.InsertCreditCardHolder(creditCardNumber, cardHolderName);

            Assert.IsTrue(actual == null);
        }


        [TestMethod()]
        public void InsertCreditCardHolder_Valid_CreditCard_EmptySpace_Name_Test()
        {
            CreditCardHolderAccessLayer dal = new CreditCardHolderAccessLayer();
            string creditCardNumber = "4111111111111111";
            string cardHolderName = " ";

            var actual = dal.InsertCreditCardHolder(creditCardNumber, cardHolderName);

            Assert.IsTrue(actual == null);
        }

    }
}