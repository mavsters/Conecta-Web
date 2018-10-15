using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Conecta.Data;
using Conecta.Models;
//using Conecta.Services;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;

namespace Conecta
{
    public class Startup
    {
        //Language Default
        private CultureInfo[] supportedCultures = new[]{
            new CultureInfo("es"),
            new CultureInfo("en"),
            new CultureInfo("fr"),
            new CultureInfo("de"),
            new CultureInfo("it"),
        };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //DataBase
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ConectaDBContextCloud")));
            //Identity
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddIdentity<ApplicationDbContext, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            

            //Login
            this.SetLoginOptions(services);

            //Set Region and Languages
            this.SetRegionAndLanguages(services);

            // Add application services.  services.AddTransient<IEmailSender, EmailSender>();

            //Model
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        protected void SetRegionAndLanguages(IServiceCollection services)
        {

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: "es", uiCulture: "es");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

        }

        protected void SetLoginOptions(IServiceCollection services)
        {
            services.AddAuthentication().AddTwitter(twitterOptions => {
                twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];
                twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();  
                app.UseDeveloperExceptionPage();  
                app.UseDatabaseErrorPage();  
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
