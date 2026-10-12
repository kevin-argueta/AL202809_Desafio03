using AL208209_Desafio3.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AL208209_Desafio3.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
