using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HostelDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("HostelDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAssetCategoryRepository, AssetCategoryRepository>();
        services.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();
        services.AddScoped<IGuestMasterRepository, GuestMasterRepository>();
        services.AddScoped<IStaffOccupancyTypeRepository, StaffOccupancyTypeRepository>();
        services.AddScoped<IStudOccupancyTypeRepository, StudOccupancyTypeRepository>();
        services.AddScoped<IHostelMasterRepository, HostelMasterRepository>();
        return services;
    }
}
