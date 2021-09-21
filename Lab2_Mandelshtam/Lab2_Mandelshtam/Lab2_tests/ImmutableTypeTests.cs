using System;
using System.Collections.Generic;
using System.Text;
using ImmutableType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_tests
{
    [TestClass]
    public class ImmutableTypeTests
    {
        [TestMethod]
        public void TestImmutableType()
        {
            var dog = new ImmutableDog("Rax");
            var newDog = dog.RenameDog("Tom");
            Assert.AreNotEqual(dog, newDog);
        }
    }
}
