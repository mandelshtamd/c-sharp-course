using System;
using System.Collections;
using System.Collections.Generic;
using Hashtable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_tests
{
    [TestClass]
    public class HashtableTests
    {
        [TestMethod]
        public void FindMethodTest()
        {
            var hashtable = new Hashtable<int, String>();
            hashtable.Put(2, "C#");
            hashtable.Put(1, "C++");
            hashtable.Put(0, "C");
            Assert.AreEqual("C++", hashtable.Get(1));
        }

        [TestMethod]
        public void RemoveMethodTest()
        {
            var hashtable = new Hashtable.Hashtable<string, int>();
            hashtable.Put("usersCount", 5);
            hashtable.Remove("usersCount");
            var exceptionCaught = false;
            try
            {
                hashtable.Get("usersCount");
            }
            catch (KeyNotFoundException)
            {
                Assert.AreEqual(true, true);
                exceptionCaught = true;
            }

            if (!exceptionCaught) { Assert.Fail(); }
        }

        [TestMethod]
        public void SuccessfulExpandTest()
        {
            var hashtable = new Hashtable.Hashtable<string, int>();
            for (int i = 0; i < 5; i++)
            {
                hashtable.Put($"a{i}", i);
            }

            var allIsOk = hashtable.Get("a3") == 3 && hashtable.GetCapacity() == 8;
            Assert.AreEqual(true, allIsOk);
        }
    }
}
