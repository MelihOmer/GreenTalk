using GreenTalk.Application.UseCase.Authentications;
using GreenTalk.Application.UseCase.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace GreenTalk.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(LoginUseCase));
            services.AddScoped(typeof(SendMessageUseCase));
        }
    }
}
