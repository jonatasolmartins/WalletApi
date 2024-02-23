using Microsoft.AspNetCore.Http;
using WalletApi.Modules.Wallets.Application.Wallets.Commands;

namespace WalletApi.Modules.Wallets.Api.Endpoints;

public static class FundsEndpoint
{
    public static async Task<IResult> Add(AddFunds command)
    {
        //await _dispatcher.SendAsync(command);
        return await Task.FromResult(TypedResults.NoContent());
    }
    
    public static async Task<IResult> Transfer(TransferFunds command)
    {
        //await _dispatcher.SendAsync(command);
        return await Task.FromResult(TypedResults.NoContent());
    }
}