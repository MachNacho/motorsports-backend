using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Contracts;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Mapping;
using motorsports_Infrastructure.Repositories;
using motorsports_Service.Contracts;
using motorsports_Service.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
//Add in-memory cache
builder.Services.AddMemoryCache();
//DI - Cache
builder.Services.AddScoped<ICacheRepository, MemoryCacheRepository>();
//DI - Drivers
builder.Services.AddScoped<IDriverRepository, DriverRepositories>();
builder.Services.AddScoped<IDriverService, DriverService>();
// Add database connection
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HomeConnection")));
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
