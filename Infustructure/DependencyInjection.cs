using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Context;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string ConnectionString)
        {
            string databaseMdfFolderPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "Infrastructure", "Database");

            var newConstr = ConnectionString.Replace("|DataDirectory|", databaseMdfFolderPath);


            var anan =
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\alper\\OneDrive\\Masaüstü\\Lena_AspNetCoreMVC\\Infrastructure\\Database\\ApplicationDatabase.mdf;Integrated Security=True;";
            //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\alper\\OneDrive\\Masaüstü\\Lena_AspNetCoreMVC\\Infrastructure\\Database\\ApplicationDatabase.mdf;Integrated Security=True;";
            
            if (anan == newConstr)
            {
                string asda  = string.Empty;
            }


            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(newConstr));


            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
