using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DMStorefront.Shared;


namespace DMStoreTests
{
    [TestClass]
    public class PriceTests
    {
        [TestMethod]

        //Does the Price(value) constructor turn the copper value
        //into the correct Gold, Silver, and Copper amounts?
        //Does the Price(gold, silver, copper) constructor turn the
        //g,s,c amounts into the correct copper-based Value?
        public void ValueToGSC()
        {
            int value = 345;
            int expectedGold = 3;
            int expectedSilver = 4;
            int expectedCopper = 5;

            
            Price = new Price newPrice
            
        }
    }
}
