using Api.Domain.Platform;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Configurations;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    private const int MaxNameLength = 100;
    private const int MaxPublisherLength = 100;

    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(plat => plat.Id);
        builder.Property(plat => plat.Name).IsRequired().HasMaxLength(MaxNameLength);
        builder.Property(plat => plat.Publisher).IsRequired().HasMaxLength(MaxPublisherLength);
    }
}