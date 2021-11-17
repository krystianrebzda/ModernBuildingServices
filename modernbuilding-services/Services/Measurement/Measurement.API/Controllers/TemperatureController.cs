using AutoMapper;
using Measurement.API.Entities;
using Measurement.API.GrpcServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Temperature.Grpc.Protos;

namespace Measurement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureGrpcService _temperatureGrpcService;
        private readonly IMapper _mapper;

        public TemperatureController(TemperatureGrpcService temperatureGrpcService, IMapper mapper)
        {
            _temperatureGrpcService = temperatureGrpcService ?? throw new ArgumentNullException(nameof(temperatureGrpcService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{sensorName}", Name = "GetSensorTemperatures")]
        [ProducesResponseType(typeof(MeasurementData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MeasurementData>> GetSensorTemperatures(string sensorName)
        {
            var measurementData = new MeasurementData();

            var sensorTemperatures = await _temperatureGrpcService.GetSensorTemperatures(sensorName);

            var temperatures = _mapper.Map<Google.Protobuf.Collections.RepeatedField<SensorTemperatureModel> , IEnumerable<TemperatureMeasurement>>(sensorTemperatures.SensorTemperatures);

            measurementData.Temperatures = temperatures;

            return Ok(measurementData);
        }
    }
}
