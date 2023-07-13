using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


// Add this line to retrieve the configuration
var configuration = builder.Configuration;


var connectionString = Environment.MachineName == "RasstekHome"
    ? configuration.GetConnectionString("ScoreBoardDbContextConnection1")
    : configuration.GetConnectionString("ScoreBoardDbContextConnection2");

// Use the configuration to configure the database context
builder.Services.AddDbContext<ScoreBoardDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ScoreBoardDbContextConnection")));

builder.Services.AddScoped<IJoueurRepository, ScoreBoardRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");




app.Run();
