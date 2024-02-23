using Microsoft.Extensions.DependencyInjection;
using WalletApi.Modules.Wallets.Core.Owners.Repositories;
using WalletApi.Modules.Wallets.Core.Wallets.Repositories;
using ModularMonolith.Shared.Database;
using WalletApi.Modules.Wallets.Infrastructure.DAL;
using WalletApi.Modules.Wallets.Infrastructure.DAL.Repositories;

namespace WalletApi.Modules.Wallets.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddPostgres<WalletsDbContext>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IWalletRepository, WalletRepository>();
            
        return services;
    }
}