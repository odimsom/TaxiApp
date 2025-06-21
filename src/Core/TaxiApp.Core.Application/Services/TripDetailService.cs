using AutoMapper;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces;
using TaxiApp.Core.Application.Services.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Core.Domain.Repository;

namespace TaxiApp.Core.Application.Services;

public class TripDetailService : GenericService<TripDetailDto, TripDetail>, ITripDetailService
{
    private readonly ITripDetailRepository _repository;
    private readonly IMapper _mapper;
    
    public TripDetailService(ITripDetailRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}