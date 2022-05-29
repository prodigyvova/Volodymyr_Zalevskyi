using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Zalevskyi_tasks
{
    [TestFixture]
    public class Task1
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(new List<int>() { 1, 2 }, GetIntegersFromList(new List<object>() { 1, 2, "a", "b" }));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(new List<int>() { 1, 2, 0, 15 }, GetIntegersFromList(new List<object>() { 1, 2, "a", "b", 0, 15, "123"}));
        }

        private static List<int> GetIntegersFromList(List<object> list)
        {
            return list.OfType<int>().ToList();
        }
    }
}