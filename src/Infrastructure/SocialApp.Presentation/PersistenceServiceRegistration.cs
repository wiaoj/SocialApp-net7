using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialApp.Application.Common.Authentication;
using SocialApp.Application.Common.Persistence.Repositories.ReadRepositories;
using SocialApp.Application.Common.Persistence.Repositories.WriteRepositories;
using SocialApp.Application.Common.Services;
using SocialApp.Persistence.Context;
using SocialApp.Persistence.Services;
using SocialApp.Persistence.Services.Authentication;
using SocialApp.Persistence.Services.Repositories.ReadRepositories;
using SocialApp.Persistence.Services.Repositories.WriteRepositories;

namespace SocialApp.Persistence;
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SECTION_NAME));

        services.AddDbContext<SocialAppDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(BuildingBlocks.Persistence.MsSQL.MsSQLDatabaseContext.MsSQL_CONNECTION_STRING));
        });

        services.AddRepositories()
            .AddServices();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IUserReadRepository, UserReadRepository>();

        services.AddScoped<IProfileWriteRepository, ProfileWriteRepository>();
        services.AddScoped<IProfileReadRepository, ProfileReadRepository>();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IProfileService, ProfileService>();
        return services;
    }
}