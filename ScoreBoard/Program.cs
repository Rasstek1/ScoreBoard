using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


// Add this line to retrieve the configuration
var configuration = builder.Configuration;


// Use the configuration to configure the database context
builder.Services.AddDbContext<ScoreBoardDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ScoreBoardDbContextConnection"]);
});

builder.Services.AddScoped<IJoueurRepository, ScoreBoardRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");




app.Run();
