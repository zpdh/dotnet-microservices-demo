namespace Command.Domain.Infrastructure.Data;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}