using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TaxiApp.Core.Application.Interfaces;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Application.Services;
using TaxiApp.Core.Application.Services.Common;

namespace TaxiApp.Core.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // generic service registrations
        services.AddTransient(typeof(IGenericService<,>), typeof(GenericService<,>));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // registration
        services.AddTransient<ITaxiService, TaxiService>();
        services.AddTransient<ITripDetailService, TripDetailService>();
        services.AddTransient<ITripService, TripService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserGroupDetailService, UserGroupDetailService>();
        services.AddTransient<IUserGroupService, UserGroupService>();
    }
}