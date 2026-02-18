using System;

namespace Bookify.Domain.Users;

public interface IUserRepository
{
    //CancellationToken is a struct that is used to signal that an operation should be canceled. It is typically used in asynchronous programming to
    // allow the caller to cancel an ongoing operation if it is no longer needed or if it takes too long to complete. In this case, the GetByIdAsync
    // method accepts a CancellationToken parameter, which allows the caller to cancel the operation if necessary.
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(User user);
}
