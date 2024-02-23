using Microsoft.EntityFrameworkCore;
using WalletApi.Modules.Wallets.Core.Owners.Aggregates;
using WalletApi.Modules.Wallets.Core.Wallets.Aggregates;
using WalletApi.Modules.Wallets.Core.Wallets.Entities;

namespace WalletApi.Modules.Wallets.Infrastructure.DAL;

internal class WalletsDbContext(DbContextOptions<WalletsDbContext> options) : DbContext(options)
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Transfer> Transfers { get; set; }
    public DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("wallets");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}