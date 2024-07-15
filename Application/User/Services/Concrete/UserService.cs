using Application.User.Services.Abstract;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task<IEnumerable<Domain.Dtos.User>> GetUsers()
        {
            return await userRepository.GetAllAsync();
        }
    }
}
