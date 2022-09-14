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
        }
       public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

 
}
    
        

