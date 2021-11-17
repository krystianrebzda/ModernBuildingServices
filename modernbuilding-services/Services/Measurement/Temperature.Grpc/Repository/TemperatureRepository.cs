using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Temperature.Grpc.Context;
using Temperature.Grpc.Entities;

namespace Temperature.Grpc.Repository
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly ITemperatureContext _temperatureContext;

        public TemperatureRepository(ITemperatureContext temperatureContext)
        {
            _temperatureContext = temperatureContext ?? throw new ArgumentNullException(nameof(temperatureContext));
        }

        public async Task<IEnumerable<SensorTemperature>> GetSensorTemperatures(string sensorName)
        {
            var filter = Builders<SensorTemperature>.Filter.Eq(x => x.SensorName, sensorName);

            return await _temperatureContext.SensorTemperatures.Find(filter).ToListAsync();
        }
    }
}
