using System.Text;

namespace SpotifyWebApi
{
    public class Utility
    {
        public static string genRandomString()
        {
            int length = 16;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //public static bool checkToken(Token token)
        //{
        //    var flag = false;
        //    var startTimeSpan = TimeSpan.Zero;
        //    var periodTimeSpawn = TimeSpan.FromMinutes(5);
        //    var timer = new System.Threading.Timer((e) =>
        //    {
        //         flag = isExpired(token);
        //   }, null, startTimeSpan, periodTimeSpawn
        //    );
        //    return flag;
        //}

    }
}
