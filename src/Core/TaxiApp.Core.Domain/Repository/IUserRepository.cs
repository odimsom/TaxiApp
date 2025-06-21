using TaxiApp.Core.Domain.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Core.Domain.Repository.Common;

namespace TaxiApp.Core.Domain.Repository;

public interface IUserRepository : IGenericRepository<User>
{
    Task<OperationResult<bool>> LoginAsync(string username, string password);
}