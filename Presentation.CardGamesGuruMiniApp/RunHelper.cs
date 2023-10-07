using Domain.CardGamesGuruMiniApp.Configuration;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using React.AspNet;
using Services.CardGamesGuruMiniApp.Services.GameService;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;
using Services.CardGamesGuruMiniApp.Services.TodService;
using Services.CardGamesGuruMiniApp.Services.TodService.Interfaces;
using Services.CardGamesGuruMiniApp.Services.TotService;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;
using System.Text.Json.Serialization;

namespace WebApp
{
    public static class RunHelper
    {
        public static void AddConfig(this IServiceCollection services)
        {
            services.AddApplicationOptions<MongoDbOptions>(nameof(MongoDbOptions));
            services.AddMongoDatabase();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GameService)));

            services.AddTransient<ITotRepository, TotRepository>();
            services.AddTransient<ITotService, TotService>();

            services.AddTransient<ITodRepository, TodRepository>();
            services.AddTransient<ITodService, TodService>();

            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IGameService, GameService>();

            services.AddAutoMapper(typeof(Program));
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });

            //services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CardGamesGuruMiniApp API",
                    Description = "An ASP.NET Core Web API for managing CardGamesGuruMiniApp items",
                    Contact = new OpenApiContact
                    {
                        Name = "Contacts",
                        Url = new Uri("https://t.me/EvoMorphey")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://github.com/Alkamal30/CardGamesGuruMiniApp/blob/main/LICENSE")
                    }
                });
            });
        }

        private static IServiceCollection AddApplicationOptions<TOptions>(
            this IServiceCollection services,
            string key = null)
            where TOptions : class
        {
            services.AddSingleton<IConfigureOptions<TOptions>>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                if (key != null)
                {
                    config = config.GetSection(key);
                }

                return new BindOptions<TOptions>(config);
            });

            return services;
        }

        private static void AddMongoDatabase(this IServiceCollection services)
        {
            services
                .AddSingleton<IMongoClient, MongoClient>(serviceProvider =>
                    new MongoClient(serviceProvider.GetRequiredService<IOptions<MongoDbOptions>>().Value.ConnectionString))
                .AddSingleton<IMongoDatabase>(serviceProvider => serviceProvider
                    .GetRequiredService<IMongoClient>()
                    .GetDatabase(serviceProvider.GetRequiredService<IOptions<MongoDbOptions>>().Value.DatabaseName));

            RegisterMongoMappings();
        }

        private static void RegisterMongoMappings()
        {
            BsonClassMap.RegisterClassMap<GameBson>();
        }
    }

    public class BindOptions<TOptions> : IConfigureOptions<TOptions> where TOptions : class
    {
        private readonly IConfiguration _config;

        public BindOptions(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException();
        }

        public void Configure(TOptions options)
        {
            _config.Bind(options);
        }
    }
}