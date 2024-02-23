using WalletApi.Modules.Wallets.Core.Wallets.Aggregates;
using WalletApi.Modules.Wallets.Core.Wallets.Repositories;

namespace WalletApi.Modules.Wallets.Application.Wallets.Commands.Handlers;

public class AddWalletHandler
{
     public AddWalletHandler() { }
     
    public async Task HandleAsync(AddWallet command, IWalletRepository walletRepository)
    {
        var wallet = Wallet.Create(command.OwnerId, command.Currency, DateTime.UtcNow);
        await walletRepository.AddAsync(wallet);
    }
    
}