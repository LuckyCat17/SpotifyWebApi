using System.Net.Http;

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
                } else
                  {
                    return null;
                   }
            }
        }
    }
}
