using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpotifyWebApi.Controllers
{
    [Route("index")]
    [ApiController]
    public class Index : ControllerBase
    {

        [HttpGet]
        public string Indext()
        {
            return "Hello,Welcome";
        }
    }
}
