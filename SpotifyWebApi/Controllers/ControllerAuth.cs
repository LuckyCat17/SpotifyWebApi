using Microsoft.AspNetCore.Mvc;
using SpotifyWebApi.Models;

namespace SpotifyWebApi.Controllers
{
    [Route("api/Spotify/Auth")]
    [ApiController]
    public class ControllerAuth : Controller
    {
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
            var token = await Token.getToken(Constants.grant_type,code,Constants.redirectUri);
            var temp = "tutto ok";
            return temp;
        }

    }
}
