using LandmarkRemark.Data;
using LandmarkRemark.Models;
using LandmarkRemark.Repository;
using LandmarkRemark.Services;
using LandmarkRemark.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LandmarkRemark
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
            var jwtSection = new JsonWebToken();
            Configuration.GetSection(Constants.AppSettings.JSON_WEB_TOKEN).Bind(jwtSection);
            services.ConfigureCors(Constants.General.POLICY_NAME);
            services.AddJwtAuthentication(jwtSection.SecretKey, jwtSection.Domain);
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString(Constants.AppSettings.DEFAULT_CONNECTION)));
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddScoped<ILandmarkService, LandmarkService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Error");
            }
            app.UseCors(Constants.General.POLICY_NAME);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
