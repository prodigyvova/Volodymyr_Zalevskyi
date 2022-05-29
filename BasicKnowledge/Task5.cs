using System;
using NUnit.Framework;

namespace Zalevskyi_tasks
{
    [TestFixture]
    public class Task5
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)", SortInvitation("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill"));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual("(BROWN, TONY)(CORWILL, ALEX)(CORWILL, FRED)(CORWILL, FRED)", SortInvitation("Fred:Corwill;Fred:Corwill;Alex:Corwill;Tony:Brown"));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual("", SortInvitation(""));
        }

        private static string SortInvitation(string invitation)
        {
            if (invitation == "")
                return invitation;
            
            string[] invitationArray = invitation.Split(";");
            for (int i = 0; i < invitationArray.Length; i++)
            {
                var person = invitationArray[i].Split(":");
                invitationArray[i] = person[1].ToUpper() + ", " + person[0].ToUpper();
            }
            
            Array.Sort(invitationArray);
            var resultString = "";
            foreach (var person in invitationArray)
            {
                resultString += "(" + person + ")";
            }

            return resultString;
        }
    }
}