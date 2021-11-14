﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Temperature.Grpc.Entities;

namespace Temperature.Grpc.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();

                var client = new MongoClient(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:ConnectionString"));
                var database = client.GetDatabase(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:DatabaseName"));
                var collection = database.GetCollection<TemperatureSensor>(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:TemperatureSensorsCollectionName"));

                var data = collection.Find(p => true).Any();

                if (!collection.Find(p => true).Any())
                {
                    collection.InsertManyAsync(GetTemperatureSensors());
                }
            }

            return host;
        }

        private static IEnumerable<TemperatureSensor> GetTemperatureSensors()
        {
            var temperatureSensors = new List<TemperatureSensor>();
            var random = new Random();

            for(int i = 1; i <= 100; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    var sensor = new TemperatureSensor()
                    {
                        SensorName = "Sensor" + i,
                        Value = (decimal)(random.Next(15, 30) + Math.Round(random.NextDouble(), 2)),
                        CreatedDate = DateTime.Now.AddMinutes(100 - j)
                    };

                    temperatureSensors.Add(sensor);
                }
            }

            return temperatureSensors;
        }
    }
}