using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Measurement.Grpc.Entities;
using Measurement.Grpc.Protos;

namespace Measurement.Grpc.Mapper
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<Temperature, TemperatureModel>()
                .ForMember(dest => dest.Value, o => o.MapFrom(src => (double)src.Value))
                .ForMember(dest => dest.CreatedDate, o => o.MapFrom(src => Timestamp.FromDateTime(src.CreatedDate)));
        }
    }
}
