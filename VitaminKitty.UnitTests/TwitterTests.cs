using CoreTweet;
using Moq;
using NUnit.Framework;
using System.IO;
using VitaminKitty.Models;
using VitaminKitty.Services;
using VitaminKitty.Wrappers;

namespace VitaminKitty.UnitTests
{
    internal class TwitterTests
    {
        private TwitterConsumer consumer { get; set; }
        private Twitter twitter { get; set; }
        private Mock<ITokensWrapper> mTokens { get; set; }

        [SetUp]
        public void Setup()
        {
            twitter = new Twitter();
            mTokens = new Mock<ITokensWrapper>();
            consumer = new TwitterConsumer
            {
                ApiKey = "apikey",
                ApiSecret = "apisecret",
                AccessToken = "accesstoken",
                AccessSecret = "accesssecrete"
            };
        }

        [Test]
        public void Tweet_MessageOnly()
        {
            // prep
            string message = "some message";
            mTokens.Setup(x => x.Update(message));
            twitter.Setup(mTokens.Object);

            // call
            twitter.Tweet(message);

            // verify
            mTokens.Verify(x => x.Update(message), Times.Once);
            mTokens.VerifyNoOtherCalls();
        }

        [Test]
        public void Tweet_WithImage()
        {
            // prep
            string message = "some message";
            FileInfo image = new FileInfo("file name");
            MediaUploadResult mediaID = new MediaUploadResult();
            mediaID.MediaId = 12345;

            mTokens.Setup(x => x.UpdateMedia(image)).Returns(mediaID);
            mTokens.Setup(x => x.Update(message, new long[] { mediaID.MediaId }));

            twitter.Setup(mTokens.Object);

            // call
            twitter.Tweet(message, image);

            // verify
            mTokens.Verify(x => x.UpdateMedia(image));
            mTokens.Verify(x => x.Update(message, new long[] { mediaID.MediaId }));
            mTokens.VerifyNoOtherCalls();
        }
    }
}
