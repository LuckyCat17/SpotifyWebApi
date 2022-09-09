using SpotifyWebApi.Models;

namespace SpotifyWebApi.DBContext
{
    public class TokenDBContext : DbContext
    {
        public TokenDBContext(DbContextOptions<TokenDBContext> options) : base(options) { }
        public DbSet<Token> Tokens { get; set; }

    }
}
