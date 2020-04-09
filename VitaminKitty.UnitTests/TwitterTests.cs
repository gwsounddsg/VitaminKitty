using Moq;
using NUnit.Framework;
using VitaminKitty.Models;
using VitaminKitty.Services;
using VitaminKitty.Wrappers;

namespace VitaminKitty.UnitTests
{
    internal class TwitterTests
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
        public void Setup_Successful()
        {
            twitter.Setup(consumer);

            Assert.That(twitter.Consumer == consumer);
            Assert.That(twitter.Tokens, Is.Not.Null);
        }

        [Test]
        public void Tweet_MessageOnly()
        {
            // prep
            string message = "some message";
            var mTokens = new Mock<TokensWrapper>();
            mTokens.Setup(x => x.Update(message));

            Twitter twitter = new Twitter();
            twitter.Tokens = mTokens.Object;

            // call
            twitter.Tweet(message);

            // verify
            mTokens.Verify(x => x.Update(message), Times.Once);
            mTokens.VerifyNoOtherCalls();
        }
    }
}
