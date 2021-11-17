using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temperature.Grpc.Entities;

namespace Temperature.Grpc.Repository
{
    public interface ITemperatureRepository
    {
        Task<IEnumerable<SensorTemperature>> GetSensorTemperatures(string sensorName);
    }
}
