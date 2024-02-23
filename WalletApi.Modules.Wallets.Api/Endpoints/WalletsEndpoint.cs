using Microsoft.AspNetCore.Http;
using WalletApi.Modules.Wallets.Application.Wallets.Commands;
using WalletApi.Modules.Wallets.Application.Wallets.Queries;

namespace WalletApi.Modules.Wallets.Api.Endpoints;

public static class WalletsEndpoint
{
    public static async Task<IResult> Get(Guid walletId)
    {
        var wallet = new GetWallet { WalletId = walletId };
        //await _dispatcher.QueryAsync(new GetWallet { WalletId = walletId });
        if (wallet is not null)
        {
            return TypedResults.Ok(wallet);
        }

        return await Task.FromResult(TypedResults.NotFound());
    }
    
    public static async Task<IResult> Post(AddWallet command)
    {
        //await _dispatcher.SendAsync(command);
        return await Task.FromResult(TypedResults.Created(nameof(Post), new { walletId = command.WalletId }));
    }
}