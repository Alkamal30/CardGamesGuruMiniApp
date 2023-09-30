using React.AspNet;
using WebApp;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyModel;
using Serilog.Extensions.Logging;
using Serilog.Settings.Configuration;

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddConfig();
    builder.Services.AddSingleton<ILoggerProvider>(sp =>
    {
        var functionDependencyContext = DependencyContext.Load(typeof(Program).Assembly);

        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        .Build();

        var logger = new LoggerConfiguration()
            // Read from appsettings.json
            .ReadFrom.Configuration(configuration)
            // Create the actual logger
            .CreateLogger();

        return new SerilogLoggerProvider(logger, dispose: true);
    });

    var app = builder.Build();
    app.UseDeveloperExceptionPage();

    app.UseReact(config => { });
    app.UseDefaultFiles();
    app.UseStaticFiles();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    
    app.UseHttpsRedirection();
    app.UseRouting();
    
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();


}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


