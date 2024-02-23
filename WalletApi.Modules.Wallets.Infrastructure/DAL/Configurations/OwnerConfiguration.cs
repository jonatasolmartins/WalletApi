using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletApi.Modules.Wallets.Core.Owners.Aggregates;
using WalletApi.Modules.Wallets.Core.Owners.SharedKernel;
using WalletApi.Modules.Wallets.Core.Owners.ValueObjects;

namespace WalletApi.Modules.Wallets.Infrastructure.DAL.Configurations;

internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("Owners");
            
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new OwnerId(x));
            
        builder.Property(x => x.FullName)
            .IsRequired()
            .HasConversion(x => x.Value, x => new FullName(x));
            
        builder.Property(x => x.Nationality)
            .IsRequired()
            .HasConversion(x => x.Value, x => new Nationality(x));
    }
}