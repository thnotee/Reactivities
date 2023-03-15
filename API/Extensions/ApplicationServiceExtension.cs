using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Application.Activites;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt =>
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"))
            );
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
               {
                   policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
               });
            });
            services.AddMediatR(typeof(List.Handeler));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}