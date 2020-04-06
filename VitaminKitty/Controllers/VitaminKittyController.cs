using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using VitaminKitty.Models;
using VitaminKitty.Services;

namespace VitaminKitty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitaminKittyController : ControllerBase
    {
        [HttpGet("catfact")]
        public Fact GetCatFact()
        {
            ICatFact fact = new CatFact();
            return fact.GetFact();
        }


        [HttpGet("catimage")]
        public Bitmap GetCatImage()
        {
            IKittyImage image = new KittyImage();
            return image.RandomKitty();
        }


        [HttpPost("tweet")]
        public string Tweet([FromBody] TwitterConsumer consumer)
        {
            var fact = GetFact();
            var image = GetImage();

            Twitter twitter = new Twitter(consumer);
            twitter.Tweet(fact, image);

            return fact;
        }


        #region Private Methods

        private string GetFact()
        {
            string fact = "";
            const int tweetLimit = 280;

            do { fact = GetCatFact().text; }
            while (fact.Length > tweetLimit);

            return fact;
        }


        private FileInfo GetImage()
        {
            var image = GetCatImage();
            var location = @"C:\Users\gaming\Pictures\catimage.png";
            image.Save(location);

            return new FileInfo(location);
        }

        #endregion
    }
}