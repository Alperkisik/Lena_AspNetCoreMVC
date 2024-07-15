using Application.Login.Requests;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Login.Services.Abstract
{
    public interface ILoginService
    {
        Task<Result> LoginVerify(LoginRequest requestModel, CancellationToken cancellationToken);
    }
}
