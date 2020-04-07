using System.IO;
using VitaminKitty.Models;

namespace VitaminKitty.Services
{
    public interface ITwitter
    {
        public void Setup(TwitterConsumer consumer);
        public void Tweet(string message, FileInfo image = null);
    }
}
