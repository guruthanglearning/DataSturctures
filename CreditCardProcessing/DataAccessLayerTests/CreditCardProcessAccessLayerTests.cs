using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CreditCardProcessor.DataAccessLayer;
using CreditCardProcessor.BusinessObject;

namespace CreditCardProcessor.DataAccessLayer.Tests
{
    /// <summary>
    /// Test class to validate Credit Card Process Access Layer
    /// </summary>
    [TestClass()]
    public class CreditCardProcessAccessLayerTests
    {
        CreditCardProcessAccessLayer dal = null;

        public CreditCardProcessAccessLayerTests()
        {
            dal = new CreditCardProcessAccessLayer();
        }
       
        /// <summary>
        /// Test which validates Card number, card holders name and max money is saved into Card Holder dictionary
        /// </summary>
        [TestMethod()]
        public void AddMoneyToCardHolderCard_Valid_CreditCard_Valid_Name_ValidMaxMoney_Test()
        {            
            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 1;

            var actual = dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);

            Assert.IsTrue(actual != null && actual.CreditCardNumber == creditCardNumber && actual.CardHolderName == creditCardHolderName && actual.MaxMoneyLimit == maxMoneyLimit);

        }

        /// <summary>
        /// Test which validates for invalid Card number, valid card holders name and valid max money is saved into Card Holder dictionary
        /// </summary>
        [TestMethod()]
        public void AddMoneyToCardHolderCard_InValid_CreditCard_Valid_Name_Test()
        {                      
            string creditCardNumber = "1234567890123456";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 1;

            var actual = dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);

