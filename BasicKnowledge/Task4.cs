using System;
using System.Linq;
using NUnit.Framework;

namespace Zalevskyi_tasks
{
    [TestFixture]
    public class Task4
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(4, NumberOfPairs(5, new int[] {1, 3, 6, 2, 2, 0, 4, 5}));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(1, NumberOfPairs(10, new int[] {1, 3, 6, 2, 2, 0, 4, 5}));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual(0, NumberOfPairs(10, new int[] {10}));
        }

        private static int NumberOfPairs(int target, int[] array)
        {
            array = array.Where(element => element <= target).ToArray();
            var result = 0;
            for (var i = 0; i < array.Length; i++)
                for (var j = i + 1; j < array.Length; j++)
                    result = (array[i] + array[j] == target) ? result + 1 : result;

            return result;
        }
    }
}