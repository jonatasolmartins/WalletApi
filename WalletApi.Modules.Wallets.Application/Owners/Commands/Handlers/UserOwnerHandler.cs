using ModularMonolith.Modules.Users.Shared.Events;
using WalletApi.Modules.Wallets.Application.Owners.Exceptions;
using WalletApi.Modules.Wallets.Application.Wallets.Commands;
using WalletApi.Modules.Wallets.Core.Owners.Aggregates;
using WalletApi.Modules.Wallets.Core.Owners.Repositories;
using WalletApi.Modules.Wallets.Core.Wallets.ValueObjects;

namespace WalletApi.Modules.Wallets.Application.Owners.Commands.Handlers;

public class UserOwnerHandler
{
    public UserOwnerHandler() { }
    
    public async Task<AddWallet> HandleAsync(UserCreated command, IOwnerRepository ownerRepository)
    {

        if (await ownerRepository.GetAsync(command.UserId) is {} noOwner)
        {
            throw new OwnerAlreadyExistsException(command.Email);
        }
        ;
        var owner = new Owner(command.UserId, command.FullName, command.Nationality, DateTime.UtcNow);
        await ownerRepository.AddAndSaveAsync(owner);
        
        return new AddWallet(owner.Id, new Currency("USD"));

    }
}