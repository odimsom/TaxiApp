using AutoMapper;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces;
using TaxiApp.Core.Application.Services.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Core.Domain.Repository;

namespace TaxiApp.Core.Application.Services;

public class TripService : GenericService<TripDto, Trip>, ITripService
{
    private readonly ITripRepository _repository;
    private readonly IMapper _mapper;

    public TripService(ITripRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}