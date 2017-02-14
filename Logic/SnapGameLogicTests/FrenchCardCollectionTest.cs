using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapGameLogic.Cards;
using System.Collections.Generic;

namespace SnapGameLogicTests
{
    [TestClass]
    public class FrenchCardCollectionTest
    {
        [TestMethod]
        public void TestGetCardTypes()
        {
            var target = new FrenchCardCollection();
            var result = target.GetCardTypes();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(52, result.Count);
        }

        [TestMethod]
        public void TestGenerateCards()
        {
            var target = new FrenchCardCollection();
            Assert.IsTrue(target.GenerateCards());
            Assert.IsNotNull(target.PopNextCard());
            Assert.IsTrue(target.Count > 0);
            Assert.AreEqual(52, target.Count);
        }
    }
}
