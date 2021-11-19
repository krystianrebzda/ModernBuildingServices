using Measurement.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Measurement.API.GrpcServices
{
    public class MeasurementGrpcService
    {
        private readonly MeasurementProtoService.MeasurementProtoServiceClient _measurementProtoServiceClient;

        public MeasurementGrpcService(MeasurementProtoService.MeasurementProtoServiceClient measurementProtoServiceClient)
        {
            _measurementProtoServiceClient = measurementProtoServiceClient ?? throw new ArgumentNullException(nameof(measurementProtoServiceClient));
        }

        public async Task<TemperaturesResponse> GetTemperatures(string sensorName)
        {
            var temperaturesRequest = new GetTemperaturesRequest() { SensorName = sensorName };

            return await _measurementProtoServiceClient.GetTemperaturesAsync(temperaturesRequest);
        }
    }
}
