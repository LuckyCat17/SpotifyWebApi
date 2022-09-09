using Microsoft.AspNetCore.Mvc;
using SpotifyWebApi.Models;

namespace SpotifyWebApi.Controllers
{
    [Route("api/Spotify/Auth")]
    [ApiController]
    public class ControllerAuth : Controller
    {
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
        public async Task<HttpResponseMessage> Index(string code, string state)
        {
            var token = await Token.getToken(Constants.grant_type, code, Constants.redirectUri);
            _context.Tokens.Add(token);
            await _context.SaveChangesAsync();
            var message = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                ReasonPhrase = "Token registrato con successo"
            };
            return message;
        }
    }
}
