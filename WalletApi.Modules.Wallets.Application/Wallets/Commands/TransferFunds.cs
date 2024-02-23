namespace WalletApi.Modules.Wallets.Application.Wallets.Commands;

public record TransferFunds(Guid FromWalletId, Guid ToWalletId, decimal Amount);