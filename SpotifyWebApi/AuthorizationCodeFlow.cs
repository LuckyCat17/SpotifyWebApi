using SpotifyWebApi.Models;
using System.Net.Http;
using System.Text.Json;

namespace SpotifyWebApi

{
    public static class AuthorizationCodeFlow
    {

        public static async Task<Uri> RequestUserAuth()
        {
            using (var client = new HttpClient())
            {
                string state = Utility.genRandomString();
                client.BaseAddress = new Uri("https://accounts.spotify.com/authorize?");
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync($"https://accounts.spotify.com/authorize?client_id={Constants.ClientId}&response_type=code&redirect_uri={Constants.redirectUri}&scope=user-read-private user-read-email playlist-read-collaborative playlist-read-private playlist-modify-public&state={state}");
                if (response.IsSuccessStatusCode)
                {
                    var temp = response.RequestMessage.RequestUri;
                    return temp;
                }
                else
                {
                    return null;
                }
            }
        }

        public static async Task<Token> RefreshToken(string refresh_token)
        {
            using (var client = new HttpClient())
            {
                var Body = new Dictionary<string, string>
                {
                    {"grant_type", "refresh_token" },
                    { "refresh_token", refresh_token }
                };
                var Auth = Utility.Base64Encode(Constants.ClientId + ":" + Constants.clientSecret);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Auth);
                var content = new FormUrlEncodedContent(Body);
                var response = await client.PostAsync("https://accounts.spotify.com/api/token",content);
                var responseString = await response.Content.ReadAsStringAsync();
                var token = JsonSerializer.Deserialize<Token>(responseString);
                return token;
            }   
        }
    }
}
