using Application.Login.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Login.Validation
{
    internal class LoginValidation : AbstractValidator<LoginRequest>
    {
        public LoginValidation()
        {
            RuleFor(request => request.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(1, 16).WithMessage("Username must be between 1 and 16 characters.");

            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(1, 16).WithMessage("Password must be between 1 and 16 characters.");

            RuleFor(request => request.RememberMe)
                .NotNull().WithMessage("RememberMe must be specified.");
        }
    }
}
