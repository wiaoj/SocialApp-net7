using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SocialApp.Application.Common.Authentication;
using SocialApp.Application.Common.Repositories.ReadRepositories;
using SocialApp.Application.Common.Repositories.WriteRepositories;
using SocialApp.Application.Common.Services;
using SocialApp.Persistence.Context;
using SocialApp.Persistence.Services;
using SocialApp.Persistence.Services.Authentication;
using SocialApp.Persistence.Services.Repositories.ReadRepositories;
using SocialApp.Persistence.Services.Repositories.WriteRepositories;
using System.Text;

namespace SocialApp.Persistence;
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SECTION_NAME));

        services.AddDbContext<SocialAppDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(BuildingBlocks.Persistence.MsSQL.MsSQLDatabaseContext.MsSQL_CONNECTION_STRING));
        });


        JwtSettings? jwtSettings = configuration.GetSection(JwtSettings.SECTION_NAME).Get<JwtSettings>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            };
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

        services.AddScoped<IPostWriteRepository, PostWriteRepository>();
        services.AddScoped<IPostReadRepository, PostReadRepository>();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IPostService, PostService>();
        return services;
    }
}