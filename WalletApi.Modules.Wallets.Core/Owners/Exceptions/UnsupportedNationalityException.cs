using ModularMonolith.Shared.Exceptions;

namespace WalletApi.Modules.Wallets.Core.Owners.Exceptions;

internal sealed class UnsupportedNationalityException(string nationality)
    : SharedException($"Nationality: '{nationality}' is unsupported.")
{
    public string Nationality { get; } = nationality;
}