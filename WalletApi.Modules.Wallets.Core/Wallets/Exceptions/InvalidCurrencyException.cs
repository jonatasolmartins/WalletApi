using ModularMonolith.Shared.Exceptions;

namespace WalletApi.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class InvalidCurrencyException(string currency) : SharedException($"Currency: '{currency}' is invalid.")
{
    public string Currency { get; } = currency;
}