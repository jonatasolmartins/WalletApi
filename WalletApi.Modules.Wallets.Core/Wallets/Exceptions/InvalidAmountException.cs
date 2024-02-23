using ModularMonolith.Shared.Exceptions;

namespace WalletApi.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class InvalidAmountException(decimal amount) : SharedException($"Amount: '{amount}' is invalid.")
{
    public decimal Amount { get; } = amount;
}