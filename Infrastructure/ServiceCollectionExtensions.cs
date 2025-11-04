using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ListaTelefonica.APIAna.Models;
using System;

namespace ListaTelefonica.APIAna.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("MongoDbSettings");
            services.Configure<MongoDbSettings>(section);

            var settings = section.Get<MongoDbSettings>();
            if (settings == null) throw new ArgumentException("MongoDbSettings not configured in appsettings.json");

            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            services.AddSingleton(client);
            services.AddSingleton(db);
            services.AddSingleton(sp =>
                sp.GetRequiredService<IMongoDatabase>().GetCollection<Contato>(settings.ContatosCollectionName)
            );

            return services;
        }
    }
}
