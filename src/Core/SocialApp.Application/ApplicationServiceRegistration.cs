using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SocialApp.Application;
public static class ApplicationServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        //services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}