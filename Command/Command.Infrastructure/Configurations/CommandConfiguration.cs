using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppDomain = Command.Domain.Command;

namespace Command.Infrastructure.Configurations;

public class CommandConfiguration : IEntityTypeConfiguration<AppDomain.Command>
{
  public void Configure(EntityTypeBuilder<AppDomain.Command> builder)
  {
    builder.HasKey(cmd => cmd.Id);
    builder.Property(cmd => cmd.HowTo);
    builder.Property(cmd => cmd.CommandLine);
    builder.HasOne(cmd => cmd.Platform)
            .WithMany(plat => plat.Commands)
            .HasForeignKey(cmd => cmd.PlatformId)
            .OnDelete(DeleteBehavior.Cascade);
  }
}
