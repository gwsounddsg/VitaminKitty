using NUnit.Framework;
using VitaminKitty.Models;
using VitaminKitty.Services;

namespace VitaminKitty.UnitTests
{
    class TwitterTests
    {
        private TwitterConsumer consumer;
        private Twitter twitter;

        [SetUp]
        public void Setup()
        {
            twitter = new Twitter();
            consumer = new TwitterConsumer
            {
                ApiKey = "apikey",
                ApiSecret = "apisecret",
                AccessToken = "accesstoken",
                AccessSecret = "accesssecrete"
            };
        }


        [Test]
        public void TestTwitter_Setup()
        {
            twitter.Setup(consumer);

            Assert.That(twitter.Consumer == consumer);
            Assert.That(twitter.Tokens, Is.Not.Null);
        }
    }
}
