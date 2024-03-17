using Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate;

namespace Dev.Plugin.ChitmeoBank.Infrastructure.Data.Config;

public class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.HasKey(b => b.Id);
        builder.ToTable(nameof(Bank));
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
    }
}
