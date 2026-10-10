using Microsoft.EntityFrameworkCore;
using TiendaTecnologiaAPI.Data;
using TiendaTecnologiaAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TiendaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Crea la base de datos automáticamente y agrega datos iniciales de prueba.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TiendaDbContext>();
    db.Database.EnsureCreated();

    var marcasIniciales = new[] { "Logitech", "Kingston", "Samsung" };
    foreach (var nombreMarca in marcasIniciales)
    {
        if (!db.Marcas.Any(m => m.Nombre == nombreMarca))
            db.Marcas.Add(new Marca { Nombre = nombreMarca });
    }
    db.SaveChanges();

    if (!db.Productos.Any())
    {
        var logitech = db.Marcas.First(m => m.Nombre == "Logitech");
        var kingston = db.Marcas.First(m => m.Nombre == "Kingston");
        var samsung = db.Marcas.First(m => m.Nombre == "Samsung");

        db.Productos.AddRange(
            new Producto { IdMarca = logitech.IdMarca, Nombre = "Mouse inalámbrico", Precio = 175.00m, Stock = 20 },
            new Producto { IdMarca = kingston.IdMarca, Nombre = "Memoria USB 64 GB", Precio = 95.00m, Stock = 35 },
            new Producto { IdMarca = samsung.IdMarca, Nombre = "SSD 1 TB", Precio = 650.00m, Stock = 10 }
        );
        db.SaveChanges();
    }

    if (!db.Clientes.Any())
    {
        db.Clientes.AddRange(
            new Cliente { Nit = "5487210-3", Nombre = "Carlos", Apellidos = "López", Email = "carlos@example.com" },
            new Cliente { Nit = "3216549-8", Nombre = "Andrea", Apellidos = "Morales", Email = "andrea@example.com" }
        );
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
