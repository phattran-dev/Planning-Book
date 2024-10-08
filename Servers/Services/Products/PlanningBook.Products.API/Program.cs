using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlanningBook.Themes.API.Extensions;
using PlanningBook.Themes.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

#region Add DbContexts
builder.Services.AddPBProductDbContext(configuration);
#endregion Add DbContexts

#region Add Services
builder.Services
    .AddRepositories()
    .RegistryCommandQueryExecutor(configuration)
    .RegistryProductModule(configuration);
#endregion Add Services

#region Add Authentication
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.SaveToken = true;
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            SaveSigninToken = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
        };
    });
builder.Services.AddAuthorization();
#endregion Add Authentication

#region Add Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                  {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                  },
                  Scheme = "oauth2",
                  Name = "Bearer",
                  In = ParameterLocation.Header,

                },
                new List<string>()
              }
        });
    }
);
#endregion Add Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
