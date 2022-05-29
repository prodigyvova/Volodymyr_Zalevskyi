using System;
using NUnit.Framework;

namespace Zalevskyi_tasks
{
    [TestFixture]
    public class Task3
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, DigitalRoot(1));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(6, DigitalRoot(132189));
        }

        private static int DigitalRoot(int number)
        {
            while (number >= 10)
            {
                var digitsAmount = (int) Math.Log10(number) + 1;
                var nextNumber = 0;
                for (var i = 0; i < digitsAmount; i++)
                {
                    nextNumber += (int) (number % 10);
                    number /= 10;
                }

                number = nextNumber;
            }

            return number;
        }
        
        
    }
}