using ModularMonolith.Modules.Users.Shared.Events;
using WalletApi.Modules.Wallets.Application.Wallets.Exceptions;
using WalletApi.Modules.Wallets.Core.Owners.Repositories;
using WalletApi.Modules.Wallets.Core.Wallets.ValueObjects;

namespace WalletApi.Modules.Wallets.Application.Wallets.Commands.Handlers;

public class UserVerifiedHandler
{
    public async Task<AddWallet> HandleAsync(UserVerified command, IOwnerRepository ownerRepository)
    {
        var owner = await ownerRepository.GetAsync(command.UserId);
        if (owner is null)
        {
            throw new OwnerNotFoundException(command.UserId);
        }
        owner.Verify(DateTime.UtcNow);
        
        await ownerRepository.UpdateAndSaveAsync(owner);
        
        return new AddWallet(owner.Id, new Currency("BTC"));
    }
}