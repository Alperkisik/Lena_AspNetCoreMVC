using Domain.Dtos;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User?> GetUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
