using CloudinaryDotNet;
using KTaseva.App.Areas.Identity.Services;
using KTaseva.App.Common;
using KTaseva.App.Hubs;
using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.AboutMe;
using KTaseva.Services.Admin;
using KTaseva.Services.Appointments;
using KTaseva.Services.Cloudinary;
using KTaseva.Services.Mapping;
using KTaseva.Services.Photos;
using KTaseva.Services.Procedures;
using KTaseva.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace KTaseva.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KTasevaDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<KTasevaDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
            });

            RegisterServiceLayer(services);

            services.Configure<SendGridOptions>(this.Configuration.GetSection("EmailSettings"));

            Account account = new Account(
                        this.Configuration["Cloudinary:AppName"],
                        this.Configuration["Cloudinary:AppKey"],
                        this.Configuration["Cloudinary:AppSecret"]);
            Cloudinary cloudinary = new Cloudinary(account);
            services.AddSingleton(cloudinary);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdmin();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AppointmentHub>("Appointments/Add");

                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, SendGridEmailSender>();

            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IProcedureService, ProcedureService>();
            services.AddScoped<IAboutMeService, AboutMeService>();
        }
    }
}
