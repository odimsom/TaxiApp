using TaxiApp.Core.Domain.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Core.Domain.Repository;
using TaxiApp.Infrastructure.Persistence.Context;
using TaxiApp.Infrastructure.Persistence.Repository.Common;

namespace TaxiApp.Infrastructure.Persistence.Repository;

public class UserGroupRepository : GenericRepository<UserGroup>, IUserGroupRepository
{
    private readonly TaxiAppContext _context;

    public UserGroupRepository(TaxiAppContext context) : base(context)
    {
        _context = context;
    }
}