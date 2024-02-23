using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Users.Shared;
using WalletApi.Modules.Wallets.Application.Owners.Commands.Handlers;
using WalletApi.Modules.Wallets.Application.Wallets.Commands.Handlers;

namespace WalletApi.Modules.Wallets.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<IUsersModuleApi, UsersModuleApiService>();
        services.AddTransient<AddOwnerHandler>();
        services.AddTransient<UserOwnerHandler>();
        services.AddTransient<AddWalletHandler>();
        services.AddTransient<UserVerifiedHandler>();
        return services;
    }
}