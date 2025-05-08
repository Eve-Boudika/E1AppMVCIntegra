using E1WebMVC.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace E1WebMVC.Repository.AppDBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
