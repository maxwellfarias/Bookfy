using System;

namespace Bookfy.Domain.Abstractions;

public interface IUnitOfWork
{
    // The SaveChangesAsync method is an asynchronous method that is responsible for saving any changes made to the entities in the unit of work to
    // the underlying data store.
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
