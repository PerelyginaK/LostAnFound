using LostFound.WebAPI.AppConfiguration.ApplicationExtensions;
using LostFound.WebAPI.AppConfiguration.ServicesExtensions;
using LostFound.Entity;
using LostFound.Repository;
using Microsoft.EntityFrameworkCore;

using Serilog;


var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogConfiguration();
builder.Services.AddVersioningConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDbContextConfiguration(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}
