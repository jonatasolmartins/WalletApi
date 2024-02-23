using WalletApi.Modules.Wallets.Api.Endpoints;
using WalletApi.Modules.Wallets.Application;
using WalletApi.Modules.Wallets.Infrastructure;

namespace WalletApi.Modules.Wallets.Api;

public static class Extension
{
    public static IServiceCollection AddWalletsModule(this IServiceCollection services)
    {
        services.AddApplicationLayer();
        services.AddInfrastructureLayer();
        return services;
    }
    
    public static IApplicationBuilder UseWalletsModule(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints  =>
        {
            var walletsEndPoint = endpoints.MapGroup("/wallets");
            walletsEndPoint.MapGet("/get/{walletId:guid}", WalletsEndpoint.Get);
            walletsEndPoint.MapPost("/create", WalletsEndpoint.Post);
            
           var fundsEndPoint = endpoints.MapGroup("/funds");
           fundsEndPoint.MapPost("/add", FundsEndpoint.Add);
           fundsEndPoint.MapPost("/transfer", FundsEndpoint.Transfer);
           
            var ownersEndPoint = endpoints.MapGroup("/owners");
            ownersEndPoint.MapPost("/create", OwnersEndpoint.Post);
        });
        
        return app;
    }
}