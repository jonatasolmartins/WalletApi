using WalletApi.Modules.Wallets.Shared;
using Wolverine;

namespace WalletApi.Modules.Wallets.Api.Endpoints;

public static class OwnersEndpoint
{
    public static async Task<IResult> Post(AddOwner command, IMessageBus bus)
    {
        await bus.InvokeAsync(command);
        return TypedResults.NoContent();
    }
}