using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using PlanningBook.Identity.API.Extensions;
using PlanningBook.Identity.Infrastructure;
using PlanningBook.Identity.Infrastructure.Entities;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

#region Add Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion Add Swagger

#region Add DbContexts
builder.Services.AddPBIdentityDbContext(configuration);
//.RegistryCommandQueryExecutor(configuration)
//.RegistryAccountModule(configuration);
#endregion Add DbContexts

#region Add Services
builder.Services
    .RegistryCommandQueryExecutor(configuration)
    .RegistryAccountModule(configuration);
#endregion Add Services

#region Add Identity
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
    })
    .AddBearerToken(IdentityConstants.BearerScheme);

//builder.Services.AddIdentityCore<Account>(options =>
//    {
//        options.SignIn.RequireConfirmedEmail = true;
//    })
    builder.Services.AddIdentityCore<Account>()
    .AddEntityFrameworkStores<PBIdentityDbContext>()
    .AddApiEndpoints();
#endregion Add Identity


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Auto generate API for authen
//app.MapIdentityApi<Account>();

app.UseAuthorization();

app.MapControllers();

app.Run();
