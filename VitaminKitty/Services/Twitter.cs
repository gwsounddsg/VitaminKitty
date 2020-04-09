using System.IO;
using System.Runtime.CompilerServices;
using VitaminKitty.Wrappers;





[assembly: InternalsVisibleTo("VitaminKitty.UnitTests")]
namespace VitaminKitty.Services
{
    public class Twitter : ITwitter
    {
        private ITokensWrapper Tokens { get; set; }

        public void Setup(ITokensWrapper tokens)
        {
            Tokens = tokens;
        }

        public void Tweet(string message, FileInfo image = null)
        {
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
