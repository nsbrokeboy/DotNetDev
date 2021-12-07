using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using PizzaDelivery.Data;
using PizzaDelivery.Logic;

namespace PizzaDelivery
{
    public class Startup
    {
        private static string connectionString = "Host=localhost;Database=PizzaDelivery;Username=dvkruglyak;Password=7f4fm76d5";
         // private static string connectionString = "Host=localhost;Database=PizzaDelivery;Username=postgres;Password=Jopa18102001";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddTransient<ShoppingCartActions>();
            
            services.AddDbContext<PizzaDeliveryDbContext>(options =>
                options.UseNpgsql(connectionString));
            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/Account/Login");
                });

            services.AddMvc()
                .AddSessionStateTempDataProvider();
            services.AddSession();
            
            // services.AddScoped(sp => sp.GetService<IHttpContextAccessor>().HttpContext.Session);
            // services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddScoped<ShoppingCartActions>();
            // services.AddControllersWithViews();
            // services.AddHttpContextAccessor();
            // services.AddTransient<ShoppingCartActions>();    
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            
            app.UseAuthorization();
            
            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}