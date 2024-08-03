using apiGestores.Models;
using Microsoft.EntityFrameworkCore;

namespace apiGestores.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Gestores_Bd> GESTORES_BD { get; set; }
    }
}
