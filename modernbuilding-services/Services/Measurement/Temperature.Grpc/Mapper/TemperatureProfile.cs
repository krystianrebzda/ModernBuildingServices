using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Temperature.Grpc.Entities;
using Temperature.Grpc.Protos;

namespace Temperature.Grpc.Mapper
{
    public class TemperatureProfile : Profile
    {
        public TemperatureProfile()
        {
            CreateMap<SensorTemperature, SensorTemperatureModel>()
                .ForMember(dest => dest.Value, o => o.MapFrom(src => (double)src.Value))
                .ForMember(dest => dest.CreatedDate, o => o.MapFrom(src => Timestamp.FromDateTime(src.CreatedDate)));
        }
    }
}
