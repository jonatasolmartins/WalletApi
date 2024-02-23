namespace WalletApi.Modules.Wallets.Application.Wallets.Commands;

public record AddFunds(Guid WalletId, decimal Amount);