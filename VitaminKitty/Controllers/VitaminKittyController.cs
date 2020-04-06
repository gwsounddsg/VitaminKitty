using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VitaminKitty.Models;
using VitaminKitty.Web;

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
    }
}