using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1Tests
{
    [TestClass]
    public class HashtableTests
    {
        [TestMethod]
        public void FindMethodTest()
        {
            var hashtable = new Hashtable.Hashtable<int, string>();
            hashtable.Add(2, "C#");
            hashtable.Add(1, "C++");
            hashtable.Add(0, "C");
            Assert.AreEqual("C++", hashtable.Find(1));
        }

        [TestMethod]
        public void RemoveMethodTest()
        {
            var hashtable = new Hashtable.Hashtable<string, int>();
            hashtable.Add("usersCount", 5);
            hashtable.Remove("usersCount");
            var exceptionCaught = false;
            try
            {
                hashtable.Find("usersCount");
            }
            catch (KeyNotFoundException)
            {
                Assert.AreEqual(true, true);
                exceptionCaught = true;
            }

            if (!exceptionCaught) { Assert.Fail(); }
        }
    }
}
