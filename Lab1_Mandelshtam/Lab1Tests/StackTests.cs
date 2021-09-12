using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab1Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void EmptyIntStackTest()
        {
            var testStack = new Stack.Stack<int>();
            Assert.AreEqual(testStack.MinValue(), 0);
        }

        [TestMethod]
        public void FirstMinElementTest()
        {
            var testStack = new Stack.Stack<int>();
            testStack.Push(1);
            testStack.Push(5);
            testStack.Push(196);
            Assert.AreEqual(testStack.MinValue(), 1);
        }

        [TestMethod]
        public void LastMinElementTest()
        {
            var testStack = new Stack.Stack<int>();
            testStack.Push(196);
            testStack.Push(12);
            testStack.Push(100);
            testStack.Push(-1);
            Assert.AreEqual(testStack.MinValue(), -1);
        }

        [TestMethod]
        public void RepeatedValuesTest()
        {
            var testStack = new Stack.Stack<int>();
            testStack.Push(-1);
            testStack.Push(1);
            testStack.Push(-1);
            testStack.Pop();
            Assert.AreEqual(testStack.MinValue(), -1);
        }
    }
}