using Microsoft.VisualStudio.TestTools.UnitTesting;
using customLinkedList;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void TestRemoveMiddle()
        {
            LinkedList<int> list = new LinkedList<int>(1);
            list.Push(2);
            list.Push(3);
            list.Push(2);
            list.Remove(2);
            Assert.AreEqual(list.StartNode.Next.Next.Value, 3);
        }

        [TestMethod]
        public void TestRemoveBeginning()
        {
            LinkedList<int> list = new LinkedList<int>(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Remove(1);
            Assert.AreEqual(list.StartNode.Next.Value, 2);
        }

        [TestMethod]
        public void TestRemoveEnding()
        {
            var list = new LinkedList<string>("abc");
            list.Push("__");
            list.Push("12");
            list.Push("final");
            list.Remove("final");
            // end node is fictitious
            Assert.AreEqual(list.EndNode.Prev.Value, "12");
        }

        [TestMethod]
        public void TestCount()
        {
            var list = new LinkedList<string>("first");
            list.Push("second");
            Assert.AreEqual(list.Count, 2);
        }
    }
}
