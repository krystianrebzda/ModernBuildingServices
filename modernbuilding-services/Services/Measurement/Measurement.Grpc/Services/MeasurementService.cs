using AutoMapper;
using Grpc.Core;
using Measurement.Grpc.Entities;
using Measurement.Grpc.Protos;
using Measurement.Grpc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Measurement.Grpc.Services
{
    public class MeasurementService : MeasurementProtoService.MeasurementProtoServiceBase
    {
        private readonly IReadOnlyTemperatureRepository _temperatureRepository;
        private readonly IMapper _mapper;

        public MeasurementService(IReadOnlyTemperatureRepository temperatureRepository, IMapper mapper)
        {
            _temperatureRepository = temperatureRepository ?? throw new ArgumentNullException(nameof(temperatureRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<TemperaturesResponse> GetTemperatures(GetTemperaturesRequest request, ServerCallContext context)
        {
            var temperatureResponse = new TemperaturesResponse();

            var temperatures = await _temperatureRepository.GetTemperatures(request.SensorName);

            var temperatureModels = _mapper.Map<IEnumerable<Temperature>, IEnumerable<TemperatureModel>>(temperatures);

            temperatureResponse.Temperatures.AddRange(temperatureModels);

            return temperatureResponse;
        }
    }
}
