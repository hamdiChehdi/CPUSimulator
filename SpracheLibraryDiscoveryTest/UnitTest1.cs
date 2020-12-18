using NUnit.Framework;
using Sprache;

namespace SpracheLibraryDiscoveryTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Parser<string> identifier =
                from leading in Parse.WhiteSpace.Many()
                from first in Parse.Letter.Once().Text()
                from rest in Parse.LetterOrDigit.Many().Text()
                from trailing in Parse.WhiteSpace.Many()
                select first + rest;

            Parser<string[]> MOV =
                from instruction in Parse.String("MOV")
                from space in Parse.WhiteSpace.Once()
                from r1 in Parse.Char('R').Once()
                from rn1 in Parse.Number
                from comma in Parse.Char(',').Once()
                from r2 in Parse.Char('R').Once()
                from rn2 in Parse.Number
                select new string[] {rn1, rn2 };

            var v1 = MOV.TryParse(" abc123  ");
            v1 = MOV.TryParse("MOV R10,R17");
            Assert.Pass();
        }
    }
}