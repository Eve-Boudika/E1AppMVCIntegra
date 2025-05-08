using Microsoft.EntityFrameworkCore;
using E1WebMVC.Repository.AppDBContext;
using E1WebMVC.Repository;
using E1WebMVC.Service;

namespace E1WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar el contexto de la base de datos
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppDbContext")));

            // Repositorio
            builder.Services.AddScoped<ClientRepository>();
            // Servicio
            builder.Services.AddScoped<ClientService>();

            builder.Services.AddControllersWithViews();

            // Add services to the container.

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
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
