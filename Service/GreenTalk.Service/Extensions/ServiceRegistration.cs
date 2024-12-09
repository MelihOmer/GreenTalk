using GreenTalk.Application.Interfaces.Services;
using GreenTalk.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GreenTalk.Service.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(AuthService));

            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
