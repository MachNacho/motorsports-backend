using Microsoft.EntityFrameworkCore;
using motorsports_backend.Middleware;
using motorsports_Domain.Contracts;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Mapping;
using motorsports_Infrastructure.Repositories;
using motorsports_Service.Contracts;
using motorsports_Service.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Entities repositorys & Services
//DI - Drivers
builder.Services.AddScoped<IDriverRepository, DriverRepositories>();
builder.Services.AddScoped<IDriverService, DriverService>();
//DI - Teams
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

//Services/Tool
//DI - BLOB
builder.Services.AddScoped<IBlobService, BlobService>();//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
//Add in-memory cache
builder.Services.AddMemoryCache();
//DI - Cache
builder.Services.AddScoped<ICacheRepository, MemoryCacheRepository>();
//Prevent circular references
builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });



// Add database connection
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HomeConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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
