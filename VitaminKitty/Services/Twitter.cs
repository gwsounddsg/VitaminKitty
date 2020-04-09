using CoreTweet;
using System.IO;
using System.Runtime.CompilerServices;
using VitaminKitty.Models;
using VitaminKitty.Wrappers;





[assembly: InternalsVisibleTo("VitaminKitty.UnitTests")]
namespace VitaminKitty.Services
{
    public class Twitter: ITwitter
    {
        internal TwitterConsumer Consumer { get; set; }
        internal TokensWrapper Tokens { get; set; }

        public void Setup(TwitterConsumer consumer, TokensWrapper tokens = null)
        {
            Consumer = consumer;

            if (tokens == null)
            {
                Tokens = new TokensWrapper();
                Tokens.Create(consumer);
            }
            else
            {
                Tokens = tokens;
            }
        }

        public void Tweet(string message, FileInfo image = null)
        {
            if (Tokens == null)
            {
                return;
            }

            if (image == null)
            {
                Tokens.Update(message);
            }
            else
            {
                var media = Tokens.UpdateMedia(image);
                Tokens.Update(message, new long[] { media.MediaId });
            }
        }
    }
}
