using Microsoft.Extensions.Logging;
using ModularMonolith.Modules.Users.Shared;
using WalletApi.Modules.Wallets.Application.Owners.Exceptions;
using WalletApi.Modules.Wallets.Core.Owners.Aggregates;
using WalletApi.Modules.Wallets.Core.Owners.Repositories;
using WalletApi.Modules.Wallets.Shared;

namespace WalletApi.Modules.Wallets.Application.Owners.Commands.Handlers;

public class AddOwnerHandler
{
    public AddOwnerHandler() { }
    
    public async Task Handle(AddOwner command, IOwnerRepository ownerRepository,
        IUsersModuleApi usersModuleApi,
        ILogger<AddOwnerHandler> logger)
    {
        var user = await usersModuleApi.GetUserAsync(command.Email);
        if (user is null)
        {
            throw new UserNotFoundException(command.Email);
        }

        if (await ownerRepository.GetAsync(user.UserId) is {} noOwner)
        {
            throw new OwnerAlreadyExistsException(command.Email);
        }

        var now = DateTime.UtcNow;
        var owner = new Owner(user.UserId, user.FullName, user.Nationality, now);
        await ownerRepository.AddAndSaveAsync(owner);
        logger.LogInformation("Created an owner for the user with ID: '{0}' and Email: {1}.", user.UserId, user.Email);
    }
}