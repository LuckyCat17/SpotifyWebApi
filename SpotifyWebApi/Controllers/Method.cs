using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpotifyWebApi.Controllers
{
    [Route("api/Spotify/Method")]
    [ApiController]
    public class Method : ControllerBase
    {
        private readonly TokenDBContext _context;
        public Method(TokenDBContext dbContext)
        {
            _context = dbContext;
        }

    }
}
