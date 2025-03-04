﻿using Platform.Api.Domain.Core;

namespace Platform.Api.Domain.Infrastructure.Data.Abstractions;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<Result<List<TEntity>>> GetAllAsync();
    Task<Result<TEntity>> GetByIdAsync(int id);
    Task InsertAsync(TEntity entity);
}