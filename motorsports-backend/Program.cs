using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using motorsports_backend.Middleware;
using motorsports_Domain.Contracts;
using motorsports_Domain.Contracts.Service;
using motorsports_Domain.Entities;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Repositories;
using motorsports_Infrastructure.Seeding;
using motorsports_Service.Auth;
using motorsports_Service.Contracts;
using motorsports_Service.Services;
using Newtonsoft.Json;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//DI - Drivers
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();
//DI - Teams
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
//DI- Nationality
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();
builder.Services.AddScoped<INationalityService, NationailtyService>();
//DI - BLOB
builder.Services.AddScoped<IBlobService, BlobService>();//Add AutoMapper
//Add in-memory cache
builder.Services.AddMemoryCache();
//DI - Cache
builder.Services.AddScoped<ICacheService, MemoryCacheService>();
//DI - Token
builder.Services.AddScoped<ITokenService, TokenService>();
//DI - Account
builder.Services.AddScoped<IAccountService, AccountService>();

//Prevent circular references
builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
//Fake data
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

//Configure Identity service
builder.Services.AddIdentity<UserEntity, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ApplicationDBContext>();

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

var app = builder.Build();

//DB seeding (via command)
//TODO Fix this
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
        var fakers = scope.ServiceProvider.GetRequiredService<Fakers>();
        //Seed the database with initial data
        motorsports_Infrastructure.Seeding.DbSeeder.SeedBDData(dbContext, fakers, 50, 50);
    }
}


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
