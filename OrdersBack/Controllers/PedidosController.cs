using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersBack.Models;

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

                decimal subtotalPedido = 0;
                decimal igvPedido = 0;
                decimal totalPedido = 0;

                foreach (var detalle in pedido.Detpedidos)
                {
                    var detalleExistente = pedidoExistente.Detpedidos.FirstOrDefault(d => d.Id == detalle.Id);

                    if (detalleExistente != null)
                    {
                        detalleExistente.Cantidad = detalle.Cantidad;
                        var precio = await _context.Precios.FirstOrDefaultAsync(a => a.PreCodart == detalle.IdProd && a.PreFlagUnidad == "A" && a.PreCodcia == "01");

                        if (precio != null)
                        {
                            detalleExistente.Valor = (decimal)precio.PrePre1;
                            detalleExistente.Precio = Math.Round(detalleExistente.Valor * 1.18m, 4);
                            detalleExistente.PrecDscto = Math.Round(detalleExistente.Precio * (1 - detalleExistente.Dscto1 / 100m), 4);
                            detalleExistente.Subtotal = Math.Round(detalleExistente.PrecDscto * detalleExistente.Cantidad, 2);
                            detalleExistente.Igv = Math.Round(detalleExistente.Subtotal * 0.18m, 2);
                            detalleExistente.Total = Math.Round(detalleExistente.Subtotal + detalleExistente.Igv, 2);

                            subtotalPedido += detalleExistente.Subtotal;
                            igvPedido += detalleExistente.Igv;
                            totalPedido += detalleExistente.Total;
                        }
                    }
                    else
                    {
                        var nuevoDetalle = new Detpedido
                        {
                            Item = pedidoExistente.Detpedidos.Count + 1,
                            IdProd = detalle.IdProd,
                            Cantidad = detalle.Cantidad,
                            Dscto1 = 5
                        };

                        var precio = await _context.Precios.FirstOrDefaultAsync(a => a.PreCodart == detalle.IdProd && a.PreFlagUnidad == "A" && a.PreCodcia == "01");

                        if (precio != null)
                        {
                            nuevoDetalle.Valor = (decimal)precio.PrePre1;
                            nuevoDetalle.Precio = Math.Round(nuevoDetalle.Valor * 1.18m, 4);
                            nuevoDetalle.PrecDscto = Math.Round(nuevoDetalle.Precio * (1 - nuevoDetalle.Dscto1 / 100m), 4);
                            nuevoDetalle.Subtotal = Math.Round(nuevoDetalle.PrecDscto * nuevoDetalle.Cantidad, 2);
                            nuevoDetalle.Igv = Math.Round(nuevoDetalle.Subtotal * 0.18m, 2);
                            nuevoDetalle.Total = Math.Round(nuevoDetalle.Subtotal + nuevoDetalle.Igv, 2);
                        }

                        pedidoExistente.Detpedidos.Add(nuevoDetalle);

                        subtotalPedido += nuevoDetalle.Subtotal;
                        igvPedido += nuevoDetalle.Igv;
                        totalPedido += nuevoDetalle.Total;
                    }
                }

                pedidoExistente.Subtotal = Math.Round(subtotalPedido, 2);
                pedidoExistente.Igv = Math.Round(igvPedido, 2);
                pedidoExistente.Total = Math.Round(totalPedido, 2);
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
                        var precio = await _context.Precios.FirstOrDefaultAsync(a => a.PreCodart == detalle.IdProd && a.PreFlagUnidad == "A" && a.PreCodcia == "01");

                        if (precio != null)
                        {
                            detalle.Item = itemCounter++;

                            decimal valor = (decimal)precio.PrePre1;
                            detalle.Valor = valor;
                            detalle.Precio = Math.Round(valor * 1.18m, 4);

                            detalle.Dscto1 = 5;
                            detalle.Dscto2 = 0;
                            detalle.PrecDscto = Math.Round(detalle.Precio * (1 - detalle.Dscto1 / 100m), 4);

                            detalle.Subtotal = Math.Round(detalle.PrecDscto * detalle.Cantidad, 2);
                            detalle.Igv = Math.Round(detalle.Subtotal * 0.18m, 2);
                            detalle.Total = Math.Round(detalle.Subtotal + detalle.Igv, 2);

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
