using Measurement.Grpc.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Measurement.Grpc.Repositories
{
    public interface IReadOnlyTemperatureRepository
    {
        Task<IEnumerable<Temperature>> GetTemperatures(string sensorName);
    }
}
