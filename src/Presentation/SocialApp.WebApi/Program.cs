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
builder.Services.AddSwaggerGen();

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

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
