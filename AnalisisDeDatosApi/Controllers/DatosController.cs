using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnalisisDeDatosApi.Models;
using AnalisisDeDatosApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json; // Necesario para JsonElement

namespace AnalisisDeDatosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor: Aquí se inyecta el contexto de la base de datos
        public DatosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost("cargar")] // Este es el endpoint de tu API
        public async Task<IActionResult> CargarDatos([FromBody] JsonElement datos)
        {
            if (datos.ValueKind != JsonValueKind.Array)
            {
                return BadRequest("Se esperaba un arreglo JSON.");
            }

            foreach (var elemento in datos.EnumerateArray())
            {
                try
                {
                    // Convertimos el elemento JSON en un objeto de tu modelo
                    var datoDeVenta = new DatoDeVenta
                    {
                        Producto = elemento.GetProperty("producto").GetString(),
                        Marca = elemento.GetProperty("marca").GetString(), // Nuevo campo
                        Cantidad = elemento.GetProperty("cantidad").GetInt32(),
                        Precio = elemento.GetProperty("precio").GetDouble(), // Nuevo campo
                        Fecha = elemento.GetProperty("fecha").GetDateTime()
                    };

                    _context.DatosDeVentas.Add(datoDeVenta);
                }
                catch (Exception ex)
                {
                    // Manejo de errores si un elemento JSON no tiene el formato correcto
                    Console.WriteLine($"Error al procesar un elemento JSON: {ex.Message}");
                }
            }

            // Guardamos todos los datos en la base de datos
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Datos cargados exitosamente." });
        }

        [HttpGet("totalventas")]
        public async Task<IActionResult> GetTotalVentas()
        {
            var totalVentas = await _context.DatosDeVentas.SumAsync(d => d.Cantidad);

            return Ok(new { totalVentas = totalVentas });
        }

        [HttpGet("ventasporproducto")]
        public async Task<IActionResult> GetVentasPorProducto()
        {
            var ventas = await _context.DatosDeVentas
                .GroupBy(d => d.Producto)
                .Select(g => new
                {
                    Producto = g.Key,
                    TotalCantidad = g.Sum(d => d.Cantidad)
                })
                .ToListAsync();

            return Ok(ventas);
        }

        [HttpGet("ingresostotales")]
        public async Task<IActionResult> GetIngresosTotales()
        {
            var ingresosTotales = await _context.DatosDeVentas
                .SumAsync(d => d.Cantidad * d.Precio);

            return Ok(new { ingresosTotales = ingresosTotales });
        }

        [HttpGet("ingresosporproducto")]
        public async Task<IActionResult> GetIngresosPorProducto()
        {
            var ingresos = await _context.DatosDeVentas
                .GroupBy(d => d.Producto)
                .Select(g => new
                {
                    Producto = g.Key,
                    TotalIngresos = g.Sum(d => d.Cantidad * d.Precio)
                })
                .ToListAsync();

            return Ok(ingresos);
        }

        [HttpGet("datosdeventas")]
        public async Task<IActionResult> GetDatosDeVentas(int pagina = 1, int tamanoDePagina = 25)
        {
            var datosPaginados = await _context.DatosDeVentas
                .Skip((pagina - 1) * tamanoDePagina)
                .Take(tamanoDePagina)
                .ToListAsync();

            return Ok(datosPaginados);
        }

    }
}
