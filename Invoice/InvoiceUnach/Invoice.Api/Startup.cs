using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Invoice.Api.Configuration;
using Invoice.Infrastructure;
using Invoice.Infrastructure.JsonResolver;
using Invoice.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Invoice.Api
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
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);
            
            services.AddDbContext<InvoiceDbContext>
                (option=> 
                option.UseSqlServer(appSettings.ConnectionStrings.InvoiceDb));
            
            services.AddHttpContextAccessor();
            
            services.AddControllers()
                .AddNewtonsoftJson(opt =>
                    opt.SerializerSettings.ContractResolver = new PrivateSetterContractResolver());
                    
            ConfigureSwagger(services);
            
            services.AddMvc();
            services.AddMemoryCache();
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            
            ConfigureMiddlewares(app);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        private void ConfigureSwagger(IServiceCollection services)
        {
            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Invoice Unach API",
                    Description = "API REST used to manage invoice Unach information",
                    Contact = new OpenApiContact
                    {
                        Name = "DSoftNet",
                        Email = "dsoftnet@unach.edu.ec"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        protected virtual void ConfigureMiddlewares(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new RepositoryModule());
        }
    }
}