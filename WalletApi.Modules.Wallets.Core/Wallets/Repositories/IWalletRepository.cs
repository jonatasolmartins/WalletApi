using WalletApi.Modules.Wallets.Core.Owners.SharedKernel;
using WalletApi.Modules.Wallets.Core.Wallets.Aggregates;
using WalletApi.Modules.Wallets.Core.Wallets.ValueObjects;

namespace WalletApi.Modules.Wallets.Core.Wallets.Repositories;

public interface IWalletRepository
{
    internal Task<Wallet> GetAsync(WalletId id);
    internal Task<Wallet> GetAsync(OwnerId ownerId, Currency currency);
    internal Task AddAsync(Wallet wallet);
    internal Task UpdateAsync(Wallet wallet);
}