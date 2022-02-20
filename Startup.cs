using BiathlonSuccess.Data;
using BiathlonSuccess.Infrastructure;
using BiathlonSuccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiathlonSuccess.Models;

namespace BiathlonSuccess
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
            //Sets the display of the Cookie Consent banner (/Pages/Shared/_CookieConsentPartial.cshtml).
            //This lambda determines whether user consent for non-essential cookies is needed for a given request.
            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            string connection = Configuration["ConnectionStrings:Dsu_team3"];
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection,
                o => o.SetPostgresVersion(new Version(9, 5))));

            services.AddDbContext<LoginDbContext>(options => options.UseNpgsql(connection,
                o => o.SetPostgresVersion(new Version(9, 5))));

            //string connection = Configuration["ConnectionString:Develop"];
            //services.AddDbContext<AppDbContext>(
            //    options => options.UseSqlite(connection));
            //services.AddDbContext<LoginDbContext>(
            //    options => options.UseSqlite(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LoginDbContext>()
                .AddDefaultTokenProviders(); // Aktiverar så det går att använda tokens

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(2)); // Token är giltig i 2 timmar

            services.AddScoped<IDbRepository, DbRepository>();
            services.AddScoped<IFitnessRepo, FitnessRepo>();
            services.AddScoped<IWeatherRepo, WeatherRepo>();
            services.AddScoped<IApiClient, ApiClient>();
            services.AddScoped<ICalculationsConversionsRepo, CalculationsConversionsRepo>();
            services.AddScoped<IAimtrackerRepo, AimtrackerRepo>();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            services.AddAuthorization(o =>
            {
                o.AddPolicy("CaptainsOnly", policy => policy.RequireClaim("Level", "5"));
            });

            services.AddControllersWithViews();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
