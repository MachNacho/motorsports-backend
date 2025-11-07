using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using motorsports_backend.Middleware;
using motorsports_Domain.Entities;
using motorsports_Domain.Interfaces;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Integration;
using motorsports_Infrastructure.Repositories;
using motorsports_Infrastructure.Seeding;
using motorsports_Service.Auth;
using motorsports_Service.Interface;
using motorsports_Service.Services;
using Newtonsoft.Json;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Dependency Injection
//DI- Race track
builder.Services.AddScoped<IRaceTrackRepository, RaceTrackRepository>();
builder.Services.AddScoped<IRaceTrackService, RaceTrackService>();
//DI - Drivers
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();
//DI - Teams
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();
//DI- Nationality
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();
builder.Services.AddScoped<INationalityService, NationailtyService>();
//DI - BLOB
builder.Services.AddScoped<IBlobIntegration, BlobIntegration>();//Add AutoMapper
//Add in-memory cache
builder.Services.AddMemoryCache();
//DI - Cache
builder.Services.AddScoped<ICacheIntegration, CacheIntegration>();
//DI - Token
builder.Services.AddScoped<ITokenService, TokenService>();
//DI - Account
builder.Services.AddScoped<IAccountService, AccountService>();
//Fake data
builder.Services.AddTransient<Fakers>();
#endregion

//Prevent circular references
builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });


#region logging
//Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // or AddDebug(), AddFile(), etc.
builder.Logging.AddDebug();   // for Visual Studio Output
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Information);
#endregion

// Add database connection
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HomeConnection"));
    options.EnableSensitiveDataLogging(); // show parameters
    options.LogTo(Console.WriteLine, LogLevel.Information); // log SQL to console
});


#region Identity service
//Configure Identity service

builder.Services.AddIdentity<UserEntity, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ApplicationDBContext>();
#endregion

#region JWT configuration
//Configure JWT for API auth

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])),
        ValidateLifetime = true, //Validate token expiration
        ClockSkew = TimeSpan.Zero //Remove grace period
    };
});
#endregion

var app = builder.Build();

#region Seeding
//SEEDING
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
//    var fakers = scope.ServiceProvider.GetRequiredService<Fakers>();
//    //Seed the database with initial data
//    motorsports_Infrastructure.Seeding.DbSeeder.SeedBDData(dbContext, fakers, 120, 10);
//}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();//Swagger alt.
}

app.UseHttpsRedirection();

app.UseCors(x => x
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials()
      .SetIsOriginAllowed(origin => true));

app.UseHttpsRedirection();

//GLobal exception handling
app.UseMiddleware<ExceptionHandlingMiddleware>();//custom exceptions

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
