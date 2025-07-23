using CINEMA.Data;
using CINEMA.Models;
using CINEMA.Repositories;
using CINEMA.Repositories.IRepositories;
using CINEMA.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace CINEMA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(
                option=>option.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedEmail = true;

                }
                )
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IUserOTPRepository, UserOTPRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for  ion scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")

                .WithStaticAssets();

            app.Run();
        }
    }
}
