using Domain.Dtos;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;

            var connection = dbContext.Database.GetDbConnection();

            var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory")?.ToString();
            var actualConnectionString = connection.ConnectionString.Replace("|DataDirectory|", dataDirectory);
            var qwe = "C:\\Users\\alper\\OneDrive\\Masaüstü\\Lena_AspNetCoreMVC\\Infrastructure\\Database\\ApplicationDatabase.mdf;";
            var qwe2 = "(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\alper\\OneDrive\\Masaüstü\\Lena_AspNetCoreMVC\\Infustructure\\Database\\ApplicationDatabase.mdf;Integrated Security=True";
            var asd = string.Empty;
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
