using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpotifyWebApi.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SpotifyWebApi.Controllers
{
    [Route("api/Spotify/Actions")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TokenDBContext _context;

        public ValuesController(TokenDBContext context)
        {
            _context = context; 
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<string> addItemInPlaylist(string playlist_id, string id_brano)
        {
            var NoToken = _context.Tokens.Count();
            if(NoToken <= 0)
            {
               var redirectUri = AuthorizationCodeFlow.RequestUserAuth();
               Redirect(redirectUri.Result.AbsolutePath);
            }
            var token = _context.Tokens.First<Token>();
            if (Token.isExpired(token))
            {
                var tokenToDelete = new Token();
                tokenToDelete = token;
                token = await Token.refreshTokenMethod(token.refresh_token);
                _context.Tokens.Remove(tokenToDelete);
                _context.Tokens.Add(token);
                _context.SaveChanges();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.spotify.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                var item = new Song();
                item.uris[0] = id_brano;
                item.position = 0;
                var stringpaylaod = JsonConvert.SerializeObject(item);
                var httpContent = new StringContent(stringpaylaod, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"https://api.spotify.com/v1/playlists/{playlist_id}/tracks", httpContent);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        [HttpGet]
        [Route("GetSongs")]
        public async Task<string> getItemsFromPlaylist(string playlist_id)
        {
            var token = _context.Tokens.First<Token>();
            if (Token.isExpired(token))
            {
                var tokenToDelete = new Token();
                tokenToDelete = token;
                token = await Token.refreshTokenMethod(token.refresh_token);
                _context.Tokens.Remove(tokenToDelete);
                _context.Tokens.Add(token);
                _context.SaveChanges();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.spotify.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                HttpResponseMessage response = await client.GetAsync($"https://api.spotify.com/v1/playlists/{playlist_id}/tracks");
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }
    }
}
