using GreenTalk.Core.Interfaces.Jwt;
using GreenTalk.Core.Interfaces.Repository;
using GreenTalk.Infrastructure.Jwt;
using GreenTalk.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenTalk.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(conf =>
            {
                conf.UseNpgsql(configuration.GetConnectionString("postgres"));
            });

            services.AddScoped<IJwtTokenGenerator,JwtTokenGenerator>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

            services.AddScoped<IMessageRepository,MessageRepository>();
            services.AddScoped<IUserRepository,UserRepository>();


        }

    }
}
