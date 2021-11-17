using AutoMapper;
using Measurement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temperature.Grpc.Protos;

namespace Measurement.API.Mapper
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<SensorTemperatureModel, TemperatureMeasurement>()
                .ForMember(dest => dest.Value, o => o.MapFrom(src => (decimal)src.Value))
                .ForMember(dest => dest.CreatedDate, o => o.MapFrom(src => src.CreatedDate.ToDateTime()));
        }
    }
}
