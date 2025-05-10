using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FindAFelineApp.Data;
using FindAFelineApp.Data.Repositories.Abstractions;
using FindAFelineApp.Data.Repositories;
using FindAFelineApp.Services.Abstractions;
using FindAFelineApp.Services;
using FindAFelineApp.Data.Seeders;

namespace FindAFelineApp.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.UseLazyLoadingProxies();
        });
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddTransient(typeof(ICrudRepository<>), typeof(CrudRepository<>));
        builder.Services.AddTransient<IAdopterRepository, AdopterRepository>();
        builder.Services.AddTransient<ICatRepository, CatRepository>();
        builder.Services.AddTransient<ICatService, CatService>();
        builder.Services.AddTransient<IAdopterService, AdopterService>();
        builder.Services.AddTransient<IFosterParentService, FosterParentService>();

        builder.Services.AddControllersWithViews();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            UserSeeder.Initialize(services).Wait();
        }
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}
