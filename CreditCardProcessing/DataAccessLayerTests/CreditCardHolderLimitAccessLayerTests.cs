using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CreditCardProcessor.DataAccessLayer;

namespace DataAccessLayer.Tests
{
    [TestClass()]
    public class CreditCardHolderLimitAccessLayerTests
    {
        [TestMethod()]
        public void InsertCardHolderLimit_ValidCard_PositiveMoney_Test()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int maxMoneyLimit = 1000;                                        

            var actual = dal.AddMoneyToCardHolderCard(cardHolderName, maxMoneyLimit);

            Assert.IsTrue(actual.CreditCardHolderName == cardHolderName && actual.MaxMoneyLimit== maxMoneyLimit);
        }


        [TestMethod()]
        public void InsertCardHolderLimit_ValidCard_NegativeMoney_Test()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int maxMoneyLimit = -1000;

            var actual = dal.AddMoneyToCardHolderCard(cardHolderName, maxMoneyLimit);

            Assert.IsTrue(actual == null);
        }



        [TestMethod()]
        public void ChargeCardHolder_For_Valid_Card_Test()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int money = 100;
            dal.AddMoneyToCardHolderCard(cardHolderName, money);
            var actual =  dal.ChargeCardHolder(cardHolderName, money-1);

            Assert.IsTrue(actual.CreditCardHolderName == cardHolderName && actual.CurrentMoney == money-1);
        }



        [TestMethod()]
        public void ChargeCardHolder_For_Valid_Card_When_MoneyIsAdded_More_Than_Max_imitTest()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int money = 100;
            int chargeMoney1 = 50;
            int chargeMoney2 = 150;

            dal.AddMoneyToCardHolderCard(cardHolderName, money);
            var actual1 = dal.ChargeCardHolder(cardHolderName, chargeMoney1);
            var actual2 = dal.ChargeCardHolder(cardHolderName, chargeMoney2);

            Assert.IsTrue(actual2.CreditCardHolderName == cardHolderName && actual2.CurrentMoney == chargeMoney1);
        }



        [TestMethod()]
        public void ChargeCardHolder_For_InValid_Card_Test()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int money = 100;            
            var actual = dal.ChargeCardHolder(cardHolderName, money);

            Assert.IsTrue(actual == null);
        }

        [TestMethod()]
        public void ChargeCardHolder_For_Valid_Card_With_NegativeMoney_Test()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int money = -100;
            dal.AddMoneyToCardHolderCard(cardHolderName, money);
            var actual = dal.ChargeCardHolder(cardHolderName, money);

            Assert.IsTrue(actual == null);
        }



        [TestMethod()]
        public void Credit_A_CardHolder_For_Valid_Card_For_Positive_Balance_Test()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int money = 100;
            int moneyToCredit = 10;
            dal.AddMoneyToCardHolderCard(cardHolderName, money);
            dal.ChargeCardHolder(cardHolderName, money);
            var actual = dal.Credit_A_CardHolder(cardHolderName, moneyToCredit);

            Assert.IsTrue(actual.CreditCardHolderName == cardHolderName && actual.CurrentMoney == money - moneyToCredit);
        }


        [TestMethod()]
        public void Credit_A_CardHolder_For_Valid_Card_For_Negative_Balance_Test()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int money = 100;
            int moneyToCredit = 110;
            dal.AddMoneyToCardHolderCard(cardHolderName, money);
            var actual = dal.Credit_A_CardHolder(cardHolderName, moneyToCredit);

            Assert.IsTrue(actual.CreditCardHolderName == cardHolderName && actual.CurrentMoney ==  - moneyToCredit);
        }

        [TestMethod()]
        public void Credit_A_CardHolder_For_InValid_Card_Test()
        {
            CreditCardHolderLimitAccessLayer dal = new CreditCardHolderLimitAccessLayer();
            string cardHolderName = "test";
            int money = 100;
            var actual = dal.ChargeCardHolder(cardHolderName, money);

            Assert.IsTrue(actual == null);
        }



    }
}