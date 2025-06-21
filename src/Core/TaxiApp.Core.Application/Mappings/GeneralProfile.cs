using AutoMapper;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Core.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<Taxi, TaxiDto>();
        CreateMap<TaxiDto, Taxi>();

        CreateMap<Trip, TripDto>();
        CreateMap<TripDto, Trip>();

        CreateMap<TripDetail, TripDetailDto>();
        CreateMap<TripDetailDto, TripDetail>();

        CreateMap<User, UserDto>();
        CreateMap<UserGroup, UserGroupDto>();

        CreateMap<UserGroup, UserGroupDto>();
        CreateMap<UserGroupDto, UserGroup>();

        CreateMap<UserGroupDetail, UserGroupDetailDto>();
        CreateMap<UserGroupDetailDto, UserGroupDetail>();
    }
}