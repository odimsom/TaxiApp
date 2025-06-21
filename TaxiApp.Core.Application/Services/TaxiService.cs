using AutoMapper;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces;
using TaxiApp.Core.Application.Services.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Core.Domain.Repository;

namespace TaxiApp.Core.Application.Services;

public class TaxiService : GenericService<TaxiDto, Taxi>, ITaxiService
{
    private readonly ITaxiRepository _repository;
    private readonly IMapper _mapper;
    
    public TaxiService(ITaxiRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}