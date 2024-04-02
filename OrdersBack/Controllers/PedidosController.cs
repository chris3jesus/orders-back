using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersBack.Models;
using System.Linq;

namespace OrdersBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly BdatosContext _context;
        public PedidosController(BdatosContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidoapp>>> GetPedidos()
        {
            return await _context.Pedidoapps.Include(p => p.Detpedidos).ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidoapp>> GetPedido(int id)
        {
            var pedido = await _context.Pedidoapps.Include(p => p.Detpedidos).FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound("No se encontraron pedidos.");
            }
            return pedido;
        }

        // GET: api/Pedidos/v/5
        [HttpGet("v/{vendedor}")]
        public async Task<ActionResult<IEnumerable<Pedidoapp>>> GetPedidoVen(int vendedor)
        {
            DateTime fechaActual = DateTime.Today;
            var pedido = await _context.Pedidoapps.Include(p => p.Detpedidos).Where(p => p.FechaReg.Date == fechaActual && p.CodVen == vendedor).ToListAsync();

            if (pedido == null)
            {
                return NotFound("No se encontraron pedidos.");
            }
            return pedido;
        }

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedidoapp pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            try
            {
                var pedidoExistente = await _context.Pedidoapps.Include(p => p.Detpedidos).FirstOrDefaultAsync(p => p.Id == id);

                if (pedidoExistente == null)
                {
                    return NotFound("No se encontraron pedidos.");
                }

                pedidoExistente.TipoDoc = pedido.TipoDoc;
                pedidoExistente.Estado = "Modificado";
                pedidoExistente.IdDirCli = pedido.IdDirCli;
                pedidoExistente.Latitud = pedido.Latitud;
                pedidoExistente.Longitud = pedido.Longitud;
                pedidoExistente.Flete = pedido.Flete;
                pedidoExistente.Observ = pedido.Observ;
                pedidoExistente.FechaEdit = DateTime.Now;

                _context.Detpedidos.RemoveRange(pedidoExistente.Detpedidos);
                pedidoExistente.Detpedidos.Clear();

                if (pedido.Detpedidos != null && pedido.Detpedidos.Any())
                {
                    int itemCounter = 1;
                    decimal subtotalPedido = 0;
                    decimal igvPedido = 0;
                    decimal totalPedido = 0;

                    foreach (var detalle in pedido.Detpedidos)
                    {
                        var codart = _context.Artis.FirstOrDefault(x => x.ArtAlterno == detalle.IdProd.ToString() && x.ArtCodcia == "01" && x.ArtSituacion == "0");
                        var precio = await _context.Precios.FirstOrDefaultAsync(a => a.PreCodart == codart.ArtKey && a.PreFlagUnidad == "A" && a.PreCodcia == "01");

                        if (precio != null)
                        {
                            decimal valor = (decimal)precio.PrePre1;

                            var nuevoDetalle = new Detpedido
                            {
                                IdProd = detalle.IdProd,
                                Cantidad = detalle.Cantidad,
                                Item = itemCounter++,
                                Valor = valor,
                                Precio = Math.Round(valor * 1.18m, 4),

                                Dscto1 = detalle.Dscto1,
                                Dscto2 = detalle.Dscto2,

                                PrecDscto = Math.Round(valor * 1.18m * (1 - detalle.Dscto1 / 100m) * (1 - detalle.Dscto2 / 100m), 4),
                                Subtotal = Math.Round(valor * detalle.Cantidad * (1 - detalle.Dscto1 / 100m) * (1 - detalle.Dscto2 / 100m), 2),
                                Igv = Math.Round(valor * detalle.Cantidad * (1 - detalle.Dscto1 / 100m) * (1 - detalle.Dscto2 / 100m) * 0.18m, 2),
                                Total = Math.Round(valor * detalle.Cantidad * (1 - detalle.Dscto1 / 100m) * (1 - detalle.Dscto2 / 100m) * 1.18m, 2)
                            };

                            subtotalPedido += nuevoDetalle.Subtotal;
                            igvPedido += nuevoDetalle.Igv;
                            totalPedido += nuevoDetalle.Total;
                            pedidoExistente.Detpedidos.Add(nuevoDetalle);
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró un precio para el producto con ID {detalle.IdProd}.");
                        }
                    }
                    pedidoExistente.Subtotal = Math.Round(subtotalPedido, 2);
                    pedidoExistente.Igv = Math.Round(igvPedido, 2);
                    pedidoExistente.Total = Math.Round(totalPedido, 2);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound("No se encontraron pedidos.");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Pedidos
        [HttpPost]
        public async Task<ActionResult<Pedidoapp>> PostPedido(Pedidoapp pedido)
        {
            try
            {
                pedido.Codigo = GeneratePedidoCode(pedido);
                pedido.CondPago = "Contado";
                pedido.DiasCred = 1;
                pedido.FechaReg = DateTime.Now;
                pedido.Estado = "Pendiente";

                _context.Pedidoapps.Add(pedido);
                await _context.SaveChangesAsync();

                if (pedido.Detpedidos != null && pedido.Detpedidos.Any())
                {
                    List<Detpedido> nuevosDetalles = new List<Detpedido>();

                    int itemCounter = 1;
                    decimal subtotalPedido = 0;
                    decimal igvPedido = 0;
                    decimal totalPedido = 0;

                    foreach (var detalle in pedido.Detpedidos)
                    {
                        var codart = _context.Artis.FirstOrDefault(x => x.ArtAlterno == detalle.IdProd.ToString() && x.ArtCodcia == "01" && x.ArtSituacion == "0");
                        var precio = await _context.Precios.FirstOrDefaultAsync(a => a.PreCodart == codart.ArtKey && a.PreFlagUnidad == "A" && a.PreCodcia == "01");

                        if (precio != null)
                        {
                            detalle.Item = itemCounter++;

                            decimal valor = (decimal)precio.PrePre1;
                            detalle.Valor = valor;
                            detalle.Precio = Math.Round(valor * 1.18m, 4);

                            // detalle.Dscto1 = 5;
                            // detalle.Dscto2 = 0;
                            detalle.PrecDscto = Math.Round(detalle.Precio * (1 - detalle.Dscto1 / 100m) * (1 - detalle.Dscto2 / 100m), 4);

                            // detalle.Subtotal = Math.Round(detalle.PrecDscto * detalle.Cantidad, 2);
                            detalle.Subtotal = Math.Round(detalle.Valor * detalle.Cantidad * (1 - detalle.Dscto1 / 100m) * (1 - detalle.Dscto2 / 100m), 2);

                            // detalle.Igv = Math.Round(detalle.Subtotal * 0.18m, 2);
                            detalle.Igv = Math.Round(detalle.Valor * detalle.Cantidad * (1 - detalle.Dscto1 / 100m) * (1 - detalle.Dscto2 / 100m) * 0.18m, 2);

                            // detalle.Total = Math.Round(detalle.Subtotal + detalle.Igv, 2);
                            detalle.Total = Math.Round(detalle.PrecDscto * detalle.Cantidad, 2);

                            subtotalPedido += detalle.Subtotal;
                            igvPedido += detalle.Igv;
                            totalPedido += detalle.Total;

                            nuevosDetalles.Add(detalle);
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró un precio para el producto con ID {detalle.IdProd}.");
                        }
                    }

                    pedido.Subtotal = Math.Round(subtotalPedido, 2);
                    pedido.Igv = Math.Round(igvPedido, 2);
                    pedido.Total = Math.Round(totalPedido, 2);

                    pedido.Detpedidos.Clear();
                    pedido.Detpedidos = nuevosDetalles;
                }

                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el pedido: {ex.ToString()}");
                return StatusCode(500, $"Error al crear el pedido: {ex.Message}");
            }
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidoapps.Any(e => e.Id == id);
        }

        private string GeneratePedidoCode(Pedidoapp pedido)
        {
            int codVen = pedido.CodVen;
            string fechaActual = DateTime.Now.ToString("ddMMyyyy");

            int count = _context.Pedidoapps.Count(p => p.CodVen == codVen && p.FechaReg.Date == DateTime.Today);

            string pedidoCode = $"{codVen}-{fechaActual}-{count + 1}";
            return pedidoCode;
        }
    }
}
