using ModularMonolith.Shared.Exceptions;

namespace WalletApi.Modules.Wallets.Application.Wallets.Exceptions;

public sealed class OwnerNotFoundException(Guid ownerId) : SharedException($"Owner with ID: '{ownerId}' was not found.")
{
    
}