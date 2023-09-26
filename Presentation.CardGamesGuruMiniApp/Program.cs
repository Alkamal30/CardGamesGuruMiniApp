using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Services.CardGamesGuruMiniApp.Services.GameService;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GameService)));
builder.Services.AddSingleton<IGameRepository, GameRepository>();
builder.Services.AddSingleton<IGameService, GameService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddConfig();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




