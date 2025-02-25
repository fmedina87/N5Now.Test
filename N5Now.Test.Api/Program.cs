using N5Now.Test.Infrastructure;
using N5Now.Test.Application;
using N5Now.Test.Domain.Common.Filters;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>(); // Aplica el filtro globalmente
});
builder.Host.UseSerilog((context, services, loggerConfig) =>
{
    loggerConfig
        .ReadFrom.Configuration(context.Configuration) // Lee la configuración de appsettings.json
        .Enrich.FromLogContext() // Necesario para evitar el error de DiagnosticContext
        .WriteTo.Console()
        .WriteTo.File("logs/app-log-.txt", rollingInterval: RollingInterval.Day);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastrucure(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();
app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
