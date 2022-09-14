global using SpotifyWebApi.DBContext;
global using Microsoft.EntityFrameworkCore;
using SpotifyWebApi;
using SpotifyWebApi.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace SpotifyWebApi
{
    public class Program
    {
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
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
       public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Program>();
                });
    }

 
}
    
        

