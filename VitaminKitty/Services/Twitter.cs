using CoreTweet;
using System.IO;
using VitaminKitty.Models;

namespace VitaminKitty.Services
{
    public class Twitter: ITwitter
    {
        private TwitterConsumer Consumer { get; set; }
        private Tokens Tokens { get; set; }

        public void Setup(TwitterConsumer consumer)
        {
            Consumer = consumer;
            Tokens = Tokens.Create(Consumer.ApiKey, Consumer.ApiSecret, Consumer.AccessToken, Consumer.AccessSecret);
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
