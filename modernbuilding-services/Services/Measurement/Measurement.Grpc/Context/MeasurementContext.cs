using Measurement.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Measurement.Grpc.Context
{
    public class MeasurementContext : IMeasurementContext
    {
        public IMongoCollection<Temperature> Temperatures { get; }

        public MeasurementContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("TemperaturesDatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("TemperaturesDatabaseSettings:DatabaseName"));

            Temperatures = database.GetCollection<Temperature>(configuration.GetValue<string>("TemperaturesDatabaseSettings:TemperatureCollectionName"));
        }
    }
}
