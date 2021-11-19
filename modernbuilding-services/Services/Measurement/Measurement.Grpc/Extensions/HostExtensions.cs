using Measurement.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Measurement.Grpc.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();

                var client = new MongoClient(configuration.GetValue<string>("TemperaturesDatabaseSettings:ConnectionString"));
                var database = client.GetDatabase(configuration.GetValue<string>("TemperaturesDatabaseSettings:DatabaseName"));
                var collection = database.GetCollection<Temperature>(configuration.GetValue<string>("TemperaturesDatabaseSettings:TemperatureCollectionName"));

                var data = collection.Find(p => true).Any();

                if (!collection.Find(p => true).Any())
                {
                    collection.InsertManyAsync(GetTemperatureSensors());
                }
            }

            return host;
        }

        private static IEnumerable<Temperature> GetTemperatureSensors()
        {
            var temperatureSensors = new List<Temperature>();
            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var sensor = new Temperature()
                    {
                        SensorName = "Sensor" + i,
                        Value = (decimal)(random.Next(15, 30) + Math.Round(random.NextDouble(), 2)),
                        CreatedBy = "Temperature.Grpc.Seed",
                        CreatedDate = DateTime.Now.AddMinutes(100 - j)
                    };

                    temperatureSensors.Add(sensor);
                }
            }

            return temperatureSensors;
        }
    }
}
