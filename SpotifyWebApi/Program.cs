global using SpotifyWebApi.DBContext;
global using Microsoft.EntityFrameworkCore;
using SpotifyWebApi;
using SpotifyWebApi.Controllers;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<TokenDBContext>(options => options.UseSqlServer("Data Source = 104.198.162.41; Initial Catalog = SpotifyWebApi; User ID = provola12345; Password =:dA > Ki * J,l? O8RuV"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//var locale = builder.Configuration["SiteLocale"];
//RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
//{
//};
//localizationOptions.SetDefaultCulture("en");


var app = builder.Build();
//app.UseRequestLocalization(localizationOptions);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

