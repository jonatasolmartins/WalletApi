using System.Runtime.CompilerServices;
using WalletApi.Modules.Wallets.Core.Owners.Aggregates;
using WalletApi.Modules.Wallets.Core.Owners.Repositories;
using Microsoft.EntityFrameworkCore;
using WalletApi.Modules.Wallets.Core.Owners.SharedKernel;

[assembly: InternalsVisibleTo("WalletApi.Modules.Wallets.Application")]
namespace WalletApi.Modules.Wallets.Infrastructure.DAL.Repositories;

internal class OwnerRepository : IOwnerRepository
{
    private readonly WalletsDbContext _context;
    private readonly DbSet<Owner> _owners;
    
    public OwnerRepository(WalletsDbContext context)
    {
        _context = context;
        _owners = _context.Owners;
    }

    public Task<Owner> GetAsync(OwnerId id)
        =>  _owners.SingleOrDefaultAsync(x => x.Id.Equals(id))!;
    
    public async Task AddAndSaveAsync(Owner owner)
    {
        await _owners.AddAsync(owner);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAndSaveAsync(Owner owner)
    {
        _owners.Update(owner);
         await _context.SaveChangesAsync();
    }
}