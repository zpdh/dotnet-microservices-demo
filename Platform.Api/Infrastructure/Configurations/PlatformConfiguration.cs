using Platform.Api.Domain.Platform;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Api.Infrastructure.Configurations;

public class PlatformConfiguration : IEntityTypeConfiguration<Domain.Platform.Platform>
{
    private const int MaxNameLength = 100;
    private const int MaxPublisherLength = 100;

    public void Configure(EntityTypeBuilder<Domain.Platform.Platform> builder)
    {
        builder.HasKey(plat => plat.Id);
        builder.Property(plat => plat.Name).IsRequired().HasMaxLength(MaxNameLength);
        builder.Property(plat => plat.Publisher).IsRequired().HasMaxLength(MaxPublisherLength);
    }
}