using Domain.CardGamesGuruMiniApp.Configuration;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Transactions;

namespace WebApp
{
    public static class RunHelper
    {
        public static void AddConfig(this IServiceCollection services)
        {
            services.AddApplicationOptions<MongoDbOptions>(nameof(MongoDbOptions));
            services.AddMongoDatabase();
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
