using Application.Login.Requests;
using Application.Login.Services.Abstract;
using Application.Login.Validation;
using Domain.Common;
using Domain.Dtos;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Login.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository userRepository;
        private readonly LoginValidation loginValidation;


        public LoginService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.loginValidation = new LoginValidation();
        }

        public async Task<Result> LoginVerify(LoginRequest requestModel, CancellationToken cancellationToken)
        {
            var validationResult = await loginValidation.ValidateAsync(requestModel, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Failure(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));


            try
            {
                var user = await userRepository
                    .GetUserAsync(user => user.Username == requestModel.Username && user.Password == requestModel.Password);

                if (user is null) return Result.Failure("Username or Password is incorrect.");

                return Result.Success(user);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
            
        }
    }
}
