using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Middleware.ImageHanlerMiddleware;
using SimECommerce.ImagesHandler;
using SimECommerce.Models;

namespace SimECommerce
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //injection de services ImageHandler
            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageRead, ImageRead>();
            services.AddDistributedMemoryCache(); //Adds a default in-memor implementation of IDistributedCache

            services.AddSession();
            //services.AddSession(options=> {
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //}); //addsession

            
            services.AddDbContext<ECommerceSimplifieContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("ECommerceSimplifieContext")));
            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession(); //use session

            //Begin--> ImageHandlerMiddleware

            //   app.UseMiddleware<ImageMiddleWare>();
            // Load options from section "MyMiddlewareOptionsSection"
            //var myMiddlewareOptions = Configuration.GetSection("ImageMiddleWareSection").Get<ImageMiddleWareOptions>();
            //var myMiddlewareOptions2 = Configuration.GetSection("MyMiddlewareOptionsSection2").Get<MyMiddlewareOptions>();
            //app.UseMyMiddlewareWithParams(myMiddlewareOptions);
            //app.UseMyMiddlewareWithParams(myMiddlewareOptions2);
            //services.Configure<ImageMiddleWareOptions>(
            //    Configuration.GetSection("MyMiddlewareOptionsSection"));
            // Create branch to the MyHandlerMiddleware. 
            // All requests ending in .report will follow this branch.
            //app.MapWhen(
            //    context => context.Request.Path.ToString().EndsWith(".img"),
            //    appBranch => {
            //        // ... optionally add more middleware to this branch
            //        appBranch.UseMiddleware<ImageMiddleWare>();
            //    });

            //app.MapWhen(
            //    context => context.Request.Path.ToString().StartsWith("/image/"),
            //    appBranch =>
            //    {
            //        // ... optionally add more middleware to this branch
            //        appBranch.UseMiddleware<ImageMiddleWare>();
            //    });

            //app.UseWhen(
            //    context => context.Request.Path.StartsWithSegments("/image"),
            //    appBranch =>
            //    {
            //        appBranch.UseMiddleware<ImageMiddleWare>();
            //    });

            //End <-- ImageHandlerMiddleware


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
