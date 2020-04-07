using NUnit.Framework;
using System.Drawing;
using VitaminKitty.Services;

namespace VitaminKitty.UnitTests
{
    class KittyImageTests
    {
        private KittyImage kittyImage;

        [SetUp]
        public void Setup()
        {
            kittyImage = new KittyImage();
        }

        [Test]
        public void TestKittyImage_RandomKitty()
        {
            Bitmap image = kittyImage.RandomKitty();
            Assert.That(image, Is.Not.Null);
        }
    }
}
