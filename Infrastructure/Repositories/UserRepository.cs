using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Users.ToListAsync(cancellationToken);
        }

        public async Task<User?> GetUserAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken)
        {
            return await dbContext.Users.FirstOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
