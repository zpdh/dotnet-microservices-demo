﻿namespace Command.Domain.Infrastructure.Data.Abstractions;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}