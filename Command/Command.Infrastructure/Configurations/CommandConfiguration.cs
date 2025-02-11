using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppDomain = Command.Domain.Command;

namespace Command.Infrastructure.Configurations;

public class CommandConfiguration : IEntityTypeConfiguration<AppDomain.Command>
{
    public void Configure(EntityTypeBuilder<AppDomain.Command> builder)
    {
        throw new NotImplementedException();
    }
}