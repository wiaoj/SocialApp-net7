using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;
using SocialApp.Application;
using SocialApp.Persistence;
using Spectre.Console;

AnsiConsole.Write(new FigletText("Social Application").Centered().Color(Color.Purple3));
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
    //her önüne gelen girebilir... policy.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin()
    policy//.WithOrigins("http://localhost:4200", "https://localhost:4200")
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    //.AllowCredentials() // SignalR için 
        )
    );



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            """
            JWT Authorization header using the Bearer scheme. 

            Enter 'Bearer' [space] and then your token in the text input below.

            Example: "Bearer {{token}}"
            """
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[] { }
        }
    });
});

Logger log = new LoggerConfiguration()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.File($"logs/{DateTime.Today}.txt")
            .MinimumLevel.Information()
            .CreateLogger();

builder.Host.UseSerilog(log);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
