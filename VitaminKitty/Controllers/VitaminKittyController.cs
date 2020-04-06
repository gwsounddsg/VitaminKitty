using System;
using System.Collections.Generic;
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
    }
}