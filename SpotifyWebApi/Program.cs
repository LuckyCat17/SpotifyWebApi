global using Microsoft.EntityFrameworkCore;
global using SpotifyWebApi.DBContext;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddDbContext<TokenDBContext>(options => options.UseSqlServer("Data Source = 104.198.162.41; Initial Catalog = SpotifyWebApi; User ID = provola12345; Password =vL88/6X@Z*9PMGT<"));
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}