using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiasApp.Data;
using DiasApp.Interfaces;
using DiasApp.Models;
using DiasApp.Repositories;
using DiasApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DiasApp.Hubs;

namespace DiasApp
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
            //session configs
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
                //options.CheckConsentNeeded = context => false;
            });

                services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<PharmacyContext>(options => options.UseSqlite("Data Source=pharmacy.db"));

            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<PharmacyContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped<DrugService>();
            services.AddScoped<IDrugRepository, DrugRepository>();

            services.AddScoped<ManufacturerService>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

            services.AddScoped<PrescriptionService>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

            services.AddScoped<OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<OrganizationService>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            services.AddScoped<PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddSignalR();

            //SEC SETTINGS
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseSession();
            //app.UseHttpContextItemsMiddleware();

            /*app.Run(async (context) =>
            {
                 if (context.Session.Keys.Contains("name")) { }
                    // await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
                 else
                 {
                     context.Session.SetString("name", "Anonymous");
                     //await context.Response.WriteAsync("Hello Anonymous!");
                 }
             });*/

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //UseSignalR 
            app.UseSignalR(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
            });

        }
    }
}
