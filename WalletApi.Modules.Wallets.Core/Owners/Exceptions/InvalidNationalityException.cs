using ModularMonolith.Shared.Exceptions;

namespace WalletApi.Modules.Wallets.Core.Owners.Exceptions;

internal sealed class InvalidNationalityException(string nationality)
    : SharedException($"Nationality: '{nationality}' is invalid.")
{
    public string Nationality { get; } = nationality;
}