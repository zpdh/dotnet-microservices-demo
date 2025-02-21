using Command.Domain.Platform;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Command.Infrastructure.Configurations;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
      builder.HasKey(plat => plat.Id);
      builder.Property(plat => plat.Name);
      builder.HasMany(plat => plat.Commands)
        .WithOne(cmd => cmd.Platform)
        .HasForeignKey(cmd => cmd.PlatformId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}

