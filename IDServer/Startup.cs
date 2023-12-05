
using DCC.ModelSQL.GenericRepository.Implementation;
using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using DCC.Service.Service;
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace IDServer
{

    public class Startup
    {
        IHostEnvironment _environment;
        public Startup(IConfiguration configuration,IHostEnvironment env)
        {
            _environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string AllowAll = "AllowAllDCCContent";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

           // var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath,"rs256.pfx"),"dcc");

        //    var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "idsvr3test.pfx"),"dcc");

            services.AddControllers();

            services.AddDbContext<DCCContext>(
             options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IRepository, EntityFrameworkRepository>();
            services.AddScoped<IRepositoryReadOnly, EntityFrameworkRepositoryReadOnly>();
            services.AddScoped<IuserManager, userManagerService>();

            services.AddIdentityServer()
           // .AddSigningCredential(cert)
           
           .AddDeveloperSigningCredential()
           .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
           .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
           .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
           .AddInMemoryClients(IdentityConfiguration.Clients)
           .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
           .AddProfileService<ProfileService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DCCServer", Version = "v1" });
            });



            services.AddCors(options =>
            {
                options.AddPolicy(AllowAll,
                   builder =>
                   {
                       builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                   });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(AllowAll);

            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DCCServer v1"));
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "DCCServer v1"));
            }

          


            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    
    
    }
}
