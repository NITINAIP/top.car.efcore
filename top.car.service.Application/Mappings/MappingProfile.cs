using AutoMapper;
using top.car.service.Application.DTOs.ReqForm;
using top.car.service.Domain.Entities;


namespace top.car.service.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarsDetailReq, ReqFormDto>()
            .ForMember(dest => dest.DocumentNo, opt => opt.MapFrom(src => src.DocNo))
            .ForMember(dest => dest.CostComp, opt => opt.MapFrom(src => src.CostComp))
            .ForMember(dest => dest.CarsDetails, opt => opt.MapFrom(src => src.CarsDetailBookings));

        CreateMap<CarsDetailBooking, CarsDetailReqDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.BusinessDoc, opt => opt.MapFrom(src => src.BusinessDocNo))
            .ForMember(dest => dest.ReqType, opt => opt.MapFrom(src => src.ReqType.HasValue ? src.ReqType.Value.ToString() : null))
            .ForMember(dest => dest.ReqFrom, opt => opt.MapFrom(src => src.ReqFrom.HasValue ? src.ReqFrom.Value.ToString() : null))
            .ForMember(dest => dest.TransportType, opt => opt.MapFrom(src => src.TransportType.HasValue ? src.TransportType.Value.ToString() : null))
            .ForMember(dest => dest.Travelers, opt => opt.MapFrom(src => src.CarsDetailTravelers));

        CreateMap<CarsDetailTraveler, CarsDetailTravelerDto>();
    }
}