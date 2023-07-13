using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScoreBoard.Models;
using ScoreBoard.Repositories;
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

builder.Services.AddScoped<IJoueurRepository, JoueurRepository>();
builder.Services.AddScoped<IJeuRepository, JeuRepository>();

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



 InitialiseurBD.Seed(app);





app.Run();
