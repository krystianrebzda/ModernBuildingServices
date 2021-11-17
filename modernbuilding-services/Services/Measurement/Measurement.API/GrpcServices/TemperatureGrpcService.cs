using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temperature.Grpc.Protos;

namespace Measurement.API.GrpcServices
{
    public class TemperatureGrpcService
    {
        private readonly TemperatureProtoService.TemperatureProtoServiceClient _temperatureProtoServiceClient;

        public TemperatureGrpcService(TemperatureProtoService.TemperatureProtoServiceClient temperatureProtoServiceClient)
        {
            _temperatureProtoServiceClient = temperatureProtoServiceClient ?? throw new ArgumentNullException(nameof(temperatureProtoServiceClient));
        }

        public async Task<SensorTemperaturesResponse> GetSensorTemperatures(string sensorName)
        {
            var sensorTemperaturesRequest = new GetSensorTemperaturesRequest() { SensorName = sensorName };

            return await _temperatureProtoServiceClient.GetSensorTemperaturesAsync(sensorTemperaturesRequest);
        }
    }
}
