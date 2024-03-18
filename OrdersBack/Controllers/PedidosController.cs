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

        // GET: api/Pedido/5
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

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedidoapp pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
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

        [HttpPost]
        public async Task<ActionResult<Pedidoapp>> PostPedido(Pedidoapp pedido)
        {
            pedido.FechaReg = DateTime.Now;

            _context.Pedidoapps.Add(pedido);
            await _context.SaveChangesAsync();

            List<Detpedido> nuevosDetalles = new List<Detpedido>();

            if (pedido.Detpedidos != null && pedido.Detpedidos.Any())
            {
                foreach (var detalle in pedido.Detpedidos)
                {
                    nuevosDetalles.Add(detalle);
                }
                pedido.Detpedidos.Clear();
            }

            pedido.Detpedidos = nuevosDetalles;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidoapps.Any(e => e.Id == id);
        }

        // TODO: check data
    }
}
