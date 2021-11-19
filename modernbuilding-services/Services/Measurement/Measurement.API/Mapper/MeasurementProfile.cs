using AutoMapper;
using Measurement.API.Entities;
using Measurement.Grpc.Protos;

namespace Measurement.API.Mapper
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<TemperatureModel, Temperature>()
                .ForMember(dest => dest.Value, o => o.MapFrom(src => (decimal)src.Value))
                .ForMember(dest => dest.CreatedDate, o => o.MapFrom(src => src.CreatedDate.ToDateTime()));
        }
    }
}
