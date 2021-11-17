using AutoMapper;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Temperature.Grpc.Entities;
using Temperature.Grpc.Protos;
using Temperature.Grpc.Repository;

namespace Temperature.Grpc.Services
{
    public class TemperatureService : TemperatureProtoService.TemperatureProtoServiceBase
    {
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly IMapper _mapper;

        public TemperatureService(ITemperatureRepository temperatureRepository, IMapper mapper)
        {
            _temperatureRepository = temperatureRepository ?? throw new ArgumentNullException(nameof(temperatureRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<SensorTemperaturesResponse> GetSensorTemperatures(GetSensorTemperaturesRequest request, ServerCallContext context)
        {
            var sensorTemperatureResponse = new SensorTemperaturesResponse();

            var sensorTemperatures = await _temperatureRepository.GetSensorTemperatures(request.SensorName);

            var sensorTemperatureModels = _mapper.Map<IEnumerable<SensorTemperature>, IEnumerable<SensorTemperatureModel>>(sensorTemperatures);

            sensorTemperatureResponse.SensorTemperatures.AddRange(sensorTemperatureModels);

            return sensorTemperatureResponse;
        }
    }
}
