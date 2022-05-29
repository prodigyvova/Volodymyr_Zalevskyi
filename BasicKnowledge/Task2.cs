
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Zalevskyi_tasks
{
    [TestFixture]
    public class Task2
    {

        [Test]
        public void Test1()
        {
           Assert.AreEqual("T", first_non_repeating_letter("sTreSS"));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual("", first_non_repeating_letter("ssakkadpppldl"));
        }

        public string first_non_repeating_letter(string str)
        {
            List<char> repeatingLetters = new List<char>();
            List<char> nonRepeatingLetters = new List<char>();
            
            
            foreach (char letter in str.ToLower())
            {
               if (repeatingLetters.Contains(letter))
                   continue;
               
               if (nonRepeatingLetters.Contains(letter))
               {
                   nonRepeatingLetters.Remove(letter);
                   repeatingLetters.Add(letter);
                   continue;
               }

               nonRepeatingLetters.Add(letter);
            }

            
            if (nonRepeatingLetters.Count() == 0)
                return "";

            return str[str.ToLower().IndexOf(nonRepeatingLetters[0])].ToString();
            
        }
    }
}