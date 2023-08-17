using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Date.Data;
using Date.Interfaces;
using Date.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtentsion
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services,
       IConfiguration config)
       {
            services.AddDbContext<DataContext>(opt=>{

            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITokenService,TokenService>();
            
            // services.AddScoped<IuserRepository,UserRepository>();
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            // services.AddScoped<Iphotoservice,PhotoService>();
            // services.AddScoped<UserLoginActivity>();
            // services.AddScoped<IuserLikesRepository,LikeRepository>();
            // services.AddScoped<IMessageRepository,MessageRepository>();

            return services;
       } 

       
    }
}