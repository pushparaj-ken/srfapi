using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();

    Task<T> GetByIdAsync(int id);

    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteASync(T entity);
}
