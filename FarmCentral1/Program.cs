using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FarmCentral1.Areas.Identity.Data;
using FarmCentral1.Core;
using FarmCentral1.Core.Repositories;
using FarmCentral1.Repositories;

namespace FarmCentral1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

                                    builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Authorization
            AddAuthorizationPolicies(builder.Services);
            #endregion

            AddScoped();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            app.Run();


            void AddAuthorizationPolicies(IServiceCollection services)
            {
                builder.Services.AddAuthorization(options =>
                {
                    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
                });
                builder.Services.AddAuthorization(options =>
                {
                    options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Administrator));
                    options.AddPolicy(Constants.Policies.RequireManager, policy => policy.RequireRole(Constants.Roles.Manager));
                });
            }

            void AddScoped()
            {
                builder.Services.AddScoped<IUserRepository, UserRepository>();
                builder.Services.AddScoped<IRoleRepository, RoleRepository>();
                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
                builder.Services.AddScoped<IProductRepository, ProductRepository>();
            }
        } 
    }
}
