using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Temperature.Grpc.Entities;

namespace Temperature.Grpc.Context
{
    public class TemperatureContext : ITemperatureContext
    {
        public IMongoCollection<SensorTemperature> SensorTemperatures { get; }

        public TemperatureContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:DatabaseName"));

            SensorTemperatures = database.GetCollection<SensorTemperature>(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:SensorTemperatureCollectionName"));
        }
    }
}
