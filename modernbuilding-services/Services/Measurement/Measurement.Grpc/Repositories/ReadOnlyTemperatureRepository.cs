using Measurement.Grpc.Context;
using Measurement.Grpc.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Measurement.Grpc.Repositories
{
    public class ReadOnlyTemperatureRepository : IReadOnlyTemperatureRepository
    {
        private readonly IMeasurementContext _measurementContext;

        public ReadOnlyTemperatureRepository(IMeasurementContext measurementContext)
        {
            _measurementContext = measurementContext ?? throw new ArgumentNullException(nameof(measurementContext));
        }

        public async Task<IEnumerable<Temperature>> GetTemperatures(string sensorName)
        {
            var filter = Builders<Temperature>.Filter.Eq(x => x.SensorName, sensorName);

            return await _measurementContext.Temperatures.Find(filter).ToListAsync();
        }
    }
}
