using ModularMonolith.Shared.Exceptions;

namespace WalletApi.Modules.Wallets.Application.Owners.Exceptions;

internal sealed class UserNotFoundException(string email)
    : SharedException($"User with email: '{email}' was not found.")
{
    public string Email { get; } = email;
}