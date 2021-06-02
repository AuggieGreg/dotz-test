using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Infrastructure.Services;
using System.Text;
using Dotz.Fidelidade.Application;
using Dotz.Fidelidade.Infrastructure;
using Dotz.Fidelidade.Api.Services;
using Dotz.Fidelidade.Infrastructure.Persistence;
using Dotz.Fidelidade.Api.Filters;
using FluentValidation.AspNetCore;

namespace Dotz.Fidelidade.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddHttpContextAccessor();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddHealthChecks();

            services.AddControllers(options =>
                    options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation();

            services.AddHttpClient();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Account", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Account v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(cors => cors
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
