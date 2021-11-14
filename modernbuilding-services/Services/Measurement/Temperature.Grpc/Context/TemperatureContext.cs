using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Temperature.Grpc.Entities;

namespace Temperature.Grpc.Context
{
    public class TemperatureContext : ITemperatureContext
    {
        public IMongoCollection<TemperatureSensor> TemperatureSensors { get; }

        public TemperatureContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:DatabaseName"));

            TemperatureSensors = database.GetCollection<TemperatureSensor>(configuration.GetValue<string>("TemperatureSensorsDatabaseSettings:TemperatureSensors"));
        }
    }
}
