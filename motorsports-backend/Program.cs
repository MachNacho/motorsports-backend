using Microsoft.EntityFrameworkCore;
using motorsports_backend.Middleware;
using motorsports_Domain.Contracts;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Repositories;
using motorsports_Service.Contracts;
using motorsports_Service.Services;
using Newtonsoft.Json;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Entities repositorys & Services
//DI - Drivers
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
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
if (args.Length == 1 && args[0].ToLower() == "seeddata") // allows for test data to be loaded with command  
{
    Console.WriteLine("Seeding data...");
    // Add a simple test message to confirm execution  
    Console.WriteLine("Test: Seed data logic executed successfully.");
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
//app.UseHttpsRedirection();
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
