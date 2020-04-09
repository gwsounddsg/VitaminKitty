using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using VitaminKitty.Models;
using VitaminKitty.Services;
using VitaminKitty.Wrappers;

namespace VitaminKitty.Controllers
{
    /// <summary>
    /// Vitamin Kitty controller for GET/POST, managing getting kitty data and posting to you twitter account
    /// </summary>
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

        /// <summary>
        /// Gets a random cat fact.
        /// </summary>
        /// <returns>Fact</returns>
        [HttpGet("catfact")]
        public Fact GetCatFact()
        {
            return _catFact.GetFact();
        }


        /// <summary>
        /// Gets the daily cat image.
        /// </summary>
        /// <returns>Bitmap</returns>
        [HttpGet("catimage")]
        public Bitmap GetCatImage()
        {
            return _kittyImage.RandomKitty();
        }


        /// <summary>
        /// Gets a random cat fact limited to 280 characters, gets the daily cat image, and posts to your twitter account.
        /// </summary>
        /// <param name="consumer"></param>
        /// <returns>A string of the fact posted.</returns>
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