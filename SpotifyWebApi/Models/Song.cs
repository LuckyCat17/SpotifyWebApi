namespace SpotifyWebApi.Models
{
    public class Song
    {
        public string[] uris { get; set; }
        public int position { get; set; }

        public Song()
        {
            uris = new string[1];
        }
    }
}
