using DMStorefront.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMStorefront.Shared.Tests
{
    [TestClass()]
    public class PriceTests
    {
        [TestMethod()]
        public void Price_TurnsValueToCorrectGSCFields()
        {
            Price price = new Price(345);
            Assert.IsTrue(price.Gold.Equals(3));
            Assert.IsTrue(price.Silver.Equals(4));
            Assert.IsTrue(price.Copper.Equals(5));

        }

        [TestMethod()]
        public void Price_TurnsGSCFieldsToCorrectValue()
        {
            Price price = new Price(3, 4, 5);
            Assert.IsTrue(price.Value.Equals(345));
        }

        [TestMethod()]
        public void PriceTest2()
        {
            Price price = new Price(3, 40, 5);
            Assert.IsTrue(price.Value.Equals(705));
        }
    }
}