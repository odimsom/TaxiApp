using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Core.Application.Interfaces;

public interface ITripService : IGenericService<TripDto, Trip>
{
}
