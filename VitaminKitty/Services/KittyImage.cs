using System.Drawing;
using System.IO;
using System.Net;

namespace VitaminKitty.Services
{
    public class KittyImage : IKittyImage
    {
        // last two numbers are for width and height
        private readonly string _url = "http://placekitten.com/200/300";

        public Bitmap RandomKitty()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(_url);
            Bitmap bitmap = new Bitmap(stream);

            // clean up
            stream.Flush();
            stream.Close();
            client.Dispose();

            return bitmap;
        }
    }
}
