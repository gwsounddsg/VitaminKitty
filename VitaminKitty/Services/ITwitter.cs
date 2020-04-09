using System.IO;
using VitaminKitty.Models;
using VitaminKitty.Wrappers;

namespace VitaminKitty.Services
{
    public interface ITwitter
    {
        public void Setup(ITokensWrapper token);
        public void Tweet(string message, FileInfo image = null);
    }
}
