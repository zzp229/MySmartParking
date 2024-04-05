using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmarkParking.Server.IService;
using SmartParking.Server.EFContext;
using SmartParking.Server.IEFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmarkParking.Server.Service;

namespace SmartParking.Server.Start
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfiguration.IConfiguration, Configuration.Configuration>();
            services.AddTransient<IEFContext.IEFContext, EFContext.EFContext>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IMenuService, MenuService>();

            services.AddControllers();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
