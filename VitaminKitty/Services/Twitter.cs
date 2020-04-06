using CoreTweet;
using System.IO;
using VitaminKitty.Models;

namespace VitaminKitty.Services
{
    public class Twitter
    {
        private TwitterConsumer _consumer { get; set; }
        private Tokens Tokens { get; set; }

        public Twitter(TwitterConsumer consumer)
        {
            _consumer = consumer;
            Tokens = Tokens.Create(_consumer.ApiKey, _consumer.ApiSecret, _consumer.AccessToken, _consumer.AccessSecret);
        }

        public void Tweet(string message, FileInfo image = null)
        {
            if (Tokens == null)
            {
                return;
            }

            if (image == null)
            {
                Tokens.Statuses.Update(status => message);
            }
            else
            {
                var media = Tokens.Media.Upload(image);
                Tokens.Statuses.Update(status: message, media_ids: new long[] { media.MediaId });
            }
        }
    }
}
