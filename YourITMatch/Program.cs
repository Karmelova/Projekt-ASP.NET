using Microsoft.EntityFrameworkCore;
using YourITMatch.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using YourITMatch.Models;
using Microsoft.Extensions.DependencyInjection;

namespace YourITMatch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = (@"Data Source=.\Data\YourITMatchDB.db") ?? throw new InvalidOperationException("Connection string 'YourITMatchContextConnection' not found.");

            builder.Services.AddDbContext<YourITMatchContext>(options => options.UseSqlite(connectionString));
            builder.Services.AddDbContext<YourITMatchDBContext>(options => options.UseSqlite(connectionString));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<YourITMatchContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=JobOffer}/{action=Index}/{id?}");
            app.MapRazorPages();
            Task.Run(async () =>
            {
                using (var scope = app.Services.CreateScope())
                {
                    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
                }
            }).GetAwaiter().GetResult();
            app.Run();
        }
    }
}