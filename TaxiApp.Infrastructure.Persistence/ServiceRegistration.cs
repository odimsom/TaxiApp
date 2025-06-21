using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiApp.Core.Domain.Repository;
using TaxiApp.Core.Domain.Repository.Common;
using TaxiApp.Infrastructure.Persistence.Context;
using TaxiApp.Infrastructure.Persistence.Repository;
using TaxiApp.Infrastructure.Persistence.Repository.Common;

namespace TaxiApp.Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static void AddInfrastructureRepositories(this IServiceCollection services, IConfiguration config)
    {
        if(config.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<TaxiAppContext>(opt => 
                opt.UseInMemoryDatabase("TaxiAppDb"));
        }
        else
        {
            services.AddDbContext<TaxiAppContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"), 
                    m => 
                    m.MigrationsAssembly(typeof(TaxiAppContext).Assembly.FullName)), ServiceLifetime.Transient);
        }
        
        // register generic
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        // Register Repositories
        services.AddTransient<ITaxiRepository, TaxiRepository>();
        services.AddTransient<ITripRepository, TripRepository>();
        services.AddTransient<ITripDetailRepository, TripDetailRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserGroupRepository, UserGroupRepository>();
        services.AddTransient<IUserGroupDetailRepository, UserGroupDetailRepository>();
    }
}