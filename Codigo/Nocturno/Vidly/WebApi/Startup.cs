using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.Filters;

namespace WebApi
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private readonly string cors = "AllowEverything";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(cors,builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            
            services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));
            ServiceFactory serviceFactory = new ServiceFactory(services);
            services.AddSingleton(typeof(string), Configuration.GetValue<string>("pathImport"));
            serviceFactory.AddDbContextService();
            serviceFactory.AddCustomServices();
            services.AddScoped<AuthorizationDIFilter>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(cors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
