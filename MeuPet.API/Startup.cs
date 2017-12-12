using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPet.API.Context;
using MeuPet.API.Helpers;
using MeuPet.API.Middlewares;
using MeuPet.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace MeuPet.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<IProvider, Provider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<UsuarioService>();
            services.AddScoped<AgendaService>();
            services.AddScoped<PetService>();
            services.AddScoped<DoacaoService>();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<MeuPetContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("MeuPetContext"));
                    }
                    , ServiceLifetime.Transient);


            services.AddMvc(options =>
                {
                    //var policy = new AuthorizationPolicyBuilder()
                    //    .RequireAssertion(handler => (handler.Resource as AuthorizationFilterContext)?.HttpContext.Items["usuario"] != null)
                    //    .Build();

                    //options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter(policy));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<MeuPetContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<MeuPetContext>().EnsureSeedData();

            }

            //app.UseBasicAuthentication().UseMvc();
            app.UseMvc();

        }
    }
}
