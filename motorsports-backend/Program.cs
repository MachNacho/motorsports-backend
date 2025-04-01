using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Contracts;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Repositories;
using motorsports_Service.Contracts;
using motorsports_Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//Add in-memory cache
builder.Services.AddMemoryCache();
//DI - Cache
builder.Services.AddScoped<ICacheService, MemoryCacheService>();
//DI - Drivers
builder.Services.AddScoped<IDriverRepository, DriverRepositories>();
builder.Services.AddScoped<IDriverService, DriverService>();
// Add database connection
builder.Services.AddDbContext<ApplicationDBContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("HomeConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
