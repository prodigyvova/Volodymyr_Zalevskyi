using System;
using System.Linq;
using NUnit.Framework;

namespace Zalevskyi_tasks
{
    [TestFixture]
    public class ExtraTask1
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(21, NextBigger(12));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(531, NextBigger(513));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(2071, NextBigger(2017));
        }
        
        [Test]
        public void Test4()
        {
            Assert.AreEqual(-1, NextBigger(9));
        }
        
        [Test]
        public void Test5()
        {
            Assert.AreEqual(-1, NextBigger(111));
        }
        
        [Test]
        public void Test6()
        {
            Assert.AreEqual(-1, NextBigger(531));
        }

        private static int NextBigger(int number)
        {
            int[] digits = number.ToString().Select(t=>int.Parse(t.ToString())).ToArray();

            if (digits.Length == 1)
                return -1;

            var index = 1;
            for (var i = digits.Length-1; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    index = i;
                    break;
                }
            }

            if (index == 1 && digits[index] <= digits[index - 1])
                return -1;

            var temp = digits[index - 1];
            var smallestDigit = index;
            for (var i = index+1; i<digits.Length; i++)
                if (digits[i] > temp && digits[i] < digits[smallestDigit])
                    smallestDigit = i;

            temp = digits[smallestDigit];
            digits[smallestDigit] = digits[index - 1] ;
            digits[index - 1] = temp;

            var result = 0;
            for (int i = 0; i < index; i++)
            {
                result = result * 10 + digits[i];
            }

            int[] tempArr = new int[digits.Length-index];
            for (int i = index; i < digits.Length; i++)
            {
                tempArr[i-index] = digits[i];
            }

            Array.Sort(tempArr);
            
            for (int i = 0; i < tempArr.Length; i++)
            {
                result = result * 10 + tempArr[i];
            }

            return result;

        }
    }
}