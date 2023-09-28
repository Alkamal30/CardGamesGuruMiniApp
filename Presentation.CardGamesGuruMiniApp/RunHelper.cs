using Domain.CardGamesGuruMiniApp.Configuration;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Infrastructure.CardGamesGuruMiniApp.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;
using Services.CardGamesGuruMiniApp.Services.GameService;
using System.Transactions;
using System.Text.Json.Serialization;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;
using Services.CardGamesGuruMiniApp.Services.TotService;

namespace WebApp
{
    public static class RunHelper
    {
        public static void AddConfig(this IServiceCollection services)
        {
            services.AddApplicationOptions<MongoDbOptions>(nameof(MongoDbOptions));
            services.AddMongoDatabase();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GameService)));

            services.AddSingleton<ITotRepository, TotRepository>();
            services.AddSingleton<ITotService, TotService>();

            services.AddSingleton<IGameRepository, GameRepository>();
            services.AddSingleton<IGameService, GameService>();
            services.AddAutoMapper(typeof(Program));
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
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
