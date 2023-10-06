using Azure.Identity;
using crudapp.Data;
using Microsoft.EntityFrameworkCore;
namespace crudapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddAzureKeyVault(new Uri("https://keyvault-dev-karuna.vault.azure.net/"), new DefaultAzureCredential());

            builder.Services.AddDbContext<crudappContext>(options =>
                 options.UseSqlServer(builder.Configuration["crudappContext"] ?? throw new InvalidOperationException("Connection string 'crudappContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<crudappContext>();
                    //dbContext.Database.EnsureCreated();
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = app.Services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An Error occured creating the db");
                }
            }

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}