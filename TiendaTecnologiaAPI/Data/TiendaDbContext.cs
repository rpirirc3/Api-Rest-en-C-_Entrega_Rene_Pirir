using Microsoft.EntityFrameworkCore;
using TiendaTecnologiaAPI.Models;

namespace TiendaTecnologiaAPI.Data;

public class TiendaDbContext : DbContext
{
    public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
    {
    }

    public DbSet<Marca> Marcas => Set<Marca>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marca>().HasKey(m => m.IdMarca);
        modelBuilder.Entity<Producto>().HasKey(p => p.IdProducto);
        modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);

        modelBuilder.Entity<Producto>()
            .HasOne<Marca>()
            .WithMany()
            .HasForeignKey(p => p.IdMarca)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Nit)
            .IsUnique();
    }
}