            Assert.IsTrue(actual == null);

        }

        /// <summary>
        /// Test which validates entry being restricted into Card Holder dictionary when empty Card number, empty card holders name and valid max money is passed
        /// </summary>
        [TestMethod()]
        public void AddMoneyToCardHolderCard_EmptySpace_CreditCard_EmptySpace_Name_Test()
        {            
            string creditCardNumber = " ";
            string creditCardHolderName = "  ";
            long maxMoneyLimit = 1;

            var actual = dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);

            Assert.IsTrue(actual == null);
        }


        /// <summary>
        /// Test which validates entry being restricted into Card Holder dictionary when empty Card number, valid card holders name and valid max money is passed
        /// </summary>
        [TestMethod()]
        public void AddMoneyToCardHolderCard_EmptySpace_CreditCard_Valid_Name_Test()
        {         
            string creditCardNumber = " ";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 1;

            var actual = dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);


            Assert.IsTrue(actual == null);
        }

        /// <summary>
        /// Test which validates entry being restricted into Card Holder dictionary when valid  Card number, empty card holders name and valid max money is passed
        /// </summary>
        [TestMethod()]
        public void AddMoneyToCardHolderCard_Valid_CreditCard_EmptySpace_Name_Test()
        {         
            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = " ";
            long maxMoneyLimit = 1;

            var actual = dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);

            Assert.IsTrue(actual == null);
        }

        /// <summary>
        /// Test which validates entry being restricted into Card Holder dictionary when valid Card number, valid card holders name and -ve max money is passed
        /// </summary>
        [TestMethod()]
        public void AddMoneyToCardHolderCard_ValidCard_NegativeMoney_Test()
        {
            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = "test";
            long maxMoneyLimit = -1;

            var actual = dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);

            Assert.IsTrue(actual == null);
        }

        /// <summary>
        /// Test which validates whether card is been charged with  money > 0
        /// </summary>
        [TestMethod()]
        public void ChargeCardHolder_For_Valid_Card_Test()
        {

            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 100;
            long moneyToCharge = 10;

            dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);
            var actual = dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge);

            Assert.IsTrue(actual != null && actual.CurrentMoney == moneyToCharge);
        }


        /// <summary>
        /// Test which validates whether card is been charged more than its max limit
        /// </summary>
        [TestMethod()]
        public void ChargeCardHolder_For_Valid_Card_When_MoneyIsCharged_More_Than_Max_Limit_Test()
        {
            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 100;
            long moneyToCharge1 = 10;
            long moneyToCharge2 = 200;

            dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);
            dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge1);
            var actual = dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge2);
            Assert.IsTrue(actual != null && actual.CurrentMoney == moneyToCharge1);            
        }


        /// <summary>
        /// Test which validates whether card is been charged more than 1 time with different value
        /// </summary>
        [TestMethod()]
        public void ChargeCardHolder_For_Valid_Card_When_MoneyIsCharged_Twice_Test()
        {
            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 100;
            long moneyToCharge1 = 10;
            long moneyToCharge2 = 30;

            dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);
            dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge1);
            var actual = dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge2);

            Assert.IsTrue(actual != null && actual.CurrentMoney == (moneyToCharge1 + moneyToCharge2));
        }



        /// <summary>
        /// Test which validates whether invalid card is being charged
        /// </summary>
        [TestMethod()]
        public void ChargeCardHolder_For_InValid_Card_Test()
        {
            string creditCardNumber = "1234567890123456";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 100;
            long moneyToCharge = 10;

            dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);
            var actual = dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge);            

            Assert.IsTrue(actual == null);
        }


        /// <summary>
        /// Test which validates whether card is been charged with negative amount
        /// </summary>
        [TestMethod()]
        public void ChargeCardHolder_For_Valid_Card_With_NegativeMoney_Test()
        {
            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 100;
            long moneyToCharge = -10;

            dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);
            var actual = dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge);

            Assert.IsTrue(actual != null && actual.CurrentMoney == 0);
        }



        /// <summary>
        /// Test which validates whether card is been charged for the card which is not present in the dictionary
        /// </summary>
        [TestMethod()]
        public void ChargeCardHolder_For_Valid_Card_With_ValidMoney_Where_CardHolderNotExists_InDictionary_Test()
        {            
            string creditCardHolderName = "test";            
            long moneyToCharge = 10;
            
            var actual = dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge);

            Assert.IsTrue(actual == null);
        }

        /// <summary>
        /// Test which validates whether card is been credit for the valid card holder and with money > 0
        /// </summary>
        [TestMethod()]
        public void Credit_A_CardHolder_For_Valid_Card_For_Positive_Balance_Test()
        {
            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 100;
            long moneyToCharge = 20;
            long moneyToCredit = 10;

            dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);
            dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge);
            var actual = dal.Credit_A_CardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCredit);

            Assert.IsTrue(actual != null && actual.CurrentMoney == (moneyToCharge - moneyToCredit));
        }

        /// <summary>
        /// Test which validates whether card is been credit for the valid card holder and with money > 0 and ensure current limit goes in negative value
        /// </summary>
        [TestMethod()]
        public void Credit_A_CardHolder_For_Valid_Card_For_Negative_Balance_Test()
        {
            string creditCardNumber = "4111111111111111";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 100;
            long moneyToCharge = 20;
            long moneyToCredit = 30;

            dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);
            dal.ChargeCardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCharge);
            var actual = dal.Credit_A_CardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCredit);

            Assert.IsTrue(actual != null && actual.CurrentMoney == (moneyToCharge - moneyToCredit));
        }


        /// <summary>
        /// Test which validates whether card is been credit for the invalid card
        /// </summary>
        [TestMethod()]
        public void Credit_A_CardHolder_For_InValid_Card_Test()
        {
            string creditCardNumber = "1234567890123456";
            string creditCardHolderName = "test";
            long maxMoneyLimit = 100;
            long moneyToCredit = 30;

            dal.AddMoneyToCardHolderCard(creditCardNumber: creditCardNumber, creditCardHolderName: creditCardHolderName, maxMoneyLimit: maxMoneyLimit);
            var actual = dal.Credit_A_CardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCredit);

            Assert.IsTrue(actual == null);
        }

        /// <summary>
        /// Test which validates whether card is been credit for the card holder which is not in dictionary
        /// </summary>

        [TestMethod()]
        public void Credit_A_CardHolder_For_Valid_Card_With_ValidMoney_Where_CardHolderNotExists_InDictionary_Test()
        {            
            string creditCardHolderName = "test";
            long moneyToCredit = 10;

            var actual = dal.Credit_A_CardHolder(creditCardHolderName: creditCardHolderName, money: moneyToCredit);

            Assert.IsTrue(actual == null);
        }

    }
}