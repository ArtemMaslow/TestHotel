using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TestHotel.Models;
using TestHotel.Options;
using TestHotel.Services;

namespace TestHotel
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var options = new ApplicationOptions(_configuration["ConnectionString"]);
            services.AddSingleton(options);

            services.AddRazorPages();
            services.AddControllers();

            services.AddDbContext<DatabaseContext>(option =>
            {
                option.UseNpgsql(options.ConnectionString,
                    migr => migr.MigrationsAssembly("TestHotel"));
                option.UseNpgsql(options.ConnectionString,
                    option => option.SetPostgresVersion(9, 6));
            });

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            });

            //services
            services.AddScoped<ClientService>();
            services.AddScoped<RoomService>();
            services.AddScoped<RoomTypeService>();
            services.AddScoped<StateService>();
            services.AddScoped<VisitService>();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                s.RoutePrefix = "api/help";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
