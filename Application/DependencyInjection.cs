using Application.Forms.Services.Abstract;
using Application.Forms.Services.Concrete;
using Application.Login.Services.Abstract;
using Application.Login.Services.Concrete;
using Application.User.Services.Abstract;
using Application.User.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IFormService, FormService>();

            return services;
        }
    }
}
