using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletApi.Modules.Wallets.Core.Owners.Aggregates;
using WalletApi.Modules.Wallets.Core.Owners.SharedKernel;
using WalletApi.Modules.Wallets.Core.Wallets.Aggregates;
using WalletApi.Modules.Wallets.Core.Wallets.ValueObjects;

namespace WalletApi.Modules.Wallets.Infrastructure.DAL.Configurations;

internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.Property(x => x.Version).IsConcurrencyToken();
        builder.HasOne<Owner>().WithMany().HasForeignKey(x => x.OwnerId);
            
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new WalletId(x));
            
        builder.Property(x => x.OwnerId)
            .IsRequired()
            .HasConversion(x => x.Value, x => new OwnerId(x));

        builder.Property(x => x.Currency)
            .IsRequired()
            .HasConversion(x => x.Value, x => new Currency(x));
    }
}