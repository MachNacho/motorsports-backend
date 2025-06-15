using Bogus;
using Microsoft.EntityFrameworkCore;
using motorsports_backend.Middleware;
using motorsports_Domain.Contracts;
using motorsports_Domain.Contracts.Service;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Repositories;
using motorsports_Infrastructure.Seeding;
using motorsports_Service.Contracts;
using motorsports_Service.Services;
using Newtonsoft.Json;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Entities repositorys & Services
//DI - Drivers
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();
//DI - Teams
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

builder.Services.AddScoped<INationalityRepository,NationalityRepository>();
builder.Services.AddScoped<INationalityService,NationailtyService>();
//Services/Tool
//DI - BLOB
builder.Services.AddScoped<IBlobService, BlobService>();//Add AutoMapper
//Add in-memory cache
builder.Services.AddMemoryCache();
//DI - Cache
builder.Services.AddScoped<ICacheService, MemoryCacheService>();
//Prevent circular references
builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

builder.Services.AddTransient<Fakers>();
//Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // or AddDebug(), AddFile(), etc.
builder.Logging.AddDebug();   // for Visual Studio Output
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Information);

// Add database connection
builder.Services.AddDbContext<ApplicationDBContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HomeConnection"));
    options.EnableSensitiveDataLogging(); // show parameters
    options.LogTo(Console.WriteLine, LogLevel.Information); // log SQL to console
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{

}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    var fakers = scope.ServiceProvider.GetRequiredService<Fakers>();
    //Seed the database with initial data
    motorsports_Infrastructure.Seeding.DbSeeder.SeedBDData(dbContext, fakers, 50, 50);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.UseCors(x => x
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials()
      .SetIsOriginAllowed(origin => true));

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();//custom exceptions
app.UseAuthorization();

app.MapControllers();

app.Run();
