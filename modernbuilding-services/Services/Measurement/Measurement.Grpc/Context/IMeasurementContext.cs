using Measurement.Grpc.Entities;
using MongoDB.Driver;

namespace Measurement.Grpc.Context
{
    public interface IMeasurementContext
    {
        IMongoCollection<Temperature> Temperatures { get; }
    }
}
