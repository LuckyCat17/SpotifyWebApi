using Microsoft.AspNetCore.Mvc;
using SpotifyWebApi.DBContext;
using SpotifyWebApi.Models;

namespace SpotifyWebApi.Controllers
{
    [Route("api/Spotify/Auth")]
    [ApiController]
    public class ControllerAuth : Controller
    {

        public static Token token = null;
        private readonly TokenDBContext _context;
        public ControllerAuth(TokenDBContext dbContext)
        {
            _context = dbContext;
        }



        [HttpGet]
        public async Task<RedirectResult> GetAuth()
        {
            var redUri = await AuthorizationCodeFlow.RequestUserAuth();
            return Redirect(redUri.AbsoluteUri);
        }

        [HttpGet]
        [Route("callback")]
        public async Task <string> Index(string code, string state)
        {
            token = await Token.getToken(Constants.grant_type,code,Constants.redirectUri);
            _context.Tokens.Add(token);
            await _context.SaveChangesAsync();
            var temp = Token.isExpired(token);
            return "Added";
        }

    }
}
