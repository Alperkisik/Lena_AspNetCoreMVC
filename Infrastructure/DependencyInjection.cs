using Domain.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFormRepository, FormRepository>();

            return services;
        }
    }
}
