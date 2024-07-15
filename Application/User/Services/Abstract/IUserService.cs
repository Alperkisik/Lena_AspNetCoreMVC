using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Services.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<Domain.Dtos.User>> GetUsers();
    }
}
