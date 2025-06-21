using TaxiApp.Core.Domain.Entities;
using TaxiApp.Core.Domain.Repository;
using TaxiApp.Infrastructure.Persistence.Context;
using TaxiApp.Infrastructure.Persistence.Repository.Common;

namespace TaxiApp.Infrastructure.Persistence.Repository;

public class TaxiRepository : GenericRepository<Taxi>, ITaxiRepository
{
    private readonly TaxiAppContext _context;

    public TaxiRepository(TaxiAppContext context) : base(context)
    {
        _context = context;
    }
}