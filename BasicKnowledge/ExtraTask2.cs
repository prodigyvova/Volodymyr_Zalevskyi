using System;
using System.Linq;
using NUnit.Framework;

namespace Zalevskyi_tasks
{
    [TestFixture]
    public class ExtraTask2
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("128.32.10.1", NumberToIPv4(2149583361));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("0.0.0.32", NumberToIPv4(32));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual("0.0.0.0", NumberToIPv4(0));
        }

        private static String NumberToIPv4(uint number)
        {
            int[] binaryArray = new int[32];
            for (int i = 31; i >= 0; i--)
            {
                var pow2i = (uint) Math.Pow(2, i);
                if (number >= pow2i)
                {
                    number -= pow2i;
                    binaryArray[i] = 1;
                }
            }
            
            int[] resultArr = new int[4];
            for (int i = 0; i < 32; i++)
            {
                if (binaryArray[i] == 1)
                {
                    resultArr[3 - i / 8] = resultArr[3 - i / 8] + (int) Math.Pow(2, i - i / 8 * 8);
                }
            }

            return (resultArr[0].ToString() + '.' + resultArr[1].ToString() + '.' + resultArr[2].ToString() + '.' + resultArr[3].ToString());
        }
    }
}