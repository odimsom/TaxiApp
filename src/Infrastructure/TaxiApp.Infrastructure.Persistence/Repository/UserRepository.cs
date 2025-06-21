using TaxiApp.Core.Domain.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Core.Domain.Repository;
using TaxiApp.Infrastructure.Persistence.Context;
using TaxiApp.Infrastructure.Persistence.Repository.Common;

namespace TaxiApp.Infrastructure.Persistence.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly TaxiAppContext _context;
    
    public UserRepository(TaxiAppContext context) : base(context)
    {
        _context = context;
    }
    public async Task<OperationResult<bool>> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}