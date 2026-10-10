using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaTecnologiaAPI.Data;
using TiendaTecnologiaAPI.Models;

namespace TiendaTecnologiaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarcasController : ControllerBase
{
    private readonly TiendaDbContext _context;

    public MarcasController(TiendaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
    {
        return await _context.Marcas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Marca>> GetMarca(int id)
    {
        var marca = await _context.Marcas.FindAsync(id);
        if (marca == null) return NotFound();
        return marca;
    }

    [HttpPost]
    public async Task<ActionResult<Marca>> PostMarca(Marca marca)
    {
        _context.Marcas.Add(marca);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMarca), new { id = marca.IdMarca }, marca);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMarca(int id, Marca marca)
    {
        if (id != marca.IdMarca) return BadRequest();

        _context.Entry(marca).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Marcas.AnyAsync(m => m.IdMarca == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMarca(int id)
    {
        var marca = await _context.Marcas.FindAsync(id);
        if (marca == null) return NotFound();

        if (await _context.Productos.AnyAsync(p => p.IdMarca == id))
            return BadRequest("No se puede eliminar una marca que tiene productos asociados.");

        _context.Marcas.Remove(marca);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
