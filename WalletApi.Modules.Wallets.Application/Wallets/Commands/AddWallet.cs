namespace WalletApi.Modules.Wallets.Application.Wallets.Commands;

public record AddWallet(Guid OwnerId, string Currency)
{
    public Guid WalletId { get; init; } = Guid.NewGuid();
}