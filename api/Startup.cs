using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using GlobalTravelTradeApi.Helper;
using GlobalTravelTradeApi.DataAccess.Application;
using GlobalTravelTradeApi.DataAccess;

namespace GlobalTravelTradeApi
{
    public class Startup
    {
        private readonly IAppSettings _appSettings;
        public IHostingEnvironment CurrentEnvironment { get; }
        private readonly IConnectionStrings _connectionString;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var connectionStringSection = Configuration.GetSection("ConnectionStrings");

            _appSettings = appSettingsSection.Get<AppSettings>();
            _connectionString = connectionStringSection.Get<ConnectionStrings>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings>(_appSettings);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(_appSettings.AllowedOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IAppSettings>(_appSettings);
            services.AddSingleton<INpgSqlServerRepository, NpgSqlServerRepository>(serviceProvider =>
            {
                return new NpgSqlServerRepository(_connectionString.GlobalTravelTradeConnection);
            });

            AddService(services);
        }

        public static void AddService(IServiceCollection services)
        {
              services.AddScoped<IPopupService, PopupService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles(); // for wwwroot folder

            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), "file");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(filePaths),
                RequestPath = "/file"
            });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
