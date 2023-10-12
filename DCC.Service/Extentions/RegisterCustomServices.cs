using DCC.ModelSQL.GenericRepository.Implementation;
using DCC.ModelSQL.GenericRepository.Repository;
using DCC.Service.Interface;
using DCC.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Extentions
{
    public static class Dependencyinjections
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, EntityFrameworkRepository>();
            services.AddScoped<IRepositoryReadOnly, EntityFrameworkRepositoryReadOnly>();
            services.AddScoped<IOutgoingService, OutgoingService>();
            services.AddScoped<IInComingService, InComingService>();
            services.AddScoped<IMenubar, MenubarService>();
            services.AddScoped<IDocInfo, DocInfoService>();
            services.AddScoped<IFileUtilityService, FileUtilityService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddHttpContextAccessor();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IuserManager, userManagerService>();

        }
    }
}
