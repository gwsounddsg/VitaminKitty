using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using VitaminKitty.Models;
using VitaminKitty.Services;
using VitaminKitty.Wrappers;

namespace VitaminKitty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitaminKittyController : ControllerBase
    {
        private readonly ICatFact _catFact;
        private readonly IKittyImage _kittyImage;
        private readonly ITwitter _twitter;

        public VitaminKittyController(ICatFact catFact, IKittyImage kittyImage, ITwitter twitter)
        {
            _catFact = catFact;
            _kittyImage = kittyImage;
            _twitter = twitter;
        }

        [HttpGet("catfact")]
        public Fact GetCatFact()
        {
            return _catFact.GetFact();
        }


        [HttpGet("catimage")]
        public Bitmap GetCatImage()
        {
            return _kittyImage.RandomKitty();
        }


        [HttpPost("tweet")]
        public string Tweet([FromBody] TwitterConsumer consumer)
        {
            var fact = GetFact();
            var image = GetImage();

            _twitter.Setup(new TokensWrapper(consumer));
            _twitter.Tweet(fact, image);

            return fact;
        }


        #region Private Methods

        private string GetFact()
        {
            string fact = "";
            const int tweetLimit = 280;

            do { fact = _catFact.GetFact().text; }
            while (fact.Length > tweetLimit);

            return fact;
        }


        private FileInfo GetImage()
        {
            var image = _kittyImage.RandomKitty();
            var location = @"C:\Users\gaming\Pictures\catimage.png";
            image.Save(location);

            return new FileInfo(location);
        }

        #endregion
    }
}