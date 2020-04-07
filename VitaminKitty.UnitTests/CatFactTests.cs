using NUnit.Framework;
using VitaminKitty.Models;
using VitaminKitty.Services;

namespace VitaminKitty.UnitTests
{
    public class CatFactTests
    {
        private CatFact catFact;

        [SetUp]
        public void Setup()
        {
            catFact = new CatFact();
        }


        [Test]
        public void TestCatFact_GetFact()
        {
            Fact fact = catFact.GetFact();
            Assert.That(fact, Is.Not.Null);
        }
    }
}