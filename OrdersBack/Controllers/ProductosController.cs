using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersBack.DTOs;
using OrdersBack.Models;

namespace OrdersBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly BdatosContext _context;
        public ProductosController(BdatosContext context)
        {
            _context = context;
        }

        // GET: api/producto/{key}
        [HttpGet("{key}")]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProducto(string key)
        {
            var productoQuery = _context.Artis.Where(a => a.ArtCodcia == "01" && a.ArtSituacion == "0");

            if (int.TryParse(key, out int codigo))
            {
                // productoQuery = productoQuery.Where(a => a.ArtKey == codigo);
                productoQuery = productoQuery.Where(a => a.ArtAlterno.Contains(key));
            }
            else
            {
                productoQuery = productoQuery.Where(a => a.ArtNombre.Contains(key));
            }

            var productos = await productoQuery.ToListAsync();
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos.");
            }

            var productosDtos = new List<ProductoDTO>();

            foreach (var producto in productos)
            {
                var articulo = await _context.Articulos.FirstOrDefaultAsync(a => a.ArmCodart == producto.ArtKey && a.ArmCodcia == "01");
                var precio = await _context.Precios.FirstOrDefaultAsync(a => a.PreCodart == producto.ArtKey && a.PreFlagUnidad == "A" && a.PreCodcia == "01");
                var marca = await _context.Tablas.FirstOrDefaultAsync(a => a.TabNumtab == producto.ArtFamilia && a.TabTipreg == 122 && a.TabCodcia == "01");

                if (articulo != null)
                {
                    if (articulo.Comprometido == null)
                    {
                        articulo.Comprometido = 0;
                    }
                    productosDtos.Add(new ProductoDTO
                    {
                        Codigo = producto.ArtAlterno.Trim(),
                        Descripcion = producto.ArtNombre.Trim(),
                        Marca = marca.TabNomlargo.Trim(),
                        Presentacion = precio.PreUnidad.Trim(),
                        Valor = (decimal)precio.PrePre1,
                        Precio = Math.Round((decimal)precio.PrePre1 * 1.18m, 4),
                        Stock = (int)articulo.ArmStock / (int)precio.PreEquiv - (int)articulo.Comprometido
                    });
                }
                else
                {
                    return NotFound("ERROR: Consulte al administrador de base de datos.");
                }
            }
            return productosDtos;
        }
    }
}
