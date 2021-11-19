using AutoMapper;
using Measurement.API.Entities;
using Measurement.API.GrpcServices;
using Measurement.Grpc.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Measurement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly MeasurementGrpcService _measurementGrpcService;
        private readonly IMapper _mapper;

        public TemperatureController(MeasurementGrpcService measurementGrpcService, IMapper mapper)
        {
            _measurementGrpcService = measurementGrpcService ?? throw new ArgumentNullException(nameof(measurementGrpcService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{sensorName}", Name = "GetSensorTemperatures")]
        [ProducesResponseType(typeof(MeasurementData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MeasurementData>> GetSensorTemperatures(string sensorName)
        {
            var measurementData = new MeasurementData();

            var temperaturesModel = await _measurementGrpcService.GetTemperatures(sensorName);

            var temperatures = _mapper.Map<Google.Protobuf.Collections.RepeatedField<TemperatureModel> , IEnumerable<Temperature>>(temperaturesModel.Temperatures);

            measurementData.Temperatures = temperatures;

            return Ok(measurementData);
        }
    }
}
