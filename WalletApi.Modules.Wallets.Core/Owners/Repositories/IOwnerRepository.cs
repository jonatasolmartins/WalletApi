using System.Runtime.CompilerServices;
using WalletApi.Modules.Wallets.Core.Owners.Aggregates;
using WalletApi.Modules.Wallets.Core.Owners.SharedKernel;

[assembly: InternalsVisibleTo("WalletApi.Modules.Wallets.Infrastructure")]
[assembly: InternalsVisibleTo("WalletApi.Modules.Wallets.Application")]
namespace WalletApi.Modules.Wallets.Core.Owners.Repositories;

public interface IOwnerRepository
{
    internal Task<Owner> GetAsync(OwnerId id);
    internal Task AddAndSaveAsync(Owner owner);
    internal Task UpdateAndSaveAsync(Owner owner);
}