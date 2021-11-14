using MongoDB.Driver;
using Temperature.Grpc.Entities;

namespace Temperature.Grpc.Context
{
    public interface ITemperatureContext
    {
        IMongoCollection<TemperatureSensor> TemperatureSensors { get; }
    }
}
