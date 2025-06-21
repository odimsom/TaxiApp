using TaxiApp.Core.Domain.Entities;
using TaxiApp.Core.Domain.Repository;
using TaxiApp.Infrastructure.Persistence.Context;
using TaxiApp.Infrastructure.Persistence.Repository.Common;

namespace TaxiApp.Infrastructure.Persistence.Repository;

public class TripDetailRepository : GenericRepository<TripDetail>, ITripDetailRepository
{
    private readonly TaxiAppContext _context;

    public TripDetailRepository(TaxiAppContext context) : base(context)
    {
        _context = context;
    }
}