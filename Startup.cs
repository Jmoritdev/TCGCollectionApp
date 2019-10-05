using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TCGCollectionApp.Models;
using System;

namespace TCGCollectionApp {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production") {
                System.Console.WriteLine("-----------------------USING PRODUCTION---------------------");
                services.AddDbContext<TCGCollectionContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
                System.Console.WriteLine("USING STRING: " + Configuration.GetConnectionString("MyDbConnection"));
            } else {
                System.Console.Write("-----------------------USING LOCAL---------------------");
                services.AddDbContext<TCGCollectionContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalContext")));
            }

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<TCGCollectionContext>().Database.Migrate();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
