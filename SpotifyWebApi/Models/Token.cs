using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SpotifyWebApi.Models
{
    [Table("Tokens")]
    public class Token
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public bool is_expired { get; set; }
        public DateTime generated { get; set; }

        public Token()
        {
            generated = new DateTime(2022, 09, 03, 16, 47, 45);
            is_expired = false;
        }


        public static async Task<Token> getToken(string grant_type, string code, string redirect_uri)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    {"grant_type", grant_type },
                    {"code" , code },
                    {"redirect_uri", redirect_uri }
                };

                var Auth = Utility.Base64Encode(Constants.ClientId + ":" + Constants.clientSecret);

                client.BaseAddress = new Uri("https://accounts.spotify.com/api/token");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Auth);
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("https://accounts.spotify.com/api/token", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var Token = JsonSerializer.Deserialize<Token>(responseString);
                return Token;
            }
        }

        public static bool tokenExpired(Token token)
        {
            if (token.is_expired)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isExpired(Token token)
        {
            var temp = token.generated.AddSeconds(3600);
            if (token.generated >= temp)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
