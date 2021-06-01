﻿using System;
using System.Text;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Infrastructure.Persistence;
using Dotz.Fidelidade.Infrastructure.Services;
using Dotz.Fidelidade.Infrastructure.Services.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Dotz.Fidelidade.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)//, IWebHostEnvironment environment)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                );

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IHttpClientHandler, HttpClientHandler>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
//dotnet ef migrations add "CreateDb" --project src\Common\Dotz.Fidelidade.Infrastructure --startup-project src\App\Dotz.Fidelidade.Api --output-dir Persistence\Migrations